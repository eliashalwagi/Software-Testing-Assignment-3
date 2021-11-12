using System;
using System.Collections.Generic;

//Using style guide:
//commenting every event/function
//labelling variables properly
//refactoring code
namespace Assignment_3
{
   public class A3
    {
        public static double Avg(List<double> ArreyOfDoubles, bool isTrue)
        {
            //double for sum of numbers
            double numberSum = Sum(ArreyOfDoubles, isTrue);

            int count = 0;
            //loop for count
            for (int i = 0; i < ArreyOfDoubles.Count; i++)
            {
                if (isTrue || ArreyOfDoubles[i] >= 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return numberSum / count;
        }

        // Return of new method
        public static double Sum(List<double> listOfDoubles, bool isTrue)
        {
            return NewMethod(listOfDoubles, isTrue);
        }

        //this method is not implemented
        //makes sure the list is not empty
        private static double NewMethod(List<double> listOfDoubles, bool isTrue)
        {
            //throws an exception if the list is empty
            if (listOfDoubles.Count < 0)
            {
                throw new ArgumentException("list of doubles cannot be empty");
            }

            //makes sure that its not a 0
            double numberSum = 0.0;
            foreach (double val in listOfDoubles)
            {
                //if its false or zero
                if (isTrue || val >= 0)
                {

                    numberSum += val;
                }
            }
            //return of the sum of numbers
            return numberSum;
        }

        //method calculates the median 
        public static double Median(List<double> userInput)
        {
            //if the count is 0 throw an exception
            if (userInput.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            //method called to sort the user input
            userInput.Sort();

            //median calculation user input is devided by 2
            double median = userInput[userInput.Count / 2];

            //makes sure there is no remainder 
            if (userInput.Count % 2 == 0)
                median = (userInput[userInput.Count / 2] + userInput[userInput.Count / 2 - 1]) / 2;

            //return of median value
            return median;
        }

        //method calculates the standard deviation
        public static double StandardDeviation(List<double> userInput)
        {
            //if the count is less than 1 throw an exception
            if (userInput.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            //variable count number of user input
            int numberOfInput = userInput.Count;

            //initializes numberSum to 0
            double numberSum = 0;
            //Variable to get the average of user input and boolean to confirm
            double averageOfNumber = Avg(userInput, true);

            //for loop initialized at 0, until the user input length. increment by 1 
            //This for loop uses a temporary number where the user input for that increment
            //is stored. Then sums and appends the temporary number minus the average.
            for (int i = 0; i < numberOfInput; i++)
            {
                //temporary number variable initialized with the current user input of [i].
                double tempNumber = userInput[i];
                //Math.Pow method implemented to get the number sum.
                numberSum += Math.Pow(tempNumber - averageOfNumber, 2);
            }
            //standard deviation results variable initialized to square root of sumber sum 
            //divided by the number of inputs.
            double standardDeviationResults = Math.Sqrt(numberSum / (numberOfInput - 1));

            //return standard deviation
            return standardDeviationResults;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testData = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            //this outout calls the fuction Sum
            Console.WriteLine("The numberSum of the array = {0}", Sum(testData, true));

            //this outout calls the fuction Avg
            Console.WriteLine("The average of the array = {0}", Avg(testData, true));

            //this outout calls the fuction Median
            Console.WriteLine("The median value of the Double data set = {0}", Median(testData));

            //this outout calls the fuction Standard deviation
            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testData));
        }
    }
}
