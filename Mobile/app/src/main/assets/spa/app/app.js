var app = angular.module('nideasApp', ['ngRoute', 'LocalStorageModule']);

app.config(function ($routeProvider, localStorageServiceProvider) {

    $routeProvider
            .when('/login', {
                controller: 'loginController',
                templateUrl: 'app/views/login.html'
            })
            .when('/singup', {
                controller: 'singupController',
                templateUrl: 'app/views/singup.html'
            })
            .when('/recovery-password', {
                controller: 'recoveryPasswordController',
                templateUrl: 'app/views/recovery-password.html'
            })
            .when('/', {
                controller: 'homeController',
                templateUrl: 'app/views/home.html'
            })
            .otherwise({redirectTo: '/'});
    
    localStorageServiceProvider.setPrefix('nideasApp');

});

