app.service("APIService", function ($http) {

    this.getStackOverflowApiList = function (stackUser) {
        var response = $http({
            method: "post",
            url: "API/GetStackOverflowApiList",
            data: {
                StackUser: stackUser,
            }
        });

        return response;
    }
});