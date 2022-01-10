using BusinessLayer.Utils;
using NUnit.Framework;

namespace KImplementorTests.BusinessLayerTests
{
    public class HasherTest
    {
        [Test]
        public void SimpleHashStringTest()
        {
            var hasher = new Hasher();
            var sourceString = "abc";
            var hashedString = hasher.GetHashedStringSha3(sourceString);
            var expected = "b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0";
            Assert.AreEqual(expected, hashedString);
            hashedString = hasher.GetHashedStringSha3(sourceString);
            Assert.AreEqual(expected, hashedString);
            sourceString = "abcd";
            hashedString = hasher.GetHashedStringSha3(sourceString);
            Assert.AreNotEqual(expected, hashedString);
        }
    }
}
