using NUnit.Framework;
using System;

namespace CalculatorTests
{

    [TestFixture]
    public class CalculatorTests
    {
        private Ñalculator.Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Ñalculator.Calculator();
        }
        [Test]
        public void Spaces()
        {
            string str = "( 3 + 5 + 5) * 3";
            str = Ñalculator.Remover.RemoveSpaces(str);
            Assert.AreEqual(str, "(3+5+5)*3");
        }
        [Test]
        public void Addition()
        {
            Assert.AreEqual(calc.Calculate("3+4"), 7);
        }
        [Test]
        public void Subtraction()
        {
            Assert.AreEqual(calc.Calculate("3-7"), -4);
        }
        [Test]
        public void Multiplication()
        {
            Assert.AreEqual(calc.Calculate("3*7"), 21);
        }
        [Test]
        public void Division()
        {
            Assert.AreEqual(calc.Calculate("8/2"), 4);
        }
        [Test]
        public void CheckExeption1()
        {
            try
            {
                calc.Calculate("a - g + 7");
                Assert.Fail("An exception should have been thrown");
            }
            catch (FormatException fe)
            {
                Assert.AreEqual("One of the identified items was in an invalid format.", fe.Message);
            }

        }
        [Test]
        public void CheckExeption2()
        {
            try
            {
                calc.Calculate(")3 + 5(");
                Assert.Fail("An exception should have been thrown");
            }
            catch (InvalidOperationException fe)
            {
                Assert.AreEqual("Operation is not valid due to the current state of the object.", fe.Message);
            }
        }
        [Test]
        public void Bracket()
        {
            Assert.AreEqual(calc.Calculate("(((3 + 4)))"), 7);
        }
        [Test]
        public void TestString()
        {
            Assert.AreEqual(calc.Calculate("(2+3)*5/6+7+(8/2)") - ((2 + 3) * 5 / 6.0 + 7 + (8 / 2.0)), -6.3578287878840456E-07d);
        }
    }

}