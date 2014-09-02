(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;

        var service = {
            getCorrespondences: getCorrespondences,
            getCorrespondecesCount: getCorrespondecesCount
        };

        return service;



        function getCorrespondecesCount() { return $q.when(72); }

        function getCorrespondences() {
           
            var correspondences = [
                { id: 1, title: 'Approval For 123', relatedentity: 'Company X', responsible: 'Mohammad', assignedto: 'Omar', status:'Pending' },
                { id: 2, title: 'Approval For 456', relatedentity: 'Department Of Licensing', responsible: 'Mohammad', assignedto: '', status: 'Draft' },
                { id: 3, title: 'Approval For 554', relatedentity: 'Department Company X', responsible: 'Shaima', assignedto: 'Omar', status: 'Pending' },
                { id: 4, title: 'Inform For 123', relatedentity: 'Company X', responsible: 'Rami', assignedto: 'Omar', status: 'Closed' },
                { id: 5, title: 'Come heere For 123', relatedentity: 'Company D', responsible: 'Mohammad', assignedto: 'Mohammad', status: 'Pending' },
                { id: 6, title: 'Complaint From Client', relatedentity: 'Client ABC', responsible: 'Rami', assignedto: 'Shaima', status: 'Closed' },
                { id: 7, title: 'Approval For abc', relatedentity: 'Company Z', responsible: 'Rami', assignedto: 'Shaima', status: 'Pending' },
                { id: 8, title: 'Inform me about', relatedentity: 'Company Y', responsible: 'Shaima', assignedto: '', status: 'Closed' },
            ];
            return $q.when(correspondences);
        }
    }
})();