app.controller("APIController", function ($scope,APIService) {

    $scope.LoadStackOverflowApiList = function () {
        var getStackOverflowApiList = APIService.getStackOverflowApiList($scope.StckUserName);
        getStackOverflowApiList.then(function (res) {
            $scope.categoryList = res.data;
        }, function () {
            swal("Something went wrong", "", "error");
        });
    }
});