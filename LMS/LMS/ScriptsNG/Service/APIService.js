app.service("APIService", function ($http) {

    
    this.getGithubDataByUsername = function (gitUsername) {
        var response = $http({
            method: "post",
            url: "/API/GetGithubDataByUsername",
            data: { GitUsername: gitUsername}
        });

        return response;
    }

    this.getTwitterDataByUsername = function (twitterUserName) {
        var response = $http({
            method: "post",
            url: "/API/GetTwitterDataByUsername",
            data: { TwitterUsername: twitterUserName }
        });

        return response;
    }

    this.getSODataByUserId = function (SoUserId) {
        var response = $http({
            method: "post",
            url: "/API/GetSoDataByUserId",
            data: { SoUserId: SoUserId }
        });

        return response;
    }
    
});