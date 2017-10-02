'use strict';
app.factory( 'adminService',
[
	'$http', 'ngAuthSettings', 'authService', function( $http, ngAuthSettings, authService ) {

		var serviceBase = ngAuthSettings.apiServiceBaseUri;

		var adminServiceFactory = {};

		adminServiceFactory.getBrands = function() {
			return $http.get( serviceBase + 'api/brands/list' )
				.then( function( results ) {
						return results;
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		adminServiceFactory.getClassifications = function() {
			return $http.get( serviceBase + 'api/classifications/list' )
				.then( function( results ) {
						return results;
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		adminServiceFactory.getSuppliers = function() {
			return $http.get( serviceBase + 'api/suppliers/list' )
				.then( function( results ) {
						return results;
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		adminServiceFactory.createBrand = function( brand ) {
			return $http.post( serviceBase + 'api/brands/create', brand )
				.then( function( result ) {
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		adminServiceFactory.createClassification = function( classification ) {
			return $http.post( serviceBase + 'api/classifications/create', classification )
				.then( function( result ) {
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		adminServiceFactory.createSupplier = function( supplier ) {
			return $http.post( serviceBase + 'api/suppliers/create', supplier )
				.then( function( result ) {
					},
					function( response ) {
						if( response.data.exceptionType.indexOf( "AuthenticateException" ) != -1 )
							authService.logOut();
					} );
		};

		return adminServiceFactory;

	}
] );