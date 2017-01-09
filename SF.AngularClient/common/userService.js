(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("UserService", ["$http","$q", "appSettings", userService])

    function userService($http, $q, appSettings) {
        return {
            getUsers: function () {
                return $q(function (resolve, reject) {
                    $http.get(appSettings.SfApi + "/api/users/get")
                    .success(function (data) {
                        resolve(JSON.parse(data));
                    });
                });
            },
        }
    };

}());

