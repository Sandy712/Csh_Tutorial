using System.Dynamic;
using System.Net.Http.Headers;

public class Book{
    public string Title{get; set;}
    public string Author{get; set;}
    public int Year{get; set;}

    public Book(string title,string author,int year){
        Title=title;
        Author=author;
        Year=year;
    }

    public void DisplayBookInfo()
    {
        Console.WriteLine($"Title of Book:{Title}\nAuthor of Book:{Author}\nYear of Book:{Year}");
    }
}

public class LibraryMember
{
    public string MemberName{get;set;}
    public int MemberID{get;set;}
    private List<Book> CheckoutBooks{get;set;}

    public LibraryMember(string membername,int memberid)
    {
        MemberName=membername;
        MemberID=memberid;
        CheckoutBooks=new List<Book>();
    }

    public void CheckoutBook(Book book)
    {
        CheckoutBooks.Add(book);
        Console.WriteLine($"{MemberName} check out the book:{book.Title}\n");
    }

    public void DisplayCheckoutBooks()
    {
        Console.WriteLine($"Books checkout by {MemberName} (ID:{MemberID})");
        foreach(var book in CheckoutBooks)
        {
            book.DisplayBookInfo();
        }
    }
}

public class LibraryTranscation
{
    public static void PerformTranscation(LibraryMember member,Book book)
    {
        Console.WriteLine($"Library Transcation:");
        Console.WriteLine($"Performing transcation for {member.MemberName} (ID:{member.MemberID})");

        member.CheckoutBook(book);
        member.DisplayCheckoutBooks();
    
    }
}

class Program
{
    static void Main()
    {
        Book book1=new Book("The main in ove","Sandeep Martin",2045);

        LibraryMember member1=new LibraryMember("Rohit",101);
        
        LibraryTranscation.PerformTranscation(member1,book1);

        
    }
}