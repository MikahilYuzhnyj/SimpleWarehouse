'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', 'authService', function ($http, ngAuthSettings, authService) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    var _getOrders = function () {
    	return $http.get(serviceBase + 'api/orders').then(function (results) {
            return results;
    	},
		function (response) {
			if (response.data.exceptionType.indexOf("AuthenticateException") != -1)
				authService.logOut();
		});
    };

    ordersServiceFactory.getOrders = _getOrders;

    return ordersServiceFactory;

}]);