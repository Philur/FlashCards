using FlashCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FlashCardsTests
{
    
    
    [TestClass()]
    public class FlashCardsControllerTest
    {

        [TestMethod()]
        public void WorkOnTest()
        {
            FlashCardsController target = 
                new FlashCardsController();
            
            target.WorkOn = "add";
            Assert.AreEqual(target.WorkOn, "A");

            target.WorkOn = "sub";
            Assert.AreEqual(target.WorkOn, "S");

            target.WorkOn = "M";
            Assert.AreEqual(target.WorkOn, "M");

            target.WorkOn = "d";
            Assert.AreEqual(target.WorkOn, "D");
        }

        [TestMethod(), 
        ExpectedException(typeof(System.ArgumentException))]
        public void WorkOnExceptionTest()
        {
            FlashCardsController target = new FlashCardsController();

            // An ArgumentException should be thrown here.  
            // Because of the ExpectedException attribute 
            // above the test will pass.
            target.WorkOn = "Joe";

            // We shouldn't ever get this far.  
            // If we do the test should fail.
            Assert.Fail();          
        }

        [TestMethod()]
        public void UserTest()
        {
            FlashCardsController target = new FlashCardsController(); 
            string expected = "Joe"; 
            string actual;
            target.User = expected;
            actual = target.User;
            Assert.AreEqual(expected, actual);    
        }

        [TestMethod()]
        public void TriesTest()
        {
            FlashCardsController target = new FlashCardsController();

            Assert.IsTrue(target.Tries == 0);
            target.Number1 = 1.0;
            target.Number2 = 2.0;
            target.WorkOn = "A";
            target.CheckAnswer(3.0);
            Assert.IsTrue(target.Tries == 1);
        }

        [TestMethod()]
        public void PercentCorrectTest()
        {
            FlashCardsController target = new FlashCardsController();
            target.Number1 = 1.0;
            target.Number2 = 2.0;
            target.WorkOn = "A";

            // This one should be right
            target.CheckAnswer(3.0);

            target.Number1 = 3.0;
            target.Number2 = 4.0;
            target.WorkOn = "A";

            // This one should be wrong
            target.CheckAnswer(3.0);

            // Percent should be 50
            Assert.IsTrue(target.PercentCorrect == 50);
        }

        [TestMethod()]
        public void Number2Test()
        {
            FlashCardsController target = new FlashCardsController(); 
            double expected = 12.0; 
            double actual;
            target.Number2 = expected;
            actual = target.Number2;
            Assert.AreEqual(expected, actual);    
        }

        [TestMethod()]
        public void Number1Test()
        {
            FlashCardsController target = new FlashCardsController(); 
            double expected = 10.0; 
            double actual;
            target.Number1 = expected;
            actual = target.Number1;
            Assert.AreEqual(expected, actual);          
        }

        [TestMethod()]
        public void CorrectTest()
        {
            FlashCardsController target = new FlashCardsController();
            Assert.IsTrue(target.Correct == 0);
            target.Number1 = 1.0;
            target.Number2 = 2.0;
            target.WorkOn = "A";

            // This one should be right
            target.CheckAnswer(3.0);

            target.Number1 = 3.0;
            target.Number2 = 4.0;
            target.WorkOn = "A";

            // This one should be wrong
            target.CheckAnswer(3.0);

            // Correct should be 1
            Assert.IsTrue(target.Correct == 1);
        }

        [TestMethod()]
        public void GenerateNumbersTest()
        {
            FlashCardsController target = 
                new FlashCardsController(); 
        
            // If it works 1000 times we'll assume its working correctly
            for (int i = 0; i < 1000; i++)
            {
                target.GenerateNumbers();
                Assert.IsTrue(target.Number1 >= 0.0 
                    && target.Number1 <= 99.0);
                Assert.IsTrue(target.Number2 >= 0.0 
                    && target.Number2 <= 99.0);
            } 
        }

        [TestMethod()]
        public void CheckAnswerTest()
        {
            FlashCardsController target = new FlashCardsController();

            // initialize the test with known values
            target.Number1 = 10.0;
            target.Number2 = 5.0;
            
            target.WorkOn = "A";
            Assert.IsTrue(target.CheckAnswer(15.0));

            target.WorkOn = "S";
            Assert.IsTrue(target.CheckAnswer(5.0));

            target.WorkOn = "M";
            Assert.IsTrue(target.CheckAnswer(50.0));

            target.WorkOn = "D";
            Assert.IsTrue(target.CheckAnswer(2.0));
        }

        [TestMethod()]
        public void BuildEquationTest()
        {
            FlashCardsController target = new FlashCardsController();
            target.Number1 = 10.0;
            target.Number2 = 5.0;

            target.WorkOn = "A";
            Assert.AreEqual(target.BuildEquation(), "10+5");

            target.WorkOn = "S";
            Assert.AreEqual(target.BuildEquation(), "10-5");

            target.WorkOn = "M";
            Assert.AreEqual(target.BuildEquation(), "10*5");

            target.WorkOn = "D";
            Assert.AreEqual(target.BuildEquation(), "10/5");
        }
        
        [TestMethod()]
        public void BuildEquationTest2()
        {
            FlashCardsController target = new FlashCardsController(); 
            target.Number1 = 100.0;
            target.Number2 = 50.0;
           
            target.WorkOn = "A";
            Assert.AreEqual(target.BuildEquation(),  "100+50");

            target.WorkOn = "S";
            Assert.AreEqual(target.BuildEquation(), "100-50");

            target.WorkOn = "M";
            Assert.AreEqual(target.BuildEquation(), "100*50");

            target.WorkOn = "D";
            Assert.AreEqual(target.BuildEquation(), "100/50");
        }

        [TestMethod()]
        public void BuildEquationTest3()
        {
            FlashCardsController target = new FlashCardsController();
            target.Number1 = 100.0;
            target.Number2 = 50.0;

            target.WorkOn = "A";
            Assert.AreEqual(target.BuildEquation(), "100+50");

            target.WorkOn = "S";
            Assert.AreEqual(target.BuildEquation(), "100-50");

            target.WorkOn = "M";
            Assert.AreEqual(target.BuildEquation(), "100*50");

            target.WorkOn = "D";
            Assert.AreEqual(target.BuildEquation(), "100/50");
        }

        [TestMethod()]
        public void FlashCardsControllerConstructorTest()
        {
            FlashCardsController target = new FlashCardsController();
            Assert.IsNotNull(target);
        }
    }
}
