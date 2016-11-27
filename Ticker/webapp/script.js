// create the module and name it scotchApp
var signalrApp = angular.module('signalrApp', ['ngRoute', 'signalrApp.data']);

// configure our routes
signalrApp.config(function ($routeProvider) {
    var baseComponent = 'webapp/components/';

    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: baseComponent + 'home/homeTemplate.html',
            controller: 'homeController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'webapp/pages/about.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'webapp/pages/contact.html',
            controller: 'contactController'
        })
        .when('/Dashboard', {
            controller: 'DashboardCtrl',
            templateUrl: baseComponent + 'DashBoard/dashboard.html'
        })
        .when('/new', {
            controller: 'CreateCtrl',
            templateUrl: baseComponent + 'New/ticket.html'
        })
    .otherwise({
        redirectTo: '/'
    });
});


signalrApp.controller('aboutController', function ($scope) {
    $scope.message = 'Look! I am an about page.';
});

signalrApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});


signalrApp.controller('CreateCtrl', [
    '$scope', '$location', 'Tickets', function($scope, $location, Tickets) {
        "use strict";

        $scope.save = function(newTicket) {
            Tickets.save(newTicket, function() {
                $location.path('/Dashboard');
            });
        };

        $scope.cancel = function() {
            $location.path('/');
        }

    }
]);
   
signalrApp.filter('reverse', function () {
        return function (items) {
            return items.slice().reverse();
        };
    });
