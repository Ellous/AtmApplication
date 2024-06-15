namespace AtmApplication
{
    class AtmApplication
    {

        class Account
        {
            public string AccountId="";
            public string AccountHolder="";
            public decimal Balance;
            public decimal AnnualInterestRate;
            public decimal withdrawAmount;
            public decimal depositAmount;

            public void deposit(decimal amount)
            {
                depositAmount = amount;
                Balance += depositAmount;
                Console.WriteLine($"New Balance: {Balance}");
            }
            public void withdraw(decimal amount)
            {
                withdrawAmount = amount;
                Balance -= withdrawAmount;
                Console.WriteLine($"New Balance: {Balance}");
            }
            public string getAccountHoldetname (string userAccountNumber)
            {
                if (AccountId== userAccountNumber)
                {
                    return AccountHolder;
                }
                // account not found
                return "";
            }
            public string getAccountNumber(string userAccountNumber)
            {
                if (AccountId == userAccountNumber)
                {
                   
                    return AccountId;
                }
                // account not found
                return "";
            }
            public decimal getAnnualInterestRate(string userAccountNumber)
            {
                if (AccountId == userAccountNumber)
                {
                    return AnnualInterestRate;
                }
                // account not found
                return 0;
            }
            public decimal getBalance(string userAccountNumber)
            {
                if (AccountId == userAccountNumber)
                {
                    return Balance;
                }
                // account not found
                return 0;
            }
        }//end of Account class

        private static List<Account> account = new List<Account>();

        /**
         * Main Function
         */
        private static void Main()
        {
            Bank.execute();
        }

       
        
        class Bank
        {
            /**
        * execute method
       
        */
            public static void execute()
            {


                Console.WriteLine("========Welcome to the ATM Application========");
                Console.WriteLine("Choose the following options by the number associated with the option");
                Console.WriteLine("\t1. Create  Account ");
                Console.WriteLine("\t2. Sellect  Account");
                Console.WriteLine("\t3. Exit");
                Console.Write("Option> ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        OpenAccount(account);
                        break;
                    case "2":
                        AccountController(account);
                        break;
                    case "3":
                        Console.Write("Do you want to exit? [y/n] ");
                        var yes_no = Console.ReadLine();
                        if (yes_no == "y")
                        {
                            Console.WriteLine("Thank you for using the application, now shutting down the system, all data has been erased. Goodbye.");
                            break;
                        }
                        else if (yes_no == "n")
                        {
                            //Console.Clear();
                            execute();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                            //Console.Clear();
                            execute();
                            break;
                        }

                        // break;
                }
            }
            //OpenAccount funtion with paramter account for List of  bank's Accounts
            private static void OpenAccount(List<Account> account)
            {
                Console.WriteLine("========Welcome to Create Account Menu======== ");
                var random = new Random();
                Console.Write("Enter Account Holder Name: ");
                var accountHolderName = Console.ReadLine();



                // var accountId = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12)
                // var accountId = new string(Enumerable.Repeat("1000", 4)
                // .Select(s => s[random.Next(s.Length)]).ToArray());
                Console.Write("Enter Account Number(Must be between 100 and 1000):");
                var accountId = Console.ReadLine();
               

                Console.Write("Enter Annual Interest Rate(Not less than 0 and must be less than 3.0 %): ");
                decimal annualInterestRate = 0;
                try
                {
                     annualInterestRate = decimal.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input for Annual Interest Rate");
                    Console.Write("Enter Annual Interest Rate(Not less than 0 and must be less than 3.0 %): ");
                    annualInterestRate = decimal.Parse(Console.ReadLine());
                   
                }
                // determine whether user-specified valid annualInterestRate
                if (annualInterestRate <= 0 )
                {
                    Console.WriteLine("Invalid input for Annual Interest Rate");
                    Console.Write("Enter Annual Interest Rate(Not less than 0 and must be less than 3.0 %): ");
                    annualInterestRate = decimal.Parse(Console.ReadLine());
                }
                if (annualInterestRate >= 3)
                {
                    Console.WriteLine("Invalid input for Annual Interest Rate");
                    Console.Write("Enter Annual Interest Rate(Not less than 0 and must be less than 3.0 %): ");
                    annualInterestRate = decimal.Parse(Console.ReadLine());
                }

                Console.Write("Enter Initial balance:");
               
                decimal balance = 0;
                try
                {
                    balance = decimal.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input for Initial Balance");
                    Console.Write("Enter Initial balance: ");
                    balance = decimal.Parse(Console.ReadLine());

                }



                // account.Add(new Account() { AccountId = accountId, AccountHolder = accountHolderName, Balance = 5000.0m });

                // determine whether user-specified digit number as account
                if (int.TryParse(accountId, out var check_userinput))
                {
                    // determine whether user-specified account number in the range of 100 to 1000
                    if (check_userinput >= 100 && check_userinput <= 1000)
                    {
                        //Add detail to the account list
                        account.Add(new Account() { AccountId = accountId, AccountHolder = accountHolderName, Balance = balance, AnnualInterestRate = annualInterestRate });
                        //Console.WriteLine("Account Created. Details:");
                        //Console.WriteLine($"\tAccountId: {accountId}");

                        Console.WriteLine($"\tAccount Number {accountId} created");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        // Clear The Console And Call Main Again.
                        // Console.Clear();

                        Main();//go back to main menu
                    }//just addedd
                    else {
                        Console.WriteLine("Invalid input, account number must be between 100 and 1000");
                        Main();//go back to main menu
                    }
                       
                }
                else
                {
                    Console.WriteLine("Invalid account number input ");
                    Main();//go back to main menu
                }//just addedd
            }
            //AccountController method in Bank class for transaction operation(Like withdrawing and depositing)
            //It for getting account information like checking balance and displaying trnsaction history
            private static void AccountController(List<Account> account)
            {
                var systemShutdown = false;
                while (!systemShutdown)
                {
                    Console.Write("Enter  Account Number(Must be between 100 and 1000): ");
                    var input = Console.ReadLine();

                    // loop through accounts searching for matching account number
                    foreach (var maccount in account)
                    {
                        if (input != null && input.Equals(maccount.AccountId))
                        {

                            
                            //Console.WriteLine($"Welcome {maccount.AccountHolder}. Your Current Balance: {maccount.Balance}. Your Annual Interest Rate: {maccount.AnnualInterestRate}");
                            Console.WriteLine($"Welcome {maccount.getAccountHoldetname(maccount.AccountId)}. Your Current Balance: {maccount.getBalance(maccount.AccountId)}. Your Annual Interest Rate: {maccount.getAnnualInterestRate(maccount.AccountId)}");
                            var atmModeShouldClose = false;
                            while (!atmModeShouldClose)
                            {
                                Console.WriteLine("Choose the following Options;");
                                Console.WriteLine("\t1. Check Balance");
                                Console.WriteLine("\t2. Deposit");
                                Console.WriteLine("\t3. Withdraw ");
                                Console.WriteLine("\t4. Display Transaction");
                                Console.WriteLine("\t5. Exit Account");
                                Console.Write("Enter Operation> ");
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                       // Console.Clear();
                                     //   Console.WriteLine($"Balance: {maccount.Balance}");
                                        Console.WriteLine($"Balance: {maccount.getBalance(maccount.AccountId)}");
                                        
                                        break;
                                    case "2":
                                        Console.Write("Enter Amount> ");
                                        input = Console.ReadLine();
                                      //  Console.Clear();
                                        Console.WriteLine($"Depositing {input} To Account...");
                                        //validate decimal number input for deposit Amount
                                        if (decimal.TryParse(input, out var deposit))
                                        {
                                           // deposite money 
                                            maccount.deposit(deposit);
                                           // maccount.depositAmount = deposit;
                                            //maccount.Balance += deposit;
                                            //Console.WriteLine($"New Balance: {maccount.Balance}");
                                            break;
                                        }
                                        //if wrong value is inputed display error
                                      //  Console.Clear();
                                        Console.WriteLine("Error: Please Specify Amount For Deposit...");
                                        break;
                                    case "3":
                                        Console.Write("Enter Amount> ");
                                        input = Console.ReadLine();
                                        //validate decimal number input for withdraw Amount
                                        if (decimal.TryParse(input, out var withdraw)) 
                                        {
                                            //check if balance is sufficient
                                            if (withdraw <= maccount.Balance) 
                                            {
                                               // Console.Clear();
                                                Console.WriteLine($"Withdrawing {input} From Account...");

                                                //Withdraw money
                                                // maccount.withdrawAmount = withdraw;
                                                //  maccount.Balance -= withdraw;
                                                //  Console.WriteLine($"New Balance: {maccount.Balance}");
                                                maccount.withdraw(withdraw);
                                                
                                                break;
                                            }

                                           // Console.Clear();
                                            Console.WriteLine("Error: insufficient funds.");
                                            break;
                                        }
                                        //if wrong value is inputed display error
                                        //Console.Clear();
                                        Console.WriteLine("Error: Please Specify Amount For Withdraw...");
                                        break;
                                    /* case "4":
                                         Console.Clear();
                                         Console.WriteLine("Logging out...");
                                         atmModeShouldClose = true;
                                         break;*/

                                    case "4":
                                        Console.WriteLine("======Transaction=====");
                                        Console.WriteLine($"Account Number: {maccount.AccountId}");
                                        Console.WriteLine($"Account Holder: {maccount.AccountHolder}");
                                        Console.WriteLine($"Anual Interest: {maccount.AnnualInterestRate}");
                                        Console.WriteLine($"New Balance: {maccount.Balance}");
                                        Console.WriteLine($"Deposit: {maccount.depositAmount}");
                                        Console.WriteLine($"Withdrawal: {maccount.withdrawAmount}");

                                        break;

                                    case "5":
                                        // atmModeShouldClose = true;
                                        //systemShutdown = true;
                                        // Console.WriteLine("All Data Has Been Erased. Goodbye.");
                                        //break;
                                        
                                        Console.Write("Do you want to exit? [y/n] ");
                                        var yes_no = Console.ReadLine();
                                        if (yes_no == "y")
                                        {

                                            atmModeShouldClose = true;
                                            systemShutdown = true;
                                            Console.WriteLine("Thank you for using the application, now shutting down the system, all data has been erased. Goodbye.");
                                            break;
                                        }
                                        else if (yes_no == "n")
                                        {
                                            //Console.Clear();
                                            Main();//go back to main menu
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input.");
                                            //Console.Clear();
                                            Main();//go back to main menu
                                            break;
                                        }
                                        


                                }
                            }
                        }
                    }
                }
            }//end account controller
        }//end bank class 
    }//end AtmApplication class 
}//end of namespace AtmApplication
