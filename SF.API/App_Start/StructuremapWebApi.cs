// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapWebApi.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Http.Dispatcher;
using SF.API;
using SF.API.App_Start;
using SF.API.DependencyResolution;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(StructuremapWebApi), "Start")]

namespace SF.API {
    public static class StructuremapWebApi {
        public static void Start() {
			var container = StructuremapMvc.StructureMapDependencyScope.Container;

            var dependencyResolver = new StructureMapWebApiDependencyResolver(container);
            
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}