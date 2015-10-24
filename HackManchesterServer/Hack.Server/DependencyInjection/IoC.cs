// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
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
using System.Linq;
using System.Web;
using Hack.EF;
using StructureMap;
using StructureMap.Graph;

namespace Hack.Server.DependencyInjection
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    var currentAssembles = AppDomain.CurrentDomain.GetAssemblies();
                    foreach (var assembly in currentAssembles.Where(assembly => assembly.FullName.Contains("DonorPath")))
                    {
                        scan.Assembly(assembly);
                    }
                });
                x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                //x.For<DonorPathDb>().Transient();
                x.For<HackDbContext>().Use(() => new HackDbContext());
                // this should share the dbcontext across all our services on a per request basis
            });

            return ObjectFactory.Container;
        }
    }
}