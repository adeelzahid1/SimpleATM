Main();

void Main()
{
    void printOptions()
    {
        Console.WriteLine("Please Choose One Option from the following Options . ");
        Console.WriteLine("1 DEPOSITE");
        Console.WriteLine("2 WITHDRAW");
        Console.WriteLine("3 SHOWBALANCE");
        Console.WriteLine("4 EXIT");
    }

    void deposite(CardHolder currentUser)
    {
        Console.WriteLine("How Much Money Would you like to ADD ?");
        double deposite = 0;
        do
        {
            deposite = Double.Parse(Console.ReadLine());
            if (deposite < 0)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("EE ki chawal Marrri ee , Must be a postive value");
                Console.WriteLine("Please Enter a postive value .. ");
                Console.WriteLine("-----------------------");
            }
        } while (deposite < 0);

        currentUser.setBalance(currentUser.getBalance() + deposite);

        Console.WriteLine($"Thank You for Adding Money, Your new Balance is ${currentUser.getBalance()}");

    }

    void withDraw(CardHolder currentUser)
    {
        Console.WriteLine("How much Money would you like to withdraw ?");
        double withdraw = Double.Parse(Console.ReadLine());
        if (currentUser.getBalance() < withdraw)
        {
            Console.WriteLine("Insufficient Balnace");
        }
        else
        {
            currentUser.setBalance(currentUser.getBalance() - withdraw);
            Console.WriteLine("You're good to go ! Thank You :)");
        }
    }

    void balance(CardHolder currentUser)
    {
        Console.WriteLine($"Current Balnace is : ${currentUser.getBalance()}");
    }

    List<CardHolder> cardHolders = new List<CardHolder>();
    cardHolders.Add(new CardHolder("1100", 0000, "Adeel", "Zahid", 250));
    cardHolders.Add(new CardHolder("1101", 0001, "Naveed", "Akber", 1000));
    cardHolders.Add(new CardHolder("1101", 0002, "Haseeb", "Ahmed", 350));
    cardHolders.Add(new CardHolder("1103", 0003, "Mudssar", "Hussain", 150));
    cardHolders.Add(new CardHolder("1104", 0004, "Mohsin", "Nazir", 50));


    // Welcome
    Console.WriteLine("Welcome to SIMPLE ATM");
    Console.WriteLine("pLEASE Insert Your Atm Card Number");
    String debitCardNumber = "";
    CardHolder currentUser;

    while (true)
    {
        try
        {
            debitCardNumber = Console.ReadLine();
            currentUser = cardHolders.FirstOrDefault(a => a.getCardNumber() == debitCardNumber);
            if (currentUser is not null)
            {
                break;
            }
            else
            {
                Console.WriteLine("Card Not Recognized ... Please Try Again");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Card Not Recognized ... Please Try Again");
            throw;
        }
    }

    int userPin = 0;
    Console.WriteLine("Please Enter Your Pin : ");
    while (true)
    {
        try
        {
            userPin = int.Parse(Console.ReadLine());
            currentUser = cardHolders.FirstOrDefault(x => x.getPin() == userPin);
            if (currentUser is not null)
            {
                break;
            }
            else
            {
                Console.WriteLine("INCORRECT PIN , PLEASE TRY AGAIN");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("INCORRECT PIN , PLEASE TRY AGAIN");
            throw;
        }
    }

    Console.WriteLine($"Welcome {currentUser.GetFirstName()}");
    int option = 0;

    do
    {
        printOptions();
        try
        {
            option = int.Parse(Console.ReadLine());
        }
        catch (Exception x)
        {

        }
        if (option == 1)
        {
            deposite(currentUser);
        }
        else if (option == 2)
        {
            withDraw(currentUser);
        }
        else if (option == 3)
        {
            balance(currentUser);
        }
        else if (option == 4)
        {
            break;
        }
        else
        {
            option = 0;
        }
    }
    while (option != 4);



}

public class CardHolder
{
    string cardNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;


    public CardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //getters
    public string getCardNumber() { return cardNumber; }

    public int getPin() { return pin; }

    public string GetFirstName() { return firstName; }

    public string getLastName() { return lastName; }

    public double getBalance() { return balance; }

    //setters
    public void setNum(string newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFristName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }
}