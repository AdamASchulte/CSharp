using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{

    public class cardHolder
    {
        String cardNum;
        int pin;
        String fname;
        String lname;
        double balance;

        public cardHolder(String c, int p, String f, String l, double b)
        {
            cardNum = c;
            pin = p;
            fname = f;
            lname = l;
            balance = b;
        }

        public string CardNum()
        {
            return cardNum;
        }

        public int Pin()
        {
            return pin;
        }

        public String fName()
        {
            return fname;
        }
        
        public String lName()
        {
            return lname;
        }

        public double Balance()
        {
            return balance;
        }

        public void SetCardNum(String c)
        {
            cardNum = cardNum;
        }

        public void SetPin(int p)
        {
            pin = p;
        }

        public void SetfName(String f)
        {
            fname = f;
        }

        public void SetlName(String l)
        {
            lname = l;
        }

        public void SetBalance(double b)
        {
            balance = b;
        }

        static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to deposit?");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.SetBalance(deposit + currentUser.Balance());
                Console.WriteLine("Thank you, your current balance is" + currentUser.Balance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw?");
                double withdrawal = Double.Parse(Console.ReadLine());
                if(currentUser.Balance() < withdrawal)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    currentUser.SetBalance(currentUser.Balance() - withdrawal);
                    Console.WriteLine("You're good to go. Your new balance is: " + currentUser.Balance());
                }
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.Balance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("123456", 1010, "Adam", "Schulte", 3000.00));
            cardHolders.Add(new cardHolder("348437", 0101, "Aiden", "Mathews", 10.25));
            cardHolders.Add(new cardHolder("102479", 1001, "Conrad", "Hebert", 302.84));
            cardHolders.Add(new cardHolder("102744", 0010, "Aalok", "Zimmerman", 1023.56));

            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("Please enter your card number");
            String debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again"); }
                }
                catch { Console.WriteLine("Card not recognized. Please try again"); }
            }

            Console.WriteLine("Please enter your pin");
            int userPin = 0;
            while(true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if(currentUser.Pin() == userPin) { break; }
                    else { Console.WriteLine("Pin not Recognized. Please try again."); }
                }
                catch
                {
                    Console.WriteLine("Pin not recognized. Please try again");
                }
            }

            Console.WriteLine("Welcome " + currentUser.fName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if(option == 1) { deposit(currentUser); }
                else if(option == 2) { withdraw(currentUser); }
                else if(option == 3) { balance(currentUser); }
                else if(option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you. Have a nice day.");
        }     
    }
}
