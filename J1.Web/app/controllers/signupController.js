'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
    	TenantName: "tenant-1",
    	TenantPhone: "89376458129",
    	TenantAddress: "Samara",
    	TenantEmail: "tenant@gmail.com",
    	UserName: "Mikhail Rassudishkin",
    	Email: "rassudishkin@gmail.com",
    	Phone: "89376458129",
    	Password: "!BORO1812dino",
    	ConfirmPassword: "!BORO1812dino"
    };

    $scope.signUp = function () {
    	authService.saveRegistration($scope.registration).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "Пользователь был успешно зарегистрирован";
            //startTimer();
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Ошибка регистрации:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

}]);