signalrApp.controller('CreateCtrl', [
    '$scope', '$location', 'Item', function ($scope, $location, Item) {
        "use strict";

        $scope.save = function (newTicket) {
            Item.save(newTicket, function () {
                $location.path('/Dashboard');
            });
        };

        $scope.cancel = function () {
            $location.path('/');
        }

    }
]);
