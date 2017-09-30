'use strict';
app.factory( 'productsService', [ '$http', 'ngAuthSettings', 'authService', function( $http, ngAuthSettings, authService ) {

		var serviceBase = ngAuthSettings.apiServiceBaseUri;

		var productsServiceFactory = {};

		productsServiceFactory.getProducts = function( pageNumber, pageSize ) {
			return $http.get( serviceBase + 'api/products/list?pageNumber=' + ( pageNumber - 1 ) + '&pageSize=' + pageSize )
				.then( function( results ) {
						return results;
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		productsServiceFactory.getBrands = function() {
			return $http.get( serviceBase + 'api/products/getBrands' )
				.then( function( results ) {
						return results;
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		productsServiceFactory.getClassifications = function () {
			return $http.get(serviceBase + 'api/products/getClassifications')
				.then(function (results) {
					return results;
				},
					function (response) {
						if (response.data.exceptionType.indexOf("AuthenticateException") != -1)
							authService.logOut();
					});
		};

		productsServiceFactory.getSuppliers = function () {
			return $http.get(serviceBase + 'api/products/getSuppliers')
				.then(function (results) {
					return results;
				},
					function (response) {
						if (response.data.exceptionType.indexOf("AuthenticateException") != -1)
							authService.logOut();
					});
		};

		productsServiceFactory.createProduct = function( product ) {
			return $http.post( serviceBase + 'api/products/create', product )
				.then( function( result ) {
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		return productsServiceFactory;

	}
] );