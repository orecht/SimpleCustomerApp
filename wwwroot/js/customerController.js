(function () {
    'use strict';

    angular
        .module('app-movolytics')
        .controller('customerController', customerController);

    //customerController.$inject = ['$location'];
    customerController.$inject = ['$http'];

    function customerController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'customerController';
        vm.customers = [];
        vm.showLoading = false;

        vm.showCustomers = function () {
            vm.customers = [];
            vm.showLoading = true;

            $http.get("/api/customers?joinedafterdate=2016-02-15")
                .then(function (response) {
                    angular.copy(response.data, vm.customers);
                }, function error() {
                    vm.errorMessage = "Failed to load data: " + error;
                })
                .finally(function () {
                    vm.showLoading = false;
                });
        };

        activate();

        function activate() { }
    }
})();
