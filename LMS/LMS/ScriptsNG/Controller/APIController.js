app.controller("APIController", function ($scope,APIService) {

    $scope.LoadApiList = function () {
        var getApiList = APIService.getApiList();
        getApiList.then(function (res) {
            $scope.categoryList = res.data;
        }, function () {
            swal("Something went wrong", "", "error");
        });
    }
});