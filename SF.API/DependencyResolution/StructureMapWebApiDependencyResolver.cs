// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructureMapWebApiDependencyResolver.cs" company="Web Advanced">
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

using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace SF.API.DependencyResolution
{
    /// <summary>
    /// The structure map dependency resolver.
    /// </summary>
    public class StructureMapWebApiDependencyResolver : StructureMapWebApiDependencyScope, IDependencyResolver, IHttpControllerActivator
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapWebApiDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public StructureMapWebApiDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
            container.Inject<IHttpControllerActivator>(this);
        }

        #endregion

        private readonly IContainer container;


        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The System.Web.Http.Dependencies.IDependencyScope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
              return new StructureMapWebApiDependencyResolver(container.GetNestedContainer());
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var scope = request.GetDependencyScope();
            return scope.GetService(controllerType) as IHttpController;
        }
    }
}