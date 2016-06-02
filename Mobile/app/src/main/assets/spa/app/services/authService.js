app.factory('authService', ['$location', 'localStorageService', function ($location, localStorageService) {

        if (localStorageService.get('user')) {
            var authService = {
                isAuthenticated: true
            };
        } else {
            var authService = {
                isAuthenticated: false
            };
        }

        authService.logIn = function (username, password) {
            if ((username === 'daniel' || username === 'dany07.dvd@gmail.com')  && password === 'daniel') {
                localStorageService.set('user', {
                    "username": "daniel",
                    "email": "dany07.dvd@gmail.com",
                    "name": "Daniel Velázquez",
                    "image": "1.jpg"
                });
                authService.isAuthenticated = true;
                $location.path('/');
            } else {
                return error = 'Error de usuario y contraseña';
            }
        };

        authService.logOut = function () {
            localStorageService.clearAll();
            this.isAuthenticated = false;
            $location.path('/login');
        };

        return authService;

    }]);