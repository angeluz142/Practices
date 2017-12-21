var app=angular.module('taskApp', []);

app.controller('taskCtrl', function($scope){

  $scope.task = taskData;

  $scope.editando = {};

  $scope.editar = function(){
    angular.copy($scope.task, $scope.editando);
  };

  $scope.guardar = function(){
      angular.copy( $scope.editando, $scope.task);
       $modalInstance.dismiss('guardar');
  };

  $scope.cancelar = function(){
    $scope.editando = {};
  };

});


var taskData = {
  nombre:"Tarea #1",
  fecha:"27/06/2017",
  descripcion:"bla bla bla bla bla blab lab"
}
