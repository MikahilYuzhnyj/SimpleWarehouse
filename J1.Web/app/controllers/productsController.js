'use strict';
app.controller( 'productsController',
[
	'$scope', '$location', '$timeout', 'productService', function( $scope, $location, $timeout, productService ) {

		$scope.savedSuccessfully = false;
		$scope.message = "";

		$scope.newProductModel = {
			PrimarySku: "",
			PrimaryCode: "",
			Title: "",
			Description: "",
			Width: "",
			Cost: ""
		};

		$scope.createProduct = function() {
			productService.createProduct( $scope.newProductModel )
				.then( function( response ) {
						$scope.savedSuccessfully = true;
						$scope.message = "Продукт был успешно создан";
					},
					function( response ) {
						var errors = [];
						for( var key in response.data.modelState )
							for( var i = 0;
								i < response.data.modelState[ key ].length;
								i++
							) errors.push( response.data.modelState[ key ][ i ] );
						$scope.message = "Ошибка:" + errors.join( ' ' );
					} );
		};
	}
] );