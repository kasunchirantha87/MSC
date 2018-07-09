app.service("BookService", function ($http) {

    this.getCategories = function () {
        return $http.get("Book/getCategories");
    }

    //this.saveBook = function () {
    //    return $http.get("Book/saveBook");
    //}
});