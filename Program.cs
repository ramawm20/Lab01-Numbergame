namespace Numbergame
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Welcome to my Game! Let's do some math!");
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine("sorry, You did something wrong");
                Console.WriteLine("error " + ex.Message);
            }
            finally {
                Console.WriteLine("Done, the program completed successfully");

            }
        }

        public static void StartSequence()

        {
            try
            {
                Console.WriteLine("Please enter a number greater than 0 :");
                int number = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[number];

                //get results from the methods
                int[] populateArray = Populate(array);

                int sum = GetSum(populateArray);

                int product = GetProduct(populateArray, sum);

                decimal quotient = GetQuotient(product);

                //print results
                Console.WriteLine($"Your array is size: {number}");

                Console.Write("The numbers in the array are: ");
                foreach (int i in populateArray)
                {
                    Console.Write($"{i},");
                }
                Console.WriteLine();

                Console.WriteLine($"The sum of the array is: {sum}");


                Console.WriteLine($"{sum} * {product / sum} = {product} ");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format Please enter a number");
                Console.WriteLine("Error : " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("You have entered a big number please enter smaller one");
                Console.WriteLine("Error :" + ex.Message);
            }


        }

        public static int[] Populate (int[] array ){
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine ($"Please enter a random number {i+1}/{length}");
                string userInput=Console.ReadLine ();
                int number =Convert.ToInt32(userInput);
                array[i] = number;

            }
            return array;
            }

        public static int GetSum(int[] array)
        {
            int sum = 0;
            foreach (int number in array)
            {
                sum += number;
            }
            if (sum < 20)
            {
                throw new CustomException($"Value of {sum} is too low");
            }
            return sum; 
        }

        public static int GetProduct (int [] array,int sum)
        {
            int product = 0;
            try
            {
                Console.WriteLine($"Please write a number between 1 and {array.Length}");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num < 0 || num >= array.Length)
                {
                    throw new IndexOutOfRangeException("Invalid index selected.");
                }
                 product = sum * array[num-1];

            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }



            return product;
        }

        public static decimal GetQuotient( int product){

            decimal quotient = 0;

            try
            {
                Console.WriteLine($"Please enter number to divide your product {product} by ");
                int num = Convert.ToInt32(Console.ReadLine());

                if(num == 0)
                {
                    throw new DivideByZeroException("The Dividened can't be zero");
                }

                quotient=decimal.Divide(product, num);
                
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                quotient = 0;
            }
        
            return quotient;
            }
    }
    
}