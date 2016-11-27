angular.module('signalrApp.data', ['ngResource'])
    .factory('Item', ['$resource', function ($resource) {
        'use strict';

        return $resource('/api/tickets');
    }])   
    .factory('ItemStream', ['$rootScope', function ($rootScope) {
        'use strict';
        
        return {
            on: function (eventName, callback) {
                var connection = $.hubConnection();
                var ticketHubProxy = connection.createHubProxy('dataHub');
              
                ticketHubProxy.on(eventName, function () {                  
                    var args = arguments;
                    $rootScope.$apply(function () {
                        callback.apply(ticketHubProxy, args);
                    });
                });
               
                connection.start().done(function () { });

            }
        };
    }]);