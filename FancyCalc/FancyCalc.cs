using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalc
{
    public class FancyCalcEnguine
    {

        public double Add(int a, int b)
        {
           return a + b;
        }


        public double Subtract(int a, int b)
        {
           
            return a - b;
        }


        public double Multiply(int a, int b)
        {
            return a * b;
        }

        public double Division(int a, int b)
        {
            return a / b;
        }

        //generic calc method. usage: "10 + 20"  => result 30
        public double Culculate(string expression)
        {


            if (expression == null)

            {
                throw new ArgumentNullException();
            }

            if (expression == "")

            {
                throw new ArgumentException();
            }
            try

            {

                char[] signs = { '-', '+', '*', '/' };


                int indexOfsign = expression.IndexOfAny(signs);

                if (indexOfsign == -1)
                {
                    throw new ArgumentException();
                }

                string[] numbers = expression.Split(signs);

                int number_one = Convert.ToInt32(numbers[0]);

                int number_two = Convert.ToInt32(numbers[1]);

                double result;

                switch (expression[indexOfsign])

                {
                    case '-':
                        {
                            try

                            {
                                result = Subtract(number_one, number_two);
                            }

                            catch (OverflowException)
                            {
                                throw new OverflowException();
                            }
                            return result;
                        }

                    case '+':
                        {

                            try { result = Add(number_one, number_two); }

                            catch (OverflowException)
                            {
                                throw new OverflowException();
                            }
                            return result;
                        }

                    case '*':

                        {
                            try { result = Multiply(number_one, number_two); }

                            catch (OverflowException)
                            {
                                throw new OverflowException();
                            }
                            return result;
                        }

                    case '/':
                        {
                            if (number_two == 0)
                            {
                                throw new DivideByZeroException();
                            }

                            try { result = Division(number_one, number_two); }

                            catch (OverflowException)
                            {
                                throw new OverflowException();
                            }
                            return result;
                        }
                    default: throw new NotImplementedException();
                }
            }
            catch (FormatException) { throw new FormatException(); }

            catch (IndexOutOfRangeException) { throw new IndexOutOfRangeException(); }
  
   
        }
    }
}
