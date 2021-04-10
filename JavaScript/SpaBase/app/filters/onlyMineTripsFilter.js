'use strict';

tripsModule.filter('onlyMineTripsFilter', [
    function onlyMineTripsFilter() {
        return function (input, onlyMineTrips, myName) {
            if (onlyMineTrips === true) {
                var mineTrips = [];
                for (var i in input) {
                    if (input[i]['isMine'] === true) {
                        mineTrips.push(input[i]);
                    }
                }

                return mineTrips;
            }
            else {
                return input;
            }
        }
    }]);