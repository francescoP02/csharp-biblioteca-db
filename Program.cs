// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;

List<User> registeredUser = new List<User>();
List<Document> documents = new List<Document>();
List<Loan> loans = new List<Loan>();

//some books

documents.Add(new Book("1234567", "Prova", 100, 2002, "fantasy", true, "12345", "Rowling"));
documents.Add(new Book("1234566", "Prova2", 200, 2003, "horro", true, "12344", "Rowling"));
documents.Add(new Book("1234565", "Prova3", 300, 2004, "fantasy", true, "12346", "Rowling"));

//some dvds

documents.Add(new Dvd("12345", 100, "dvd-prova", 2022, "pop", true, "12345A", "Bob"));
documents.Add(new Dvd("123456", 120, "dvd-prova2", 2022, "rock", true, "12345B", "Bob"));
documents.Add(new Dvd("123457", 150, "dvd-prova3", 2022, "jazz", true, "12345C", "Bob"));

//some users

registeredUser.Add(new User("Prova", "Rossi", "rossi@gmail.com", "12345a", "3331112233"));
registeredUser.Add(new User("Prova", "Gialli", "gialli@gmail.com", "12345b", "3332221133"));
registeredUser.Add(new User("Prova", "Verdi", "verdi@gmail.com", "12345c", "3333332211"));

bool success = false;
string choice;

Random rnd = new Random();

do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("'add' for add a document, 'loan' for loan a document");
    Console.WriteLine("'search' for search a loan, 'exit' for ending process");
    choice = Console.ReadLine();

    if (choice == "add")
    {
        InsertDocument();
    }
    else if (choice == "loan")
    {
        RequireLoan();
    }
    else if (choice == "search")
    {
        SearchLoan();
    }

} while (choice != "exit");

void InsertDocument()
{
    Console.WriteLine("Book or Dvd?");
    string response = Console.ReadLine();

    Console.WriteLine("Insert title:");
    string title = Console.ReadLine();

    Console.WriteLine("Insert author:");
    string author = Console.ReadLine();

    Console.WriteLine("Insert year:");
    int year = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Insert genre:");
    string genre = Console.ReadLine();

    string shelf = $"A{Convert.ToString(rnd.Next(1000))}";

    bool available = true;

    if (response == "Book")
    {
        Console.WriteLine("Insert page number:");
        int pages = Convert.ToInt32(Console.ReadLine());
        string isbn = Convert.ToString(rnd.Next(99999999));
        Book book = new Book(isbn, title, pages, year, genre, available, shelf, author);
        documents.Add(book);
    }

    else if (response == "Dvd")
    {
        Console.WriteLine("Insert duration:");
        int time = Convert.ToInt32(Console.ReadLine());
        string serialNumber = Convert.ToString(rnd.Next(99999999));
        Dvd dvd = new Dvd(serialNumber, time, title, year, genre, available, shelf, author);
        documents.Add(dvd);
    }
}

void RequireLoan()
{
    Console.Write("Insert name: ");
    string name = Console.ReadLine();

    Console.Write("Insert surname: ");
    string surname = Console.ReadLine();

    Console.Write("Insert email: ");
    string email = Console.ReadLine();

    Console.Write("Insert password: ");
    string password = Console.ReadLine();

    Console.Write("Insert phone number: ");
    string phone = Console.ReadLine();

    User newUser = new User(name, surname, email, password, phone);
    registeredUser.Add(newUser);

    Console.WriteLine("Which document you want to loan? (insert title)");

    string userInput = Console.ReadLine();

    foreach (Document documento in documents)
    {
        if (documento.Title == userInput)
        {
            if (documento.Available == true)
            {

                success = true;

                Loan newLoan = new Loan("20/09/2022", "21/09/2022", newUser, documento);

                loans.Add(newLoan);

                Console.WriteLine("Mr. " + newLoan.Utente.Surname + " have completed the loan request for the document: " + newLoan.Documento.Title);
            }
        }
    }

    if (success != true)
    {
        Console.WriteLine("No available");
    }
}

void SearchLoan()
{
    bool found = false;
    Console.WriteLine("Insert user's surname:");
    string userSurname = Console.ReadLine();

    foreach (Loan loan in loans)
    {
        if (loan.Utente.Surname == userSurname)
        {
            found = true;
            Console.WriteLine($"Loaned document: {loan.Documento.Title}");
        }
    }

    if (found == false)
    {
        Console.WriteLine("No loan founded");
    }

}

