using AtmConsoleApp;
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine() ?? "");
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine($"Thank you for your money.\nYour new balance is: {currentUser.getBalance()}");
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine() ?? "");
            // check if the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine($"You are good to go! Thank you {currentUser.getFirstName()}");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.getBalance()}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();

        cardHolders.Add(new CardHolder("5399287189387283", 1234, "Ade", "Laide", 1200));
        cardHolders.Add(new CardHolder("5399287374881938", 3545, "John", "Doe", 3500));
        cardHolders.Add(new CardHolder("4120287189387283", 3030, "Ismail", "Kolade", 500));
        cardHolders.Add(new CardHolder("5399287129048283", 2244, "Bukola", "Adenuga", 600));
        cardHolders.Add(new CardHolder("4120287189383333", 3029, "Khadijat", "Bello", 4000));

        // Prompt user
        Console.WriteLine("Welcome to 247 ATM");
        Console.WriteLine("Please insert your ATM card");
        string debitCardNumber = "";
        int userPin = 0;
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNumber = Console.ReadLine() ?? "";
                // check against our db
                currentUser = cardHolders.First(a => a.getCardNum() == debitCardNumber);
                Console.WriteLine($"{currentUser.getFirstName()} {currentUser.getLastName()}");    
                if (currentUser != null) break;
                else Console.WriteLine("Card not recognized! Please try again.");
            }
            catch (Exception e) 
            { 
                Console.WriteLine("Card not recognized! Please try again.");
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine("Please enter your pin");
        while (true)
        {
            try
            {
                userPin = Convert.ToInt32(Console.ReadLine());
                if (currentUser.getPin() == userPin) break;
                else Console.WriteLine("Incorrect pin! Please try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect pin! Please try again.");
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine($"Welcome {currentUser.getFirstName()} :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1: 
                        deposit(currentUser); 
                        break;
                    case 2:
                        withdraw(currentUser);
                        break;
                    case 3:
                        balance(currentUser);
                        break;
                    case 4:
                        break;
                    default: 
                        option = 0;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
