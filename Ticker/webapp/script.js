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
            templateUrl: baseComponent +  'about/about.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: baseComponent + 'contact/contact.html',
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

