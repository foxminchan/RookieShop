$(document).ready(function () {
  const sortBtn = $("#sort-btn");
  const sortCategoryDropdown = $("#sort-category-dropdown");
  sortBtn.on("click", function () {
    const expanded = sortBtn.attr("aria-expanded") === "true" || false;
    sortBtn.attr("aria-expanded", !expanded);
    sortCategoryDropdown.toggleClass("hidden");
  });
  $(document).on("click", function (event) {
    if (!sortBtn.is(event.target) && sortBtn.has(event.target).length === 0) {
      sortBtn.attr("aria-expanded", false);
      sortCategoryDropdown.addClass("hidden");
    }
  });

  const showCategoryFilter = $("#show-category-filter");
  const hideCategoryFilter = $("#hide-category-filter");

  showCategoryFilter.on("click", function () {
    $("#filter-section-1").removeClass("hidden");
    showCategoryFilter.addClass("hidden");
    hideCategoryFilter.removeClass("hidden");
  });

  hideCategoryFilter.on("click", function () {
    $("#filter-section-1").addClass("hidden");
    showCategoryFilter.removeClass("hidden");
    hideCategoryFilter.addClass("hidden");
  });
});
