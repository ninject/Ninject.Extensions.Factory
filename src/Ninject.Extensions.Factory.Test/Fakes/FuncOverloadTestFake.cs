//-------------------------------------------------------------------------------
// <copyright file="FuncOverloadTestFake.cs" company="Ninject Project Contributors">
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

namespace Ninject.Extensions.Factory.Fakes
{
    using System;

    public class FuncOverloadTestFake
    {
        private readonly Func<FuncOverloadTestImplementationFake> factory0;

        private readonly Func<int, FuncOverloadTestImplementationFake> factory1;

        private readonly Func<int, int, FuncOverloadTestImplementationFake> factory2;

        private readonly Func<int, int, int, FuncOverloadTestImplementationFake> factory3;

        private readonly Func<int, int, int, int, FuncOverloadTestImplementationFake> factory4;

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        private readonly Func<int, int, int, int, int, FuncOverloadTestImplementationFake> factory5;

        private readonly Func<int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory6;

        private readonly Func<int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory7;

        private readonly Func<int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory8;

        private readonly Func<int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory9;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory10;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory11;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory12;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory13;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory14;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory15;

        private readonly Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory16;
#endif
        public FuncOverloadTestFake(
            Func<int, FuncOverloadTestImplementationFake> factory1,
            Func<int, int, FuncOverloadTestImplementationFake> factory2,
            Func<int, int, int, FuncOverloadTestImplementationFake> factory3,
            Func<int, int, int, int, FuncOverloadTestImplementationFake> factory4,
#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
            Func<int, int, int, int, int, FuncOverloadTestImplementationFake> factory5,
            Func<int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory6,
            Func<int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory7,
            Func<int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory8,
            Func<int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory9,
            Func<int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory10,
            Func<int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory11,
            Func<int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory12,
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory13,
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory14,
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory15,
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, FuncOverloadTestImplementationFake> factory16,
#endif
            Func<FuncOverloadTestImplementationFake> factory0)
        {
            this.factory0 = factory0;
            this.factory1 = factory1;
            this.factory2 = factory2;
            this.factory3 = factory3;
            this.factory4 = factory4;
#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
            this.factory5 = factory5;
            this.factory6 = factory6;
            this.factory7 = factory7;
            this.factory8 = factory8;
            this.factory9 = factory9;
            this.factory10 = factory10;
            this.factory11 = factory11;
            this.factory12 = factory12;
            this.factory13 = factory13;
            this.factory14 = factory14;
            this.factory15 = factory15;
            this.factory16 = factory16;
#endif
        }

        public FuncOverloadTestImplementationFake Create()
        {
            return this.factory0();
        }

        public FuncOverloadTestImplementationFake Create(int arg1)
        {
            return this.factory1(arg1);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2)
        {
            return this.factory2(arg1, arg2);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3)
        {
            return this.factory3(arg1, arg2, arg3);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4)
        {
            return this.factory4(arg1, arg2, arg3, arg4);
        }

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5)
        {
            return this.factory5(arg1, arg2, arg3, arg4, arg5);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
        {
            return this.factory6(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7)
        {
            return this.factory7(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8)
        {
            return this.factory8(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9)
        {
            return this.factory9(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10)
        {
            return this.factory10(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11)
        {
            return this.factory11(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12)
        {
            return this.factory12(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13)
        {
            return this.factory13(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14)
        {
            return this.factory14(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15)
        {
            return this.factory15(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public FuncOverloadTestImplementationFake Create(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15, int arg16)
        {
            return this.factory16(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }
#endif
    }
}