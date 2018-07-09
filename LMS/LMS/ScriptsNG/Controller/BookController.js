app.controller("BookController", function ($scope,BookService) {
    //LoadCategory();


    $scope.LoadCategory = function () {
        var getCategoryData = BookService.getCategories();
        getCategoryData.then(function (res) {
            $scope.categoryList = res.data;
        }, function () {
            swal("Something went wrong", "", "error");
        });
    }

    //$scope.saveBook = function () {
    //    var check = validation();

    //    if (check == true) {
    //        var saveBook = BookService.saveBook($scope.BookName, $scope.ISBN, $scope.Author, $scope.Language,
    //            $scope.PurchaseDate, $scope.CategoryID, $scope.Status);

    //            saveBook.then(function (msg) {
    //                if (msg.data == "Success") {
    //                    swal("Successfully saved", "", "success");
    //                }
    //                else {
    //                    swal("Something went wrong", "", "error");
    //                }
    //            }, function () {
    //                swal("Something went wrong", "", "error");
    //            });
    //    }
    //    else {
    //        swal("Mandatory fields cannot blank", "", "error");
    //    }
    //}

    //function validation() {
    //    return true;
    //}
});