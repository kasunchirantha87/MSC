app.controller("APIController", function ($scope, APIService) {
    $scope.githubData = [];
    $scope.stackOverflowData = [];
  
    $scope.LoadGitApiList = function () {
        var githubUsername = $scope.GitUserName;
        if (githubUsername.length == 0) {
            alert('Please enter a username');
        }

        var githubDataResponse = APIService.getGithubDataByUsername(githubUsername);
        githubDataResponse.then(function (result) {
            $scope.githubData = [];
            for (var key in result.data) {
                if (result.data.hasOwnProperty(key)) {
                    var obj = { key: key, value: result.data[key] };
                    $scope.githubData.push(obj);
                }
            }
        });
    }

    $scope.LoadTwitterApiList = function () {
        var twitterUserName = $scope.TwitterUserName;
        if (twitterUserName.length == 0) {
            alert('Please enter a username');
        }

        var twitterDataResponse = APIService.getTwitterDataByUsername(twitterUserName);
        twitterDataResponse.then(function (result) {
            //yet to do
        });
    }

    $scope.LoadStackOverflowApiList = function () {
        var stackUserId = $scope.StckUserName;
        if (stackUserId.length == 0) {
            alert('Please enter a userId');
        }

        var twitterDataResponse = APIService.getSODataByUserId(stackUserId);
        twitterDataResponse.then(function (result) {
            $scope.stackOverflowData = [];
            for (var key in result.data.items[0]) {
                if (result.data.items[0].hasOwnProperty(key)) {
                    var obj = { key: key, value: result.data.items[0][key] };
                    $scope.stackOverflowData.push(obj);
                }
            }
        });
    }
    

});