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