using System;
using Xunit;

namespace LooyuSdk.Tests
{
    public class EncryptHelperTest 
    {

        private String blank = "将要加密的字符";
        private String key = "5dd69f95-a82a-4b01-b6c1-a2d2f8f8061b";
        private String expected = "neD0iV1eFLpIy4/F1XHFEomEfx2kV/EPMg+edO9TU/8=";
        [Fact]
        public void TestEncrypt()
        {
            String result = LooyuSdk.EncryptHelper.encode(blank, key);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestDecrypt()
        {
            String decrypted = LooyuSdk.EncryptHelper.decode(expected, key);
            Assert.Equal(blank, decrypted);
        }
    }
}
