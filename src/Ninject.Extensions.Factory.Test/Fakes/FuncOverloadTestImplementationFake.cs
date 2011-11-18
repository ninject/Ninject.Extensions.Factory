//-------------------------------------------------------------------------------
// <copyright file="FuncOverloadTestImplementationFake.cs" company="Ninject Project Contributors">
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
    public class FuncOverloadTestImplementationFake
    {
        public FuncOverloadTestImplementationFake()
        {           
        }

        public FuncOverloadTestImplementationFake(int arg1)
        {
            this.Arg1 = arg1;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2)
            : this(arg1)
        {
            this.Arg2 = arg2;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3)
            : this(arg1, arg2)
        {
            this.Arg3 = arg3;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4)
            : this(arg1, arg2, arg3)
        {
            this.Arg4 = arg4;
        }

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5)
            : this(arg1, arg2, arg3, arg4)
        {
            this.Arg5 = arg5;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
            : this(arg1, arg2, arg3, arg4, arg5)
        {
            this.Arg6 = arg6;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7)
            : this(arg1, arg2, arg3, arg4, arg5, arg6)
        {
            this.Arg7 = arg7;
        }
        
        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        {
            this.Arg8 = arg8;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
        {
            this.Arg9 = arg9;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        {
            this.Arg10 = arg10;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10)
        {
            this.Arg11 = arg11;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)
        {
            this.Arg12 = arg12;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12)
        {
            this.Arg13 = arg13;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13)
        {
            this.Arg14 = arg14;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14)
        {
            this.Arg15 = arg15;
        }

        public FuncOverloadTestImplementationFake(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15, int arg16)
            : this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15)
        {
            this.Arg16 = arg16;
        }
#endif

        public int Arg1 { get; private set; }

        public int Arg2 { get; private set; }

        public int Arg3 { get; private set; }

        public int Arg4 { get; private set; }

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        public int Arg5 { get; private set; }

        public int Arg6 { get; private set; }

        public int Arg7 { get; private set; }

        public int Arg8 { get; private set; }

        public int Arg9 { get; private set; }

        public int Arg10 { get; private set; }

        public int Arg11 { get; private set; }

        public int Arg12 { get; private set; }

        public int Arg13 { get; private set; }

        public int Arg14 { get; private set; }

        public int Arg15 { get; private set; }

        public int Arg16 { get; private set; }
#endif
    }
}