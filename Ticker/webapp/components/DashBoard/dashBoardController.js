signalrApp.controller('DashboardCtrl', ['$scope', 'Tickets', 'TicketStream', function ($scope, Tickets, TicketStream) {
    "use strict";

    $scope.tickets = Tickets.query();

    TicketStream.on('addNewTicket', function (newTicket) {
        $scope.tickets.push(newTicket);
    });

}])