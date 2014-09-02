(function () {
    'use strict';


    var controllerId = 'correspondencesCtrl';
    angular.module('app').controller(controllerId, ['$routeParams', '$rootScope', '$scope', '$http', 'common', 'datacontext', correspondencesController]);



    function correspondencesController($routeParams, $rootScope, $scope, $http, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);


        var vm = this;
        var correspondences = vm.correspondences = []; //correspondenceStorage.get();
        vm.id = $routeParams.id;
        console.log('correspondence id: ' + vm.id);
        if (vm.id != null && vm.id != undefined) getCorrespondence();

        $scope.newCorrespondence = '';
        $scope.correspondence = null;
        vm.title = 'Correspondences';

        activate();

        function activate() {
            var promises = [getCorrespondencesCount(), getCorrespondences()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Correspondences View'); });
        }

        function getCorrespondencesCount() {
            vm.count = 62;
            //return datacontext.getCorrespondencesCount().then(function (data) {
            //    return vm.messageCount = data;
            //});
        }
        function getCorrespondence() {
            console.log("http://mobile.sca.ae/correspondence/" + vm.id);
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://mobile.sca.ae/correspondence/" + vm.id, // ?callback=?
                success: function (data) {
                    console.log("Rertrieved: " + data.length);
                    console.log();
                    //$rootScope.$apply(function () {
                    //    vm.correspondence = data;
                    //    log('called apply for correspondence id:' + id);
                    //});
                }
               , error: function (err) {
                   console.log('Error in GetCorrespondence:' + err);
               }
            });



        }
        function getCorrespondences() {
            var url = 'http://mobile.sca.ae/correspondence?callback=JSON_CALLBACK';

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://mobile.sca.ae/correspondence", // ?callback=?
                success: function (data) {
                    //   console.log("Rertrieved: " + data.length);
                    $rootScope.$apply(function () {
                        vm.correspondences = data;
                        log('called apply');
                    });
                }
               , error: function (err) {
                   console.log(err);
               }
            });



        }
    }


})();