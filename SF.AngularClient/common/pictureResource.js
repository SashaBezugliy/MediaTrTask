(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("pictureResource",
                ["$resource",
                 "appSettings",
                    PictureResource])

    function PictureResource($resource, appSettings)
    {

        //resource(url, paramDefaults, actions)

        return $resource(appSettings.SfApi  + "/api/trips/:tripId/pictures/:pictureId", null,
            {
               
            });
    }
}());

