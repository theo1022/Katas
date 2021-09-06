using System;
using RobbersLanguageSim;
using Xunit;

namespace RobbersLanguageTest
{
    public class Tests
    {
        // TODO lägg till fler tester för att underlätta ditt kodande
        [Fact]
        public void ApaTest()
        {
            string result = RobbersLanguage.Encode("apa");

            Assert.Equal("apopa", result);
        }
    }
}
