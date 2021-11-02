using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0.00;
            Customer customer = new Customer();
            int result = customer.CustomerRegister();
            customer.CustomerLogin(result);
            customer.Menu(balance);
          //  int balance = customer.CheckBalance();
          


        }


    }

    class Customer
    {
        public string name { get; set; }
        public string password { get; set; }



        public int CustomerRegister()
        {
            Console.Write("Please input your full name  you used in registration: ");
            name = Console.ReadLine();
            Console.WriteLine("Your name is " + name);
            Console.Write("Please input your password: ");
            password = Console.ReadLine();
            int result = 0;
            if (Int32.TryParse(password, out result))
            {
                Console.WriteLine("You can login now");
            }
            else
            {
                Console.WriteLine("Your password has to be a number!");
            }
            return result;
        }


        public void CustomerLogin(int result)
        {
            Console.Write("Please input your password: ");
            var newPassword = Console.ReadLine();
            int check = 0;
            if (Int32.TryParse(newPassword, out check))
            {
                if (check == result)
                {
                    Console.WriteLine("Password confirmed ");
                    Console.WriteLine("Login Successful!!!!!!!! ");
                }

                else
                {
                    Console.WriteLine("Incorrect Password");
                    CustomerLogin(result);
                }
            }
            else
            {
                Console.WriteLine("Your password has to be a number!");
            }
        }

        public void Menu(double balance)
        {
            Console.Write("Press \n 1. Balance \n 2. Deposit \n 3. Withdrawal \n");
            var choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                CheckBalance(balance);
            }
            else if (choice == 2)
            {
                Deposit(balance);
            }
            else if (choice == 3)
            {
                Withdrawal(balance);
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
        }

        public void Deposit(double balance)
        {
            Console.WriteLine("Please input the amount you want to deposit");

            var amountDeposited = Convert.ToDouble(Console.ReadLine());

            balance += amountDeposited;

            Console.WriteLine("Your deposit is " + balance);
            Menu(balance);
        }


        public void CheckBalance(double balance)
        {
            Console.WriteLine("Your balance is " + balance);
            Menu(balance);

        }


        public void Withdrawal(double balance)
        {
            Console.WriteLine("Please input the amount you want to withdraw");

            var amountToWithdraw = Convert.ToDouble(Console.ReadLine());

            if (amountToWithdraw > balance)
            {
                Console.WriteLine("Insufficient Balance");
                Menu(balance);

            }
            else
            {
                balance -= amountToWithdraw;

                Console.WriteLine("Your balance is " + balance);
            }

            
        }


    }

}  
