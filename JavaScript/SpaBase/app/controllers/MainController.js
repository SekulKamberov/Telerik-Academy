'use strict';

tripsModule.controller('MainController',
    ['$scope', '$log', '$routeParams', '$resource', '$location', 'statsService', 'examName', 'institution',
function MainController($scope, $log, $routeParams, $resource, $location, statsService, examName, institution) {
    $scope.header = 'app/views/partials/header.html';
    $scope.footer = 'app/views/partials/footer.html';
    $scope.overallStatistic = 'app/views/partials/overallStatistic.html';
    $scope.tripsPublic = 'app/views/partials/tripsHome.html';
    $scope.driversPublic = 'app/views/partials/driversHome.html';

    $scope.orderTripsBy = 'departureDate';
    $scope.limitTripsTo = 10;

    $scope.examName = examName;
    $scope.institution = institution;

    $scope.tripsStatistic;
    statsService.getTripsStatistics()
                .then(function (data) {
                    $scope.tripsStatistic = data;
                    console.log(data);
                })
                .catch($log.error);

    $scope.latestTrips;
    statsService.getLatestTrips()
                .then(function (data) {
                    $scope.latestTrips = data;
                    console.log(data);
                })
                .catch($log.error);

    $scope.latestDrivers;
    statsService.getLatestDrivers()
                .then(function (data) {
                    $scope.latestDrivers = data;
                    console.log(data);
                })
                .catch($log.error);
}]);