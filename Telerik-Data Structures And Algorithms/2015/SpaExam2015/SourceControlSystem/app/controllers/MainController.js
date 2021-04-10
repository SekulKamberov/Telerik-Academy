'use strict';

projectsModule.controller('MainController',
    ['$scope', '$log', '$routeParams', '$resource', '$location', 'statsService', 'examName', 'institution',
function MainController($scope, $log, $routeParams, $resource, $location, statsService, examName, institution) {
    $scope.header = 'app/views/partials/header.html';
    $scope.footer = 'app/views/partials/footer.html';
    $scope.overallStatistic = 'app/views/partials/overallStatistic.html';
    $scope.projectsPublic = 'app/views/partials/projectsHome.html';
    $scope.commitsPublic = 'app/views/partials/commitsHome.html';

    $scope.orderProjectBy = 'CreatedOn';
    $scope.limitProjectTo = 10;

    $scope.examName = examName;
    $scope.institution = institution;

    $scope.statistic;
    statsService.getStatistics()
                .then(function (data) {
                    $scope.statistic = data;
                    console.log(data);
                })
                .catch($log.error);

    $scope.latestProjects;
    statsService.getLatestAddedProjects()
                .then(function (data) {
                    $scope.latestProjects = data;
                    console.log(data);
                })
                .catch($log.error);

    $scope.latestCommits;
    statsService.getLatestCommits()
                .then(function (data) {
                    $scope.latestCommits = data;
                    console.log(data);
                })
                .catch($log.error);
}]);