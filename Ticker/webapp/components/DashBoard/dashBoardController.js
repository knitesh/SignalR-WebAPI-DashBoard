signalrApp.controller('DashboardCtrl', ['$scope', 'Item', 'ItemStream', function ($scope, Item, ItemStream) {
    "use strict";

    $scope.tickets = Item.query();

    ItemStream.on('addNewItem', function (newTicket) {
        $scope.tickets.push(newTicket);
    });

}])