'use strict';

/**
 * @ngdoc overview
 * @name todoView
 * @description
 * # todoView
 *
 * Main module of the application.
 */
angular
  .module('todoView', [
    'ngRoute',
  ])
  .config(function ($routeProvider) {
      $routeProvider
        .when('/', {
            templateUrl: 'views/todo.html',
            controller: 'todoCtrl',
            controllerAs: 'todo'
        })
        .when('/todo', {
            templateUrl: 'views/todo.html',
            controller: 'todoCtrl',
            controllerAs: 'todo'
        })
        .otherwise({
            redirectTo: '/'
        });
  });
