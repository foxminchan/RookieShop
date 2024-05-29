using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.Npm;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;

[GitHubActions("ci",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    OnPushBranches = ["main"],
    OnPullRequestBranches = ["main"],
    InvokedTargets = [nameof(Init), nameof(Lint), nameof(TestWithCoverage)])]
public class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main () => Execute<Build>(x => x.Compile);

    [Solution] readonly Solution Solution = default!;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    const string ProjectName = "RookieShop.*";
    string ProjectPrefix => $"{ProjectName}*";
    const string TestFolder = "Tests";
    const string CoverageFolderName = "coverage";
    string CoveragePrefix => $"{CoverageFolderName}.*";
    string CoverageReportFile => "coverage.xml";


    Target Init => d => d
        .Executes(() => NpmTasks.NpmCi());

    Target Clean => d => d
        .Executes(() => Solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetClean(s => s
                .SetProject(project)
            )));

    Target Restore => d => d
        .After(Clean)
        .Executes(() => Solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetRestore(s => s
                .SetProjectFile(project)
            )));

    Target Lint => d => d
        .After(Init)
        .Executes(() =>
        {
            NpmTasks.NpmRun(s => s
                .SetCommand("lint"));
            Solution.GetAllProjects(ProjectPrefix)
                .ForEach(project => DotNetTasks.DotNetBuild(s => s
                    .SetProjectFile(project)
                    .AddWarningsAsErrors()));
        });

    Target Format => d => d
        .DependsOn(Restore)
        .After(Lint)
        .Executes(() => Solution.GetAllProjects(ProjectPrefix)
            .ForEach(project => DotNetTasks.DotNetFormat(s => s
                .SetProject(project)
            )));

    Target Compile => d => d
        .DependsOn(Restore)
        .Executes(() => Solution.GetAllProjects(ProjectName)
            .ForEach(project => DotNetTasks.DotNetBuild(s => s
                .SetProjectFile(project)
                .SetNoRestore(true)
            )));

    Target Recompile => d => d
        .DependsOn(Clean, Compile);

    Target Test => d => d
        .DependsOn(Compile)
        .Executes(() => Solution.GetSolutionFolder(TestFolder)?.Projects
            .ForEach(project => DotNetTasks.DotNetTest(s => s
                .SetProjectFile(project)
                .SetConfiguration(Configuration)
                .SetNoRestore(true)
            )));

    Target TestWithCoverage => d => d
        .DependsOn(Compile)
        .After(Lint)
        .Executes(() =>
        {
            Solution.GetSolutionFolder(TestFolder)?.Projects
                .ForEach(project => DotNetTasks.DotNetTest(s => s
                    .SetProjectFile(project)
                    .SetConfiguration(Configuration)
                    .SetCollectCoverage(true)
                    .SetCoverletOutputFormat(CoverletOutputFormat.opencover)
                    .SetCoverletOutput(RootDirectory / CoverageFolderName / CoverageReportFile)
                    .SetExcludeByFile("**/Migrations/*.cs%2C**/Function/*.cs")
                    .SetNoRestore(true)
                ));
        });

    Target Ci => d => d
        .DependsOn(Init, Lint, TestWithCoverage);

    Target GenerateHtmlTestReport => d => d
        .DependsOn(TestWithCoverage)
        .Executes(() => ReportGeneratorTasks.ReportGenerator(s => s
            .SetReports(RootDirectory / CoverageFolderName / CoverageReportFile)
            .SetTargetDirectory(RootDirectory / CoverageFolderName)
            .SetReportTypes(ReportTypes.HtmlInline)
        ));

    Target Reset => d => d
        .Before(Clean)
        .Executes(() => RootDirectory.GlobDirectories(CoverageFolderName).DeleteDirectories())
        .Executes(() => RootDirectory.GlobFiles(CoveragePrefix).DeleteFiles());
}
