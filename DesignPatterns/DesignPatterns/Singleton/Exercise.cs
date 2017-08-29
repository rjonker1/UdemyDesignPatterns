using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Singleton
{
    public class Exercise
    {
        public class SingletonTester
        {
            public static bool IsSingleton(Func<object> func)
            {
                var firstObject = func();
                var secondObject = func();
                return ReferenceEquals(firstObject, secondObject);
            }
        }

        public class SingletonTesterTests
        {
            [Fact]
            public void then_only_one_instance_is_singleton()
            {
                var obj = new object();
                Assert.True(SingletonTester.IsSingleton(() => obj));
                Assert.False(SingletonTester.IsSingleton(() => new object()));
            }
        }
    }
}
