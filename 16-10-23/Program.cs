using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
public class Bankaccount
{
    public string Number { get; }
    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    public string Gethistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNotes");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }



    private static int s_accountNumberSeed = 1234567890;
    private List<Transaction> _allTransactions = new List<Transaction>();

    public Bankaccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {


        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }


    private readonly decimal _minimumBalance;


    public Bankaccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }



    public virtual void PerformMonthEndTransactions() { }



    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    // public void MakeWithdrawal(decimal amount, DateTime date, string note)
    // {
    //     if (amount <= 0)
    //     {
    //         throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
    //     }
    //     if (Balance - amount < 0)
    //     {
    //         throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    //     }
    //     var withdrawal = new Transaction(-amount, date, note);
    //     _allTransactions.Add(withdrawal);
    // }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
    }
}





public class Transaction
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}














//Inhertiance

public class InterestEarningAccount : Bankaccount
{
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }
    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.Now, "apply monthly interest");
        }
    }
}

public class LineofCreditAccount : Bankaccount
{

    public LineofCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }


    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }

    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;
}

public class GiftCardAccount : Bankaccount
{
    private readonly decimal _monthlyDeposit = 0m;

    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;

    public override void PerformMonthEndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }
}




class Program
{
    static void Main()
    {
        var account = new Bankaccount("Sakl", 1505);

        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");



        account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
        Console.WriteLine(account.Balance);
        account.MakeDeposit(1001, DateTime.Now, "Friend paid me back");
        Console.WriteLine(account.Balance);


        // Test that the initial balances must be positive.
        // try
        // {
        //     var invalidAccount = new Bankaccount("invalid", -55);
        // }
        // catch (ArgumentOutOfRangeException e)
        // {
        //     Console.WriteLine("Exception caught creating account with negative balance");
        //     Console.WriteLine(e.ToString());
        //     return;
        // }


        Console.WriteLine(account.Gethistory());


        var giftCard = new GiftCardAccount("gift card", 100, 50);
        giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
        giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");

        giftCard.PerformMonthEndTransactions();

        giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");

        Console.WriteLine(giftCard.Gethistory());

        var saving = new InterestEarningAccount("saving account", 1000);
        saving.MakeDeposit(750, DateTime.Now, "save some money");
        saving.MakeDeposit(1250, DateTime.Now, "add more savings");
        saving.MakeWithdrawal(250, DateTime.Now, "needed to pay monthly bills");
        saving.PerformMonthEndTransactions();

        Console.WriteLine(saving.Gethistory());


        var lineofCredit = new LineofCreditAccount("line of credit", 0,2000);
        lineofCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
        lineofCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
        lineofCredit.MakeWithdrawal(5000m, DateTime.Now, "emergency funds for repairs");
        lineofCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
        lineofCredit.PerformMonthEndTransactions();
        Console.WriteLine(lineofCredit.Gethistory());
    }
}