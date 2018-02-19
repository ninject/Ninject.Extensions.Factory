//-------------------------------------------------------------------------------
// <copyright file="ClassWithGenericLazy.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2018 Ninject Project Contributors
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
namespace Ninject.Extensions.Factory.Fakes
{
    using System;

    public class ClassWithGenericLazy
    {
        private readonly Lazy<Lazy<IWeapon>> lazyWeapons;

        public ClassWithGenericLazy(Lazy<Lazy<IWeapon>> lazyWeapons)
        {
            this.lazyWeapons = lazyWeapons;
        }

        public IWeapon GetWeapon()
        {
            return this.lazyWeapons.Value.Value;
        }
    }
}
#endif