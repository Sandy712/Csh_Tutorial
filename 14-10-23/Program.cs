using System.Dynamic;
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
        var report= new System.Text.StringBuilder();

        decimal balance=0;
        report.AppendLine("Date\t\tAmount\tBalance\tNotes");
        foreach(var item in _allTransactions)
        {
            balance+=item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }



    private static int s_accountNumberSeed = 1234567890;
    private List<Transaction> _allTransactions = new List<Transaction>();

    public Bankaccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
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

    }
}


