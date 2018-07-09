app.service("APIService", function ($http) {

    this.getApiList = function () {
        return $http.get("API/getApiList");
    }
});