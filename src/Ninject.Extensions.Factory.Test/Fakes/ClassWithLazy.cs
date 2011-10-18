//-------------------------------------------------------------------------------
// <copyright file="ClassWithLazy.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
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

    public class ClassWithLazy
    {
        private readonly Lazy<IWeapon> lazyWeapon;

        public ClassWithLazy(Lazy<IWeapon> lazyWeapon)
        {
            this.lazyWeapon = lazyWeapon;
        }

        public IWeapon GetWeapon()
        {
            return this.lazyWeapon.Value;
        }
    }
}
#endif