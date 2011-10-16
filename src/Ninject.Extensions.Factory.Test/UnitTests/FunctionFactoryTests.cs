//-------------------------------------------------------------------------------
// <copyright file="FunctionFactoryTests.cs" company="Ninject Project Contributors">
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

#if !NO_MOQ
namespace Ninject.Extensions.Factory.UnitTests
{
    using FluentAssertions;
    using Moq;
    using Ninject.Syntax;
    using Xunit;
    using Xunit.Extensions;

    public class FunctionFactoryTests
    {
        private readonly FunctionFactory testee;

        public FunctionFactoryTests()
        {
            this.testee = new FunctionFactory();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(17)]
#endif
        public void GetMethodInfo(int argumentCount)
        {
            var mi = this.testee.GetMethodInfo(argumentCount);

            mi.GetGenericArguments().Length.Should().Be(argumentCount);
        }

        [Fact]
        public void Create0()
        {
            const int ExpectedResult = 1; 
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<int>(resolutionRootMock.Object)();

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters(new object[0]);
        }

        [Fact]
        public void Create1()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, int>(resolutionRootMock.Object)(20);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20);
        }

        [Fact]
        public void Create2()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, int>(resolutionRootMock.Object)(20, "w");

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w");
        }

        [Fact]
        public void Create3()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, int>(resolutionRootMock.Object)(20, "w", 4);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4);
        }

        [Fact]
        public void Create4()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, int>(resolutionRootMock.Object)(20, "w", 4, 8);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8);
        }

#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
        [Fact]
        public void Create5()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10);
        }

        [Fact]
        public void Create6()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12);
        }

        [Fact]
        public void Create7()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c');

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c');
        }

        [Fact]
        public void Create8()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6);
        }

        [Fact]
        public void Create9()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14);
        }

        [Fact]
        public void Create10()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re");

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re");
        }

        [Fact]
        public void Create11()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o');

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o');
        }
    
        [Fact]
        public void Create12()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, ulong, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o', 16);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o', (ulong)16);
        }
    
        [Fact]
        public void Create13()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, ulong, byte, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o', 16, 18);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o', (ulong)16, (byte)18);
        }

        [Fact]
        public void Create14()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, ulong, byte, sbyte, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o', 16, 18, 22);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o', (ulong)16, (byte)18, (sbyte)22);
        }

        [Fact]
        public void Create15()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, ulong, byte, sbyte, uint, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o', 16, 18, 22, 24);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o', (ulong)16, (byte)18, (sbyte)22, (uint)24);
        }

        [Fact]
        public void Create16()
        {
            const int ExpectedResult = 1;
            var resolutionRootMock = new Mock<IResolutionRoot>();
            resolutionRootMock.SetupGet(ExpectedResult);

            var result = this.testee.Create<ulong, string, byte, ushort, long, uint, char, sbyte, short, string, char, ulong, byte, sbyte, uint, long, int>(resolutionRootMock.Object)(20, "w", 4, 8, 10, 12, 'c', -6, 14, "re", 'o', 16, 18, 22, 24, 26);

            result.Should().Be(ExpectedResult);
            resolutionRootMock.VerifyParameters((ulong)20, "w", (byte)4, (ushort)8, (long)10, (uint)12, 'c', (sbyte)-6, (short)14, "re", 'o', (ulong)16, (byte)18, (sbyte)22, (uint)24, (long)26);
        }
#endif
    }
}
#endif