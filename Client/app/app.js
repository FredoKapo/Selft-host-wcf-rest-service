//angular.module('tvmonitor', ['tvmonitor.controllers']);
//angular.module('tvmonitor.controllers', []).controller('DataCtrl', ['$scope', '$interval', '$timeout',



 var  DataCtrl=  function ($scope, $http, $interval) {
    $scope.format = 'M/d/yy h:mm:ss a';
    var intervalle = $interval(function () {
        $http.jsonp("http://localhost:8090/servicehost/GetHostInfos?callback=JSON_CALLBACK").
        success(function (data) {
            $scope.data = data;
            $scope.last_update = Date.now();
            $scope.MachineName = data.GetHostInfosResult.MachineName;
            $scope.Processes = data.GetHostInfosResult.Processes;
            //$scope.salutation = data.salutation;
            //$scope.greeting = data.greeting;

            //$("[ng-model='nameNew']").val(data.name);
            //$("[ng-model='salutation']").val(data.salutation);
            //$("[ng-model='greeting']").val(data.greeting);
        }).
        error(function (data) {
            $scope.error = "Request failed";
        });
    }, 2000);
} ;

