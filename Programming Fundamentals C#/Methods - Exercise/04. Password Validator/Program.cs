using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPassLenghtValid = BetweenSixAndTen(password);
            bool isPassOnlyLettersAndDigits = OnlyLettersAndDigits(password);
            bool isPassAtLeastTwoDigits = AtLeastTwoDigits(password);

            if (!isPassLenghtValid)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }

            if (!isPassOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isPassAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");	
            }

            if (isPassAtLeastTwoDigits && isPassLenghtValid && isPassOnlyLettersAndDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

       
        private static bool BetweenSixAndTen(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
                
        }

        private static bool OnlyLettersAndDigits(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool AtLeastTwoDigits(string password)
        {
            int sum = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    sum++;
                }
            }
            return sum >= 2;
        }
    }
}
