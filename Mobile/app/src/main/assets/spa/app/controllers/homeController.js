app.controller('homeController', ['$scope', '$http', '$location', 'authService', 'gridService', 'localStorageService',
    function ($scope, $http, $location, authService, gridService, localStorageService) {

        if (!authService.isAuthenticated) {
            $location.path('/login');
        }

        $scope.logout = function () {
            authService.logOut();
        };

        $scope.user = localStorageService.get('user');

        $http.get("assets/data/ideas.json")
                .success(function (response) {
                    $scope.ideas = response.ideas;
                    gridService('#grid', '.item');
                })
                .error(function () {
                    alert('Error, el sistema no ha podido cargar la información solicitada');
                });


    }]);
