// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Data.SqlClient;


string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";
SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


    List<User> registeredUser = new List<User>();
    List<Document> documents = new List<Document>();
    List<Loan> loans = new List<Loan>();

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

        if (response == "Book")
        {

            try
            {
                connessioneSql.Open();

                string query = "INSERT INTO Books (Isbn, Title, Pages, Year, Genre, Available, Shelf, Author) VALUES (@dato1, @dato2, @dato3, @dato4, @dato5, @dato6, @dato7, @dato8)";

                SqlCommand cmd = new SqlCommand(query, connessioneSql);

                string userisbn = Convert.ToString(rnd.Next(99999999));
                cmd.Parameters.Add(new SqlParameter("@dato1", userisbn));

                Console.WriteLine("Insert title:");
                string usertitle = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato2", usertitle));

                Console.WriteLine("Insert page number:");
                int userpages = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add(new SqlParameter("@dato3", userpages));

                Console.WriteLine("Insert year:");
                int useryear = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add(new SqlParameter("@dato4", useryear));

                Console.WriteLine("Insert genre:");
                string usergenre = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato5", usergenre));

                int useravailable = 1;
                cmd.Parameters.Add(new SqlParameter("@dato6", useravailable));

                string usershelf = $"A{Convert.ToString(rnd.Next(1000))}";
                cmd.Parameters.Add(new SqlParameter("@dato7", usershelf));

                Console.WriteLine("Insert author:");
                string userauthor = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato8", userauthor));

                int affectedRows = cmd.ExecuteNonQuery();

                //Book book = new Book(userisbn, usertitle, userpages, useryear, usergenre, useravailable, usershelf, userauthor);
                //documents.Add(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connessioneSql.Close();
            }
        }

        else if (response == "Dvd")
        {
            try
            {
                connessioneSql.Open();

                string query = "INSERT INTO DVDs (SerialNumber, Time, Title, Year, Genre, Available, Shelf, Author) VALUES (@dato1, @dato2, @dato3, @dato4, @dato5, @dato6, @dato7, @dato8)";

                SqlCommand cmd = new SqlCommand(query, connessioneSql);

                string userserialNumber = Convert.ToString(rnd.Next(99999999));
                cmd.Parameters.Add(new SqlParameter("@dato1", userserialNumber));

                Console.WriteLine("Insert duration:");
                int usertime = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add(new SqlParameter("@dato2", usertime));

                Console.WriteLine("Insert title:");
                string usertitle = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato3", usertitle));

                Console.WriteLine("Insert year:");
                int useryear = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add(new SqlParameter("@dato4", useryear));

                Console.WriteLine("Insert genre:");
                string usergenre = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato5", usergenre));

                int useravailable = 1;
                cmd.Parameters.Add(new SqlParameter("@dato6", useravailable));

                string usershelf = $"A{Convert.ToString(rnd.Next(1000))}";
                cmd.Parameters.Add(new SqlParameter("@dato7", usershelf));

                Console.WriteLine("Insert author:");
                string userauthor = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato8", userauthor));

                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connessioneSql.Close();
            }
        }
    }

    void RequireLoan()
    {

        Console.WriteLine("Do you have an account? (y/n)");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case ("y"):

            break;
        case("n"):
            try
            {
                connessioneSql.Open();

                string query = "INSERT INTO Users (Name, Surname, Email, Password, Phone) VALUES (@dato1, @dato2, @dato3, @dato4, @dato5)";

                SqlCommand cmd = new SqlCommand(query, connessioneSql);
                Console.Write("Insert name: ");
                string username = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato1", username));

                Console.Write("Insert surname: ");
                string usersurname = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato2", usersurname));

                Console.Write("Insert email: ");
                string useremail = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato3", useremail));

                Console.Write("Insert password: ");
                string userpassword = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato4", userpassword));

                Console.Write("Insert phone number: ");
                string userphone = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@dato5", userphone));

                int affectedRows = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connessioneSql.Close();
                }
            break;
    }
        

        Console.WriteLine("Which document you want to loan? (insert title)");

        string userInput = Console.ReadLine();

        foreach (Document documento in documents)
        {
            if (documento.Title == userInput)
            {
                if (documento.Available == 1)
                {

                    success = true;

                    //Loan newLoan = new Loan("20/09/2022", "21/09/2022", newUser, documento);

                    //loans.Add(newLoan);

                    //Console.WriteLine("Mr. " + newLoan.Utente.Surname + " have completed the loan request for the document: " + newLoan.Documento.Title);
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


