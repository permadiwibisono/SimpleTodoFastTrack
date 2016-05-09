'use strict';
angular.module('todoView')
  .controller('BodyCtrl', function ($scope) {
      $scope.status = '';

  })
  .controller('todoCtrl', function ($scope, $http,$log) {
      
      var url = "http://localhost:40927/api/todoitem";

      //$http.get(url).success(function (data) {
      //    $scope.entities = data;
      //});
      $scope.load = function () {
          $http.get(url).success(function (data) {
              $scope.entities = data;
          });
      };
      $scope.addTodo = function () {
          $scope.$parent.status = 'Loading...';
          var todoJSON = {
              Id: '',
              Name: $scope.todoNew,
              IsCompleted: false,
          }
          $scope.todoNew = '';
          $http({
              method: 'post',
              url: url,
              data: todoJSON,
              headers: {
                  'Content-Type': 'application/json'
              }
          }).then(function successCallback(response) {
              $log.log(response.data);
              var todo={
                  Id: response.data.Id,
                  Name: response.data.Name,
                  IsCompleted: response.data.IsCompleted,
              };
              $scope.entities.push(todo);
              $scope.$parent.status = 'baru saja menambahkan todo baru';
                
              // this callback will be called asynchronously
              // when the response is available
          }, function errorCallback(response) {
              $scope.$parent.status = response.status + '-' + response.statusText;
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
      }

      $scope.deleteTodo = function (id)
      {
          $scope.$parent.status = 'Loading...';
          $http({
              method: 'delete',
              url: url + '/' + id,
          }).then(function successCallback(response) {
              $scope.$parent.status = 'baru saja menghapus todo';
              $scope.load();

              // this callback will be called asynchronously
              // when the response is available
          }, function errorCallback(response) {
              $scope.$parent.status = response.status + '-' + response.statusText;
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
      }

      $scope.completedTodo = function (todo) {
          $scope.$parent.status = 'Loading...';
          var todoJSON = {
              Name: todo.Name,
              IsCompleted: true
          };
          $http({
              method: 'put',
              url: url + '/' + todo.Id,
              data: todoJSON,
              headers: {
                  'Content-Type': 'application/json'
              }
          }).then(function successCallback(response) {
              $scope.$parent.status = 'satu todo telah selesai';
              $scope.load();

              // this callback will be called asynchronously
              // when the response is available
          }, function errorCallback(response) {
              $scope.$parent.status = response.status + '-' + response.statusText;
              $scope.load();
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
      };

      $scope.updateTodo = function (todo) {
          $scope.$parent.status = 'Loading...';
          var todoJSON = {
              Name: todo.Name,
              IsCompleted: todo.IsCompleted
          };
          $http({
              method: 'put',
              url: url + '/'+todo.Id,
              data: todoJSON,
              headers: {
                  'Content-Type': 'application/json'
              }
          }).then(function successCallback(response) {
              $scope.$parent.status = 'update todo telah berhasil';

              // this callback will be called asynchronously
              // when the response is available
          }, function errorCallback(response) {
              $scope.$parent.status = response.status+ '-'+response.statusText;
              $scope.load();
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
      };

  })