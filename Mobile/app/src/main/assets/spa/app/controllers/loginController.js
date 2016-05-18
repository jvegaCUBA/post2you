app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

        if (authService.isAuthenticated) {
            $location.path('/home');
        }

        $scope.login = function () {
            if ($scope.username && $scope.password) {
                $scope.error = authService.logIn($scope.username, $scope.password);
            }
        };

    }]);


