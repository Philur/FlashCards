using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards
{
    public class FlashCardsController
    {
        // Added in Bonus

        // public string User;
        private string mUser;

        private double mNumber1;
        private double mNumber2;

        private int mCorrect;
        private int mTries;

        private string mWorkOn;

        public void GenerateNumbers()
        {
            Random randomNumber =
                new Random(DateTime.Now.Millisecond);

            this.mNumber1 = randomNumber.Next(0, 99);
            this.mNumber2 = randomNumber.Next(0, 99);
        }

        public string BuildEquation()
        {
            switch (this.WorkOn)
            {
                case "A":
                    return this.mNumber1.ToString() + "+" + this.mNumber2.ToString();
                case "S":
                    return this.mNumber1.ToString() + "-" + this.mNumber2.ToString();
                case "M":
                    return this.mNumber1.ToString() + "*" + this.mNumber2.ToString();
                default:
                    return this.mNumber1.ToString() + "/" + this.mNumber2.ToString();
            }
        }

        public bool CheckAnswer(double answer)
        {
            double correctAnswer;

            if (this.WorkOn == "A")
            {
                correctAnswer = this.mNumber1 + this.mNumber2;
            }
            else if (this.WorkOn == "S")
            {
                correctAnswer = this.mNumber1 - this.mNumber2;
            }
            else if (this.WorkOn == "M")
            {
                correctAnswer = this.mNumber1 * this.mNumber2;
            }
            else
            {
                correctAnswer = this.mNumber1 / this.mNumber2;
            }

            this.mTries += 1;

            if (correctAnswer == answer)
            {
                this.mCorrect += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Correct
        {
            get
            {
                return this.mCorrect;
            }
        }

        public int Tries
        {
            get
            {
                return this.mTries;
            }
        }

        public double PercentCorrect
        {
            get
            {
                return ((double)this.Correct / (double)this.Tries) * 100.0;
            }
        }

        public string WorkOn
        {
            get
            {
                return this.mWorkOn;
            }
            
            set
            {
                string input = value.ToUpper().Substring(0, 1);

                if (input == "A" || input == "S" || input == "M" || input == "D")
                    this.mWorkOn = input;
                else
                    throw new ArgumentException("Must enter Add, Subtract, Multiply or Divide");
            }
        }

        // Added in Bonus
        public string User
        {
            get
            {
                return this.mUser;
            }
            
            set
            {
                this.mUser = value;
            }
        }

        // Added for unit testing exercise
        public double Number1
        {
            get
            {
                return this.mNumber1;
            }

            set
            {
                this.mNumber1 = value;
            }
        }

        public double Number2
        {
            get
            {
                return this.mNumber2;
            }

            set
            {
                this.mNumber2 = value;
            }
        }
    }
}