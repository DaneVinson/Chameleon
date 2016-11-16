angular.module('appServices', [])
    .service('AppService', ['$http', function ($http: ng.IHttpService) {
        var self = this;
        self.CheckAgentStatus = function () {
            return $http.get('http://localhost:6886/api/forms/', { timeout: 1000 });
        }
    }]);

angular.module('appControllers', ['appServices'])
    .controller('HomeController', function ($scope, AppService) {
        $scope.vm = this;
        this.description = "Exploratory application.";
        this.title = "Chameleon";
        this.checkStatus = function () {
            var promise: ng.IHttpPromise<boolean> = AppService.CheckAgentStatus();
            promise.success((data, status, headers, config) => {
                    console.log('success');
                })
                .error((data, status, headers, config) => {
                    console.log('error');
                })
                .finally(() => {
                });
        }
    })
    .controller('view1Controller', function ($scope) {
        $scope.vm = this;
        this.title = "View 1";
    })
    .controller('view2Controller', function ($scope) {
        $scope.vm = this;
        this.title = "View 2";
    });

angular.module('appConfig', ['ngRoute', 'appControllers'])
    .config(function ($routeProvider) {
        $routeProvider.when('/resources', {
            controller: 'HomeController',
            templateUrl: './html/home.html',
        });
        $routeProvider.when('/view1', {
            controller: 'view1Controller',
            templateUrl: './html/view1.html',
        });
        $routeProvider.when('/view2', {
            controller: 'view2Controller',
            templateUrl: './html/view2.html',
        });
        $routeProvider.otherwise({ redirectTo: '/resources' });
    });

var app = angular.module('app', ['appControllers', 'appConfig']);
