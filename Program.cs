//============================================================
// Student Number : S10223760, S10222843
// Student Name : Tay Yuyun Gladys, Yeo Sze Yun Gwyneth
// Module Group : T10
//============================================================
using System;
using System.IO;
using System.Collections.Generic;

namespace PRG2_T10_Team4
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Movie> movieList = new List<Movie>();
            List<Cinema> cinemaList = new List<Cinema>();
            List<Screening> screeningList = new List<Screening>();
            List<Ticket> tList = new List<Ticket>();
            List<Order> orderList = new List<Order>();
            
            
            int oNo = 0;
            int turn = 1;

            while (turn > 0)
            {
                MainMenu();

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1") //load movie and cinema data
                {
                    if (cinemaList.Count != 0)
                    {
                        Console.WriteLine("Data has already been loaded. Please do not load again");
                        continue;
                    }
                    LoadMovies(movieList);
                    LoadCinema(cinemaList);
                    Console.WriteLine("\nMovie and Cinema Data have been successfully loaded");                  
                }

                else if (option == "2") //load screening data 
                {
                    if (cinemaList.Count == 0)
                    {
                        Console.WriteLine("Please load the cinema and movie data first");
                        continue;
                    }

                    if (screeningList.Count != 0)
                    {
                        Console.WriteLine("Data has already been loaded. Please do not load again");
                        continue;
                    }
                    LoadScreening(screeningList, cinemaList, movieList);
                    Console.WriteLine("\nScreening Data have been successfully loaded");
                }


                else if (option == "3") //list all movies
                {
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the movie and cinema data first");
                        continue;
                    }

                    ListMovie(movieList);
                }

                else if (option == "4") //list movie screenings
                {
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the movie and cinema data first");
                        continue;
                    }
                    if (screeningList.Count == 0)
                    {
                        Console.WriteLine("Please load the screening data first");
                        continue;
                    }
                    Console.WriteLine();
                    ListMovie(movieList);
                    Console.WriteLine();

                    int moviechosen = 0;
                    while (true) //format validation for choosing movie option
                    {
                        try
                        {
                            Console.Write("Choose a movie: ");
                            moviechosen = Convert.ToInt32(Console.ReadLine());
                            while (moviechosen > 10 || moviechosen < 1)
                            {
                                Console.Write("Choose a option from 1 to 10: "); //number validation for choosing movie option
                                moviechosen = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please input a number from 1 to 10.");
                        }
                    }

                    Console.WriteLine();
                    ListScreening(screeningList, moviechosen, movieList);
                    //alternative way: replace the above line with 
                    //ListScreening(moviechosen, movieList);
                }

                else if (option == "5") //add movie screening session
                {
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the movie and cinema data first");
                        continue;
                    }
                    if (screeningList.Count == 0)
                    {
                        Console.WriteLine("Please load the screening data first");
                    }
                    Console.WriteLine();
                    ListMovie(movieList); //list all movies

                    int moviechosen = 0;
                    while (true) //format validation for choosing movie option 
                    {
                        try
                        {
                            Console.Write("Choose a movie: "); 
                            moviechosen = Convert.ToInt32(Console.ReadLine());
                            while (moviechosen > 10 || moviechosen < 1)
                            {
                                Console.Write("Choose a option from 1 to 10: "); //number range validation for choosing option of movie
                                moviechosen = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please input a number from 1 to 10.");
                        }
                    }
                    Movie m = movieList[moviechosen - 1];
                    Console.Write("Enter a screening Type [2D/3D]: ");
                    string sType = Console.ReadLine().ToUpper();
                    while (sType != "2D" && sType != "3D") //validation for the screeningtype
                    {
                        Console.Write("Enter a screening Type [2D/3D]: ");
                        sType = Console.ReadLine().ToLower();
                    }
                    DateTime newscreendatetime = DateTime.Now; 
                    while (true) //validation for datetime (see if datetime is valid)
                    {
                        try
                        {
                            Console.Write("Enter a screening date and time (dd/mm/yyyy hh:mm): ");
                            newscreendatetime = Convert.ToDateTime(Console.ReadLine());
                            while(newscreendatetime<=DateTime.Now) //screening datetime cannot be before today's date
                            {
                                Console.Write("Enter a screening date and time after {0} (dd/mm/yyyy hh:mm): ",DateTime.Now);
                                newscreendatetime = Convert.ToDateTime(Console.ReadLine());
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a correct date time.");
                        }
                    }
                    for (int j = 0; j < movieList.Count; j++) //check if the opening date time of the movie is before the new screening date time
                    {
                        if (movieList[j].Title == m.Title)
                        {
                            int value = DateTime.Compare(newscreendatetime, movieList[j].OpeningDate);
                            while (DateTime.Compare(newscreendatetime.Date, movieList[j].OpeningDate) < 0) 
                            {
                                Console.Write("Enter a screening date and time on or after the opening date (dd/mm/yyyy hh:mm): ");
                                newscreendatetime = Convert.ToDateTime(Console.ReadLine());
                            }
                            break;

                        }
                    }

                    ListCinema(cinemaList); //list cinemas

                    int checkcinema = 0;
                    while (true) //validation for cinema option
                    {
                        try
                        {
                            Console.Write("Select a cinema (option): ");
                            checkcinema = Convert.ToInt32(Console.ReadLine());
                            while (checkcinema > 15 || checkcinema < 1)
                            {
                                Console.Write("Choose a option from 1 to 15: ");
                                checkcinema = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please input a number from 1 to 15.");
                        }
                    }
                    Cinema c = cinemaList[checkcinema - 1]; //find the cinema from the cinema list
                    bool check = false;

                    for (int k = 0; k < cinemaList.Count; k++)
                    {

                        if (c.Name == cinemaList[k].Name && c.HallNo == cinemaList[k].HallNo) //find the cinema name and hall from cinema list that is the same as the input 
                        {
                            for (int y = 0; y < screeningList.Count; y++)
                            {
                                if (newscreendatetime.Date == screeningList[y].ScreeningDateTime.Date && screeningList[y].Cinema.Name == c.Name && screeningList[y].Cinema.HallNo == c.HallNo) 
                                { //check whether at that screening date time user chose, got any screenings happening anot at that cinema, have to check all the screenings

                                    DateTime endtime = screeningList[y].ScreeningDateTime.AddMinutes(screeningList[y].Movie.Duration + 30);

                                    if (newscreendatetime.AddMinutes(m.Duration + 30) <= screeningList[y].ScreeningDateTime || newscreendatetime >= endtime) 
                                    //check whether the input screening datetime will overlap the next screening anot and check whether the new screening input will be during any ongoing screenings at that cinema
                                    {
                                        check = true;
                                        break;
                                    }
                                    else
                                    {
                                        check = false;
                                        break; //if got overlap then break out of the loop to bring user to main menu
                                    }

                                }
                                else
                                {

                                    check = true;
                                }
                            }
                            break;
                        }
                        else
                        {

                            check = true;
                        }
                    }
                    if (check == true)
                    {
                        int sno = screeningList[screeningList.Count - 1].ScreeningNo + 1;
                        Screening s = new Screening(sno, newscreendatetime, sType, c, m);
                        s.SeatsRemaining = s.Cinema.Capacity;
                        Console.WriteLine("Creation of movie session was successful");
                        screeningList.Add(s); //add the new screening to the list 
                        m.AddScreening(s);
                    }
                    else
                    {
                        Console.WriteLine("Creation of movie session was unsuccessful, please try again.");
                    }
                }

                else if (option == "6") //delete a movie screening session
                {
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the movie and cinema data first");
                    }
                    if (screeningList.Count == 0)
                    {
                        Console.WriteLine("Please load the screening data first");
                        continue;
                    }
                    for (int i = 0; i < screeningList.Count; i++)
                    {
                        if (screeningList[i].SeatsRemaining == screeningList[i].Cinema.Capacity) //list all the screenings that have not sold any seats yet 
                        {
                            if (i == 0)
                            {
                                Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}", "Screening No", "Screening Date Time", "Screening Type", "Cinema", "Hall Number", "Seats Remaining");
                            }
                            Screening s = screeningList[i];
                            Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20} ",
                            s.ScreeningNo, s.ScreeningDateTime, s.ScreeningType, s.Cinema.Name, s.Cinema.HallNo, s.SeatsRemaining);
                        }
                    }
                    int sNo = 0;
                    Screening remove = null;
                    Movie removesmovie = null;
                    while (true) //validation for the session option 
                    {
                        try
                        {
                            Console.Write("Enter a session to remove: ");
                            sNo = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < screeningList.Count; j++)
                            {
                                if (sNo != screeningList[j].ScreeningNo) 
                                {
                                    continue;
                                }
                                else
                                {
                                    remove = screeningList[j]; 
                                    removesmovie = screeningList[j].Movie; 
                                    break;
                                }

                            }
                            if (remove != null)
                            {

                                if (remove.Cinema.Capacity == remove.SeatsRemaining) //check whether the option they enter the capacity is equal to seats remaining
                                {
                                    screeningList.Remove(remove); //remove screening from screening list
                                    removesmovie.screeningList.Remove(remove); 
                                    Console.WriteLine("Screening was removed successfully");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please choose a screening number from the above options");
                                    continue;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Please choose a screening number from the above options");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a screening number from the above options.");
                        }
                    }
                }

                else if (option == "7") //order movie tickets
                {
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the cinema and movie data first");
                        continue;
                    }
                    if (screeningList.Count == 0)
                    {
                        Console.WriteLine("Please load the screening data first");
                        continue;
                    }
                    oNo++;
                    ListMovie(movieList);

                    int selectM = 0;
                    while (true) //validation for choosing movie
                    {
                        try
                        {
                            Console.Write("Choose a movie: ");
                            selectM = Convert.ToInt32(Console.ReadLine());
                            while (selectM > 10 || selectM < 1)
                            {
                                Console.Write("Choose a option from 1 to 10: ");
                                selectM = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please input a number from 1 to 10.");
                        }
                    }

                    Movie m = SearchMovie(movieList, selectM); //search for the movie they chosen in the movie list 

                    while (ListScreening(screeningList, selectM, movieList) == 0) //check if there are any screenings for the movie chosen 
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Please select another movie: ");
                                selectM = Convert.ToInt32(Console.ReadLine());
                                while (selectM > 10 || selectM < 1)
                                {
                                    Console.Write("Choose a option from 1 to 10: ");
                                    selectM = Convert.ToInt32(Console.ReadLine());
                                }
                                m = SearchMovie(movieList, selectM);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please input a number from 1 to 10.");
                            }
                        }

                    }
                    //alternative way
                    /*
                     while (ListScreening(selectM, movieList) == 0) //check if there are any screenings for the movie chosen 
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Please select another movie: ");
                                selectM = Convert.ToInt32(Console.ReadLine());
                                while (selectM > 10 || selectM < 1)
                                {
                                    Console.Write("Choose a option from 1 to 10: ");
                                    selectM = Convert.ToInt32(Console.ReadLine());
                                }
                                m = SearchMovie(movieList, selectM);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please input a number from 1 to 10.");
                            }
                        }

                    }
                     */

                    Screening screen = null;

                    while (true) //validation for the screening 
                    {
                        try
                        {
                            Console.Write("Choose the screening: ");

                            int screenNo = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < screeningList.Count; i++) //check if the screening chosen is in the screening list 
                            {

                                if (screenNo != screeningList[i].ScreeningNo)
                                {
                                    continue;
                                }
                                else
                                {
                                    screen = screeningList[i];
                                    break;
                                }

                            }
                            if (screen != null)
                            {
                                if (screen.Movie.Title == m.Title) //check whether the screening option chosen is part of the screening options displayed 
                                {
                                    if (screen.ScreeningDateTime < DateTime.Now) //check whether the screening chosen is after today's date and time 
                                    {
                                        Console.WriteLine("Please choose a screening after {0}", DateTime.Now);
                                        continue;
                                    }
                                    else if (screen.SeatsRemaining == 0) //check whether there is space left 
                                    {
                                        Console.WriteLine("Please select another screening as screening number {0} has reached its maximum capacity", screen.ScreeningNo);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Please enter a screening number within the range.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a screening number within the range.");
                                continue;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please choose a screening number from the above options.");
                        }
                    }

                    //alternative way 
                    /*
                    while (true) //validation for the screening 
                    {
                        try
                        {
                            Console.Write("Choose the screening: ");

                            int screenNo = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < m.screeningList.Count; i++) //check if the screening chosen is in the screening list 
                            {

                                if (screenNo != m.screeningList[i].ScreeningNo) //here already check for whether the screening number is inside the movie they chosen 
                                {
                                    continue;
                                }
                                else
                                {
                                    screen = m.screeningList[i];
                                    break;
                                }

                            }
                            if (screen != null)
                            {
                                if (screen.ScreeningDateTime < DateTime.Now) //check whether the screening chosen is after today's date and time 
                                {
                                    Console.WriteLine("Please choose a screening after {0}", DateTime.Now);
                                    continue;
                                }
                                else if (screen.SeatsRemaining == 0) //check whether there is space left 
                                {
                                    Console.WriteLine("Please select another screening as screening number {0} has reached its maximum capacity", screen.ScreeningNo);
                                }
                                else
                                {
                                    break;
                                }                                                           
                            }
                            else
                            {
                                Console.WriteLine("Please enter a screening number within the range.");
                                continue;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please choose a screening number from the above options.");
                        }
                    }
                     */

                    int noTickets = 0;
                    while (true) //validation for tickets 
                    {
                        try
                        {
                            Console.Write("Enter the total number of tickets to order: ");
                            noTickets = Convert.ToInt32(Console.ReadLine());
                            while (noTickets <= 0)
                            {
                                Console.WriteLine("Please key in a value greater than 0");
                                Console.Write("Enter the total number of tickets to order: ");
                                noTickets = Convert.ToInt32(Console.ReadLine());
                            }

                            while (noTickets > screen.SeatsRemaining) //check whether the number of tickets input has exceeded the seats remaining
                            {
                                Console.WriteLine("The number of tickets chosen has exceeded the capacity of the cinema hall");
                                Console.Write("Number of tickets ordered should be less than {0}. Enter the total number of tickets to order: ", screen.SeatsRemaining);
                                noTickets = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }

                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number.");
                        }
                    }

                    string valid;
                    string classification = screen.Movie.Classification;
                    string title = screen.Movie.Title;
                    if (classification == "G")
                    {
                        valid = "Y";
                    }
                    else
                    {
                        if (classification == "PG13")
                        {
                            Console.Write("Are all ticket holders above the age of 13?[Y]/[N]: ");

                        }
                        else if (classification == "NC16")
                        {
                            Console.Write("Are all ticket holders above the age of 16?[Y]/[N]: ");

                        }
                        else if (classification == "M18")
                        {
                            Console.Write("Are all ticket holders above the age of 18?[Y]/[N]: ");

                        }
                        else if (classification == "R21")
                        {
                            Console.Write("Are all ticket holders above the age of 21?[Y]/[N]: ");

                        }

                        valid = Console.ReadLine().ToUpper();
                        while (valid != "N" && valid != "Y")
                        {
                            Console.WriteLine("You have keyed in the wrong input");
                            Console.Write("Does all ticket holders meet the requirements of the {0} movie? :", classification);
                            valid = Console.ReadLine().ToUpper();
                        }
                        if (valid == "N")
                        {
                            Console.WriteLine("\nYou are not able to watch {0} as you do not meet the age requirements", title);
                            oNo--;
                            continue;

                        }
                        else if (valid == "Y")
                        {
                            Console.WriteLine("You can watch {0}", title);
                        }
                    }

                    Order o = new Order(oNo, DateTime.Now);
                    o.Status = "Unpaid";
                    
                    for (int i = 0; i < noTickets; i++)
                    {
                        Console.WriteLine("\nSelect the type of ticket to be purchased");
                        Console.WriteLine("[1] Student");
                        Console.WriteLine("[2] Senior Citizen");
                        Console.WriteLine("[3] Adult");
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            List<string> study = new List<string> { "Primary", "Secondary", "Tertiary" };
                            Console.Write("\nEnter your level of study (Primary/Secondary/Tertiary): ");
                            string level = Console.ReadLine();
                            if (level.Length == 0)
                            {
                                Console.WriteLine("Please key in an value");
                            }
                            else
                            {
                                level = char.ToUpper(level[0]) + level.ToLower().Substring(1);
                            }

                            bool contains = study.Contains(level);
                            if (contains == true)
                            {
                                Student s = new Student(screen, level);
                                o.ticketList.Add(s);
                                o.Amount += s.CalculatePrice();
                                screen.SeatsRemaining--;
                                tList.Add(s);
                                m.TicketSold++;
                            }
                            else
                            {
                                i--;
                                Console.WriteLine("Invalid level of study");
                            }
                        }

                        else if (choice == "2")
                        {
                            int yBirth = 0;
                            while (true)
                            {
                                try
                                {
                                    Console.Write("\nEnter your year of birth: ");
                                    yBirth = Convert.ToInt32(Console.ReadLine());

                                    int currentYear = DateTime.Now.Year;

                                    if (currentYear - yBirth >= 55)
                                    {
                                        SeniorCitizen senior = new SeniorCitizen(screen, yBirth);
                                        o.ticketList.Add(senior);
                                        o.Amount += senior.CalculatePrice();
                                        screen.SeatsRemaining--;
                                        tList.Add(senior);
                                        m.TicketSold++;
                                    }
                                    else
                                    {
                                        i--;
                                        Console.WriteLine("You are not eligible for senior citizen ticket. Please choose another ticket");
                                    }
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter a year");
                                }
                            }
                        }

                        else if (choice == "3")
                        {
                            Console.Write("\nDo you want to get popcorn for $3? [Y]/[N]: ");
                            string get = Console.ReadLine().ToUpper();

                            while (get != "Y" && get != "N")
                            {
                                Console.WriteLine("Your choice is invalid");
                                Console.Write("\nDo you want to get popcorn for $3? [Y]/[N]: ");
                                get = Console.ReadLine().ToUpper();
                            }

                            if (get == "Y")
                            {
                                Adult ad = new Adult(screen, true);
                                o.ticketList.Add(ad);
                                o.Amount += ad.CalculatePrice() + 3.00;
                                screen.SeatsRemaining--;
                                tList.Add(ad);
                                m.TicketSold++;
                            }
                            else if (get == "N")
                            {
                                Adult ad = new Adult(screen, false);
                                o.ticketList.Add(ad);
                                o.Amount += ad.CalculatePrice();
                                screen.SeatsRemaining--;
                                tList.Add(ad);
                                m.TicketSold++;
                            }
                        }
                        else
                        {
                            i--;
                            continue;
                        }

                    }

                    Console.WriteLine("\nThe total amount is ${0:0.00} for {1} tickets", o.Amount, noTickets);
                    Console.Write("Press any key to make payment: ");
                    string key = Console.ReadLine();
                    Console.WriteLine("\nYour order number is {0}", oNo);
                    o.Status = "Paid";
                    orderList.Add(o);
                }

                else if (option == "8") //cancel order of ticket 
                {
                    if (orderList.Count == 0)
                    {
                        Console.WriteLine("There is no orders to cancel");
                        continue;
                    }
                    while (true) //validation for order number 
                    {
                        try
                        {
                            Console.Write("Enter order number: ");
                            int orderNo = Convert.ToInt32(Console.ReadLine());
                            Order or = SearchOrder(orderList, orderNo);
                            bool check = true;
                            if (or == null)
                            {
                                Console.WriteLine("Order number is not valid");
                                break;
                            }
                            else
                            {
                                foreach (Ticket t in or.ticketList)
                                {
                                    if (t.Screening.ScreeningDateTime <= DateTime.Now) //check if for their order, has the movie been screened
                                    {
                                        check = false;

                                        break;
                                    }
                                }
                                if (check == true)
                                {
                                    foreach (Ticket t in or.ticketList)
                                    {
                                        t.Screening.SeatsRemaining++;
                                    }
                                    Console.WriteLine("Your order has been cancelled");
                                    Console.WriteLine("${0:0.00} has been refunded", or.Amount);
                                    or.Status = "Cancelled";
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You will not be able to cancel your order as the movie has been screened");
                                    break;
                                }

                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid order number");
                        }
                    }
                }
                else if (option == "9") //recommend movie based on sales of tickets sold
                {
                    if (orderList.Count == 0)
                    {
                        Console.WriteLine("There is no orders in the list to be given for recommendation");
                        continue;
                    }
                    Console.WriteLine("\nHere are the top 3 recommendation based on the ticket sale of the movie: ");
                    Console.WriteLine("{0,-24}  {1,-20}", "Movie", "Total Sales");

                    List<double> sales = new List<double>();
                    List<string> newMovieList = new List<string>();

                    for (int i = 0; i < movieList.Count; i++)
                    {
                        newMovieList.Add(movieList[i].Title);
                    }
                    string[] newMovie = newMovieList.ToArray();

                    double amt = 0;
                    for (int j = 0; j < newMovieList.Count; j++)
                    {
                        for (int k = 0; k < orderList.Count; k++)
                        {
                            if (orderList[k].Status == "Paid")
                            {
                                string title = orderList[k].ticketList[0].Screening.Movie.Title;
                                if (title == newMovieList[j])
                                {
                                    amt += orderList[k].Amount;
                                }
                            }
                        }
                        sales.Add(amt);
                        amt = 0;
                    }
                    
                    int temp = 0;
                    double comparesale = 0;
                    List<string> sortedMovieList = new List<string>();
                    List<double> sortedmSalesList = new List<double>();
                    // compare the sales for each movie and append it to the list with the most sales being appended first 
                    
                    for (int n = 0; n < newMovieList.Count; n++)
                    {
                        for (int m = 0; m < sales.Count; m++)
                        {
                            if (sales[m] > comparesale)
                            {
                                comparesale = sales[m];
                                temp = m;
                            }
                        }
                        string movie = newMovieList[temp];
                        sortedMovieList.Add(movie);
                        double totalmsales = sales[temp];
                        sortedmSalesList.Add(totalmsales);
                        newMovieList.Remove(movie);
                        sales.Remove(totalmsales);
                        comparesale = 0;
                        temp = 0;
                    }
                   
                    for (int y = 0; y<3; y++)
                    {
                        
                        if (sortedmSalesList[y] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("{0}. {1, -25} ${2, -20}", y+1, sortedMovieList[y], sortedmSalesList[y]);
                        }
                    }                  
                }

                else if (option == "10") //display available seats of screening sessions in descending order
                {
                    if (screeningList.Count == 0)
                    {
                        Console.WriteLine("Please load screening data first/There are no screenings available");
                        continue;
                    }
                    Console.WriteLine("\nHere are the available seats of screening session: ");
                    Console.WriteLine();
                    Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}", "Screening No", "Screening Date Time", "Screening Type", "Cinema", "Hall Number", "Seats Remaining");
                    screeningList.Sort(); //using IComparable
                    for (int i = 0; i<screeningList.Count; i++)
                    {
                        Screening s = screeningList[i];                       
                        
                        Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}",
                        s.ScreeningNo, s.ScreeningDateTime, s.ScreeningType.ToUpper(), s.Cinema.Name, s.Cinema.HallNo, s.SeatsRemaining);
                    }                                    
                }
                
                else if (option == "11") //top 3 movies based on ticket sold 
                {
                   
                    if (movieList.Count == 0)
                    {
                        Console.WriteLine("Please load the movie and cinema data first.");
                        continue;
                    }
                    Console.WriteLine("\n====Here are the Top 3 Movies====");
                    Console.WriteLine("=================================");
                    Console.WriteLine("{0} {1,-20} {2}", "   ", "Movie", "Number of tickets sold");

                    movieList.Sort();

                    for (int i = 0; i < 3; i++)
                    {
                        Movie m =movieList[i];
                        if (movieList.Count == 0)
                        {
                            Console.WriteLine("There is no movies to show");
                            continue;
                        }
                        if (m.TicketSold == 0)
                        {
                            continue;
                        }
                        Console.WriteLine("{0}.  {1,-30} {2}", i+1, m.Title, m.TicketSold);
                    }
                }
                else if(option == "12") //top sales chart of the cinema name 
                {
                    if (orderList.Count == 0)
                    {
                        Console.WriteLine("There are no orders to generate the top 3 cinemas with the most sales");
                        continue;
                    }
                    //create unique cinema list
                    List<string> uniquecinemaList = new List<string>();
                    for (int i = 0; i<cinemaList.Count;i++)
                    {
                        if (i==0)
                        {
                            uniquecinemaList.Add(cinemaList[i].Name);
                        }
                        else if (cinemaList[i].Name == cinemaList[i-1].Name)
                        {
                            continue;
                        }
                        else
                        {
                            uniquecinemaList.Add(cinemaList[i].Name);
                        }
                    }
                    //get total sales for each cinema
                    List<double> csalesList = new List<double>();
                    double csales = 0;
                    for (int j = 0;j<uniquecinemaList.Count;j++)
                    {
                        for (int k = 0; k<orderList.Count;k++)
                        {
                            if (orderList[k].Status == "Paid")
                            {
                                string cinemaname = orderList[k].ticketList[0].Screening.Cinema.Name;
                                if (cinemaname == uniquecinemaList[j])
                                {
                                    csales += orderList[k].Amount;
                                }
                            }
                        }
                        csalesList.Add(csales);
                        csales = 0;
                    }
                    int index = 0;
                    double compare = 0;
                    List<string> sortedcinemaList = new List<string>();
                    List<double> sortedcsalesList = new List<double>();
                    // compare the sales for each cinema and append it to the list with the most sales being appended first 
                    for (int n = 0;n<uniquecinemaList.Count;n++)
                    {
                        for (int m = 0; m<csalesList.Count;m++)
                        {
                            if (csalesList[m]>compare)
                            {
                                compare = csalesList[m];
                                index = m;                               
                            }
                        }
                        string cinema = uniquecinemaList[index];
                        sortedcinemaList.Add(cinema);
                        double totalcsales = csalesList[index];
                        sortedcsalesList.Add(totalcsales);
                        uniquecinemaList.Remove(cinema);                                              
                        csalesList.Remove(totalcsales);
                        compare = 0;
                        index = 0;
                    }
                    //display the top 3 cinemas with the most sales 
                    Console.WriteLine("\n==== Here are the Top 3 Cinemas with the most sales ====");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("{0} {1,-20} {2}", "  ", "Cinema", "Sales");
                    for (int y = 0; y<3;y++)
                    {
                        if (sortedcsalesList[y] == 0) //if the sales of the cinema is 0, do not show
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("{0}. {1,-20} ${2:0.00}", y + 1, sortedcinemaList[y], sortedcsalesList[y]);
                        }
                    }
                    
                }

                else if (option == "0")
                {
                    Console.WriteLine("Thank you for visiting Singa Cineplexes");
                    break;
                }

                else
                {
                    Console.WriteLine("Your input is not in the options");
                    Console.WriteLine("Please choose again");
                    continue;
                }
            }
        }

        static void MainMenu()
        {
            Console.WriteLine("\n============Welcome to Singa Cineplexes============");
            Console.WriteLine("=================Select your option================");
            Console.WriteLine("[1]  Load Movie and Cinema data");
            Console.WriteLine("[2]  Load Screening data");
            Console.WriteLine("[3]  List all movies");
            Console.WriteLine("[4]  List movie screenings");
            Console.WriteLine("[5]  Add Movie Screening");
            Console.WriteLine("[6]  Delete Movie Screening");
            Console.WriteLine("[7]  Order Movie Ticket(s)");
            Console.WriteLine("[8]  Cancel Order Ticket");
            Console.WriteLine("[9]  Top 3 Movie Recommendation based on sales");
            Console.WriteLine("[10] Available seats of screening sessions");
            Console.WriteLine("[11] Top 3 Movies based on tickets sold");
            Console.WriteLine("[12] Top 3 Cinemas with the most sales");
            Console.WriteLine("[0]  Exit");
            Console.WriteLine("===================================================\n");
        }
        static void LoadMovies(List<Movie> mList)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Movie.csv"))
                {
                    string s = sr.ReadLine();
                    string[] heading = s.Split(',');

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] info = s.Split(',');
                        List<string> genreList = new List<string>();
                        if (info[0] == "")
                        {
                            break;
                        }
                        else
                        {
                            string[] genresplit = info[2].Split('/');
                            for (int i = 0; i < genresplit.Length; i++)
                            {
                                genreList.Add(genresplit[i]);
                            }
                            Movie m = new Movie(info[0], Convert.ToInt32(info[1]), info[3], Convert.ToDateTime(info[4]), genreList);
                            m.AddGenre(info[2]);
                            mList.Add(m);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void ListMovie(List<Movie> mList)
        {
            {
                Console.WriteLine("{0,10}  {1,30}  {2,15}  {3,13}  {4,7}", "Title", "Duration", "Classfication", "OpeningDate", "Genre");
                for (int i = 0; i < mList.Count; i++)
                {
                    string genre = null;
                    Movie m = mList[i];
                    for (int j = 0; j < m.genreList.Count; j++)
                    {
                        genre = m.genreList[j];
                    }
                    Console.WriteLine("[{0,-2}] {1,-27}  {2,-10}  {3,-15}  {4,-13}  {5}",
                    i + 1, m.Title, m.Duration, m.Classification, m.OpeningDate.ToString("dd/MM/yyyy"), genre);
                }
            }
        }

        static void LoadCinema(List<Cinema> cList)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Cinema.csv"))
                {
                    string s = sr.ReadLine();
                    string[] heading = s.Split(',');

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] info = s.Split(',');

                        cList.Add(new Cinema(info[0], Convert.ToInt32(info[1]), Convert.ToInt32(info[2])));

                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListCinema(List<Cinema> cList)
        {
            Console.WriteLine("{0,-4} {1,-17}  {2,-16}  {3,-25}", "", "Name", "Hall Number", "Capacity");
            for (int i = 0; i < cList.Count; i++)
            {
                Cinema c = cList[i];
                Console.WriteLine("[{0,-2}] {1,-17}  {2,-16}  {3,-25}",
                i + 1, c.Name, c.HallNo, c.Capacity);
            }

        }
        static void LoadScreening(List<Screening> sList, List<Cinema> cList, List<Movie> mList)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Screening.csv"))
                {
                    string s = sr.ReadLine();
                    string[] heading = s.Split(',');
                    int runno = 1000;

                    while ((s = sr.ReadLine()) != null)
                    {
                        runno++;
                        string[] info = s.Split(',');
                        string scinema = info[2];
                        int shallno = Convert.ToInt32(info[3]);

                        Cinema cinema = null;
                        for (int i = 0; i < cList.Count; i++)
                        {
                            if (scinema == cList[i].Name && shallno == cList[i].HallNo)
                            {
                                cinema = cList[i];
                            }
                        }
                        string smovie = info[4];
                        Movie movie = null;

                        for (int x = 0; x < mList.Count; x++)
                        {
                            if (smovie == mList[x].Title)
                            {
                                movie = mList[x];
                            }
                        }
                        Screening screen = new Screening(runno, Convert.ToDateTime(info[0]), info[1], cinema, movie);
                        screen.SeatsRemaining = cinema.Capacity;
                        sList.Add(screen);
                        movie.AddScreening(screen);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int ListScreening(List<Screening> sList, int chosen, List<Movie> mList)
        {

            Movie m = mList[chosen - 1];
            Screening s = null;
            int count = 0;

            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Movie.Title == m.Title)
                {
                    count++;
                    if (count == 1) //only if there is screenings for the movie then show this display title 
                    {
                        Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}", "Screening No", "Screening Date Time", "Screening Type", "Cinema", "Hall Number", "Seats Remaining");
                    }
                    s = sList[i];
                    Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}",
                    s.ScreeningNo, s.ScreeningDateTime, s.ScreeningType.ToUpper(), s.Cinema.Name, s.Cinema.HallNo, s.SeatsRemaining);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There are no screenings for this movie");
            }

            return count;

        }
        //alternative way to list screening 
        /*static int ListScreening(int chosen, List<Movie> mList)
         {
            Movie m = mList[chosen-1];
            int count = 0;
            if (m.ScreeningList.Count != 0)
            {
                Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}", "Screening No", "Screening Date Time", "Screening Type", "Cinema", "Hall Number", "Seats Remaining");
                for (int i = 0; i<m.ScreeningList.Count; i++)
                {
                    Console.WriteLine("{0,-13}  {1,-25}  {2,-25}  {3,-20}  {4,-20}  {5,-20}",
                    m.ScreeningList[i].ScreeningNo,  m.ScreeningList[i].ScreeningDateTime,  m.ScreeningList[i].ScreeningType.ToUpper(),  m.ScreeningList[i].Cinema.Name,  m.ScreeningList[i].Cinema.HallNo,  m.ScreeningList[i].SeatsRemaining);
                }
                count = 1;
            }
            else
            {
                Console.WriteLine("There are no screenings for this movie");
            }
        }
         */


        static Screening SearchScreening(List<Screening> sList, int sNo)
        {
            foreach (var s in sList)
            {
                if (s.ScreeningNo == sNo)
                {
                    return s;
                }
            }
            return null;
        }

        static Movie SearchMovie(List<Movie> mList, int t)
        {

            Movie m = mList[t - 1];
            for (int i = 0; i < mList.Count; i++)
            {
                if (mList[i].Title == m.Title)
                {
                    return m;
                }
            }
            return null;
        }

        static Cinema SearchCinema(List<Cinema> cList, int cHall)
        {
            foreach (var c in cList)
            {
                if (c.HallNo == cHall)
                {
                    return c;
                }
            }
            return null;
        }

        static Order SearchOrder(List<Order> oList, int n)
        {
            foreach (var o in oList)
            {
                if (o.OrderNo == n)
                {
                    return o;
                }
            }
            return null;
        }
    }
}