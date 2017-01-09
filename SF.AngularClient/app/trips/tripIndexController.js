(function () {
    "use strict";
    angular
        .module("tripGallery")
        .controller("tripIndexController",
                     ["UserService", TripIndexController]);

    function TripIndexController(UserService) {
        var vm = this;
        UserService.getUsers().then(function (data) {
            vm.Users = data;
        });
    }
}());
