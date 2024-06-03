import{_ as t}from"./plugin-vue_export-helper-DlAUqK2U.js";import{c as e,o as a,a as n}from"./app-B-Z5UyYP.js";const d="/RookieShop/assets/image/architecture.png",r={},i=n('<h1 id="system-design" tabindex="-1"><a class="header-anchor" href="#system-design"><span>System Design</span></a></h1><h2 id="high-level-design" tabindex="-1"><a class="header-anchor" href="#high-level-design"><span>High Level Design</span></a></h2><p>The high level design of the system is based on the following components:</p><figure><img src="'+d+'" alt="Architecture Diagram" tabindex="0" loading="lazy"><figcaption>Architecture Diagram</figcaption></figure><table><thead><tr><th>No</th><th>Name</th><th>Usecase</th><th>Technology</th></tr></thead><tbody><tr><td>0</td><td>ingress</td><td>A reverse proxy that routes incoming requests to the appropriate service</td><td>Yarp</td></tr><tr><td>1</td><td>identity server</td><td>An authentication server that provides authentication and authorization services for the application</td><td>Duende IdentityServer 7.0</td></tr><tr><td>2</td><td>store front</td><td>A user-facing website that allows customers to view, rate, and purchase products</td><td>Razor, htmx, Alphine.js, ///_hyperscript</td></tr><tr><td>3</td><td>back office</td><td>An admin-facing website that allows administrators to manage products, categories, and customers</td><td>Next.js 14.0</td></tr><tr><td>4</td><td>web api</td><td>A REST API that provides data to the user-facing and admin-facing websites</td><td>ASP.NET Core 8.0</td></tr><tr><td>5</td><td>cache</td><td>A distributed lock manager, cache and cart storage</td><td>Redis</td></tr><tr><td>6</td><td>sql database</td><td>A relational database that stores the application&#39;s data and email outbox</td><td>Postgres, Marten</td></tr><tr><td>7</td><td>observability</td><td>A telemetry data collector that collects and exports telemetry data to the Aspire Dashboard</td><td>OpenTelemetry</td></tr></tbody></table><h2 id="c4-model" tabindex="-1"><a class="header-anchor" href="#c4-model"><span>C4 Model</span></a></h2><blockquote><p>TODO: Add C4 Model</p></blockquote>',7),o=[i];function s(c,h){return a(),e("div",null,o)}const g=t(r,[["render",s],["__file","index.html.vue"]]),m=JSON.parse(`{"path":"/design/","title":"System Design","lang":"en-US","frontmatter":{"description":"System Design High Level Design The high level design of the system is based on the following components: Architecture DiagramArchitecture Diagram C4 Model TODO: Add C4 Model","head":[["meta",{"property":"og:url","content":"https://vuepress-theme-hope-docs-demo.netlify.app/RookieShop/design/"}],["meta",{"property":"og:site_name","content":"RookieShop"}],["meta",{"property":"og:title","content":"System Design"}],["meta",{"property":"og:description","content":"System Design High Level Design The high level design of the system is based on the following components: Architecture DiagramArchitecture Diagram C4 Model TODO: Add C4 Model"}],["meta",{"property":"og:type","content":"article"}],["meta",{"property":"og:image","content":"https://vuepress-theme-hope-docs-demo.netlify.app/RookieShop/assets/image/architecture.png"}],["meta",{"property":"og:locale","content":"en-US"}],["meta",{"property":"og:updated_time","content":"2024-06-03T06:43:47.000Z"}],["meta",{"property":"article:author","content":"Nhan Nguyen"}],["meta",{"property":"article:modified_time","content":"2024-06-03T06:43:47.000Z"}],["script",{"type":"application/ld+json"},"{\\"@context\\":\\"https://schema.org\\",\\"@type\\":\\"Article\\",\\"headline\\":\\"System Design\\",\\"image\\":[\\"https://vuepress-theme-hope-docs-demo.netlify.app/RookieShop/assets/image/architecture.png\\"],\\"dateModified\\":\\"2024-06-03T06:43:47.000Z\\",\\"author\\":[{\\"@type\\":\\"Person\\",\\"name\\":\\"Nhan Nguyen\\",\\"url\\":\\"https://github.com/foxminchan\\"}]}"]]},"headers":[{"level":2,"title":"High Level Design","slug":"high-level-design","link":"#high-level-design","children":[]},{"level":2,"title":"C4 Model","slug":"c4-model","link":"#c4-model","children":[]}],"git":{"createdTime":1717342660000,"updatedTime":1717397027000,"contributors":[{"name":"Nguyen Xuan Nhan","email":"nguyenxuannhan407@gmail.com","commits":4}]},"readingTime":{"minutes":0.56,"words":167},"filePathRelative":"design/README.md","localizedDate":"June 2, 2024","autoDesc":true,"excerpt":"\\n<h2>High Level Design</h2>\\n<p>The high level design of the system is based on the following components:</p>\\n<figure><img src=\\"/assets/image/architecture.png\\" alt=\\"Architecture Diagram\\" tabindex=\\"0\\" loading=\\"lazy\\"><figcaption>Architecture Diagram</figcaption></figure>\\n<table>\\n<thead>\\n<tr>\\n<th>No</th>\\n<th>Name</th>\\n<th>Usecase</th>\\n<th>Technology</th>\\n</tr>\\n</thead>\\n<tbody>\\n<tr>\\n<td>0</td>\\n<td>ingress</td>\\n<td>A reverse proxy that routes incoming requests to the appropriate service</td>\\n<td>Yarp</td>\\n</tr>\\n<tr>\\n<td>1</td>\\n<td>identity server</td>\\n<td>An authentication server that provides authentication and authorization services for the application</td>\\n<td>Duende IdentityServer 7.0</td>\\n</tr>\\n<tr>\\n<td>2</td>\\n<td>store front</td>\\n<td>A user-facing website that allows customers to view, rate, and purchase products</td>\\n<td>Razor, htmx, Alphine.js, ///_hyperscript</td>\\n</tr>\\n<tr>\\n<td>3</td>\\n<td>back office</td>\\n<td>An admin-facing website that allows administrators to manage products, categories, and customers</td>\\n<td>Next.js 14.0</td>\\n</tr>\\n<tr>\\n<td>4</td>\\n<td>web api</td>\\n<td>A REST API that provides data to the user-facing and admin-facing websites</td>\\n<td>ASP.NET Core 8.0</td>\\n</tr>\\n<tr>\\n<td>5</td>\\n<td>cache</td>\\n<td>A distributed lock manager, cache and cart storage</td>\\n<td>Redis</td>\\n</tr>\\n<tr>\\n<td>6</td>\\n<td>sql database</td>\\n<td>A relational database that stores the application's data and email outbox</td>\\n<td>Postgres, Marten</td>\\n</tr>\\n<tr>\\n<td>7</td>\\n<td>observability</td>\\n<td>A telemetry data collector that collects and exports telemetry data to the Aspire Dashboard</td>\\n<td>OpenTelemetry</td>\\n</tr>\\n</tbody>\\n</table>"}`);export{g as comp,m as data};