using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCalculator.Models;

namespace OhmCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string bandA = "Yellow";
            string bandB = "Violet";
            string bandC = "Red";
            string bandD = "Gold";

            int expected = 4700;

            var calculator = new OhmValueCalculator();

            int actual = calculator.CalculateOhmValue(bandA, bandB, bandC, bandD);

            Assert.AreEqual(expected, actual, 0, "Ohm not calculated correctly");
        }
    }
}
