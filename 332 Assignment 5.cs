using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();   //call private function
        }

        //Initialize values
        private void Initialize()
        {
            server = "127.0.0.1";   //ip address
            database = "GALLERY";   //DB Name
            uid = "root";           //username
            password = "pass";  //pass
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString); //connect to DB with connectionString
        } //end initialize

        //open connection to database
        private bool OpenConnection()
        {
            //try catch to get common error codes
            try
            {
                connection.Open();  //open connection
                return true;
            }
            catch (MySqlException ex)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }//end catch
        }//end OpenConnection

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }//end CloseConnection

        //Select Artist
        public void SelectArtist(bool sort)
        {
            string query;
            Console.WriteLine();

            if (!sort)
            {
                query = "SELECT * FROM ARTIST"; //ARTIST Table Query
            } else {
                query = "SELECT * FROM ARTIST ORDER BY LName ASC"; //ARTIST Table Query
                Console.WriteLine("Artist Ordered by Last Name ascending\n");
            } //end if else

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();


                //Read the data and write it to console - while rows still exist
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetName(0) + ": " + dataReader[0] + "\n" +
                                    dataReader.GetName(1) + ": " + dataReader[1] + "\n" +
                                    dataReader.GetName(2) + ": " + dataReader[2] + "\n" +
                                    dataReader.GetName(3) + ": " + dataReader[3] + "\n" +
                                    dataReader.GetName(4) + ": " + dataReader[4] + "\n" +
                                    dataReader.GetName(5) + ": " + dataReader[5] + "\n" +
                                    dataReader.GetName(6) + ": " + dataReader[6] + "\n" +
                                    dataReader.GetName(7) + ": " + dataReader[7] + "\n" +
                                    dataReader.GetName(8) + ": " + dataReader[8] + "\n" +
                                    dataReader.GetName(9) + ": " + dataReader[9] + "\n" +
                                    dataReader.GetName(10) + ": " + dataReader[10] + "\n" +
                                    dataReader.GetName(11) + ": " + dataReader[11] + "\n" +
                                    "\n------------");
                } //end while
                Console.WriteLine();

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }//end if

        } //end SelectArtist

        //Select statement
        public void SelectArtwork(bool sort)
        {
            string query;
            if (!sort)
            {
                query = "SELECT * FROM ARTWORK"; //ARTWORK Table Query
            } else {
                query = "SELECT * FROM ARTWORK ORDER BY Price ASC"; //ARTWORK Table Query
                Console.WriteLine("Artwork Ordered by Price ascending\n");
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                Console.WriteLine();

                //Read the data and write it to console - while rows still exist
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetName(0) + ": " + dataReader[0] + "\n" +
                                     dataReader.GetName(1) + ": " + dataReader[1] + "\n" +
                                     dataReader.GetName(2) + ": " + dataReader[2] + "\n" +
                                     dataReader.GetName(3) + ": " + dataReader[3] + "\n" +
                                     dataReader.GetName(4) + ": " + dataReader[4] + "\n" +
                                     dataReader.GetName(5) + ": " + dataReader[5] + "\n" +
                                     dataReader.GetName(6) + ": " + dataReader[6] + "\n" +
                                     "\n------------");
                } //end while
                Console.WriteLine();

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
        } //end SelectArtwork

        //Select statement
        public void SelectArtShows(bool sort)
        {
            string query;
            if (!sort)
            {
                query = "SELECT * FROM ART_SHOWS"; //ARTSHOWS Table Query
            } else {
                query = "SELECT * FROM ART_SHOWS ORDER BY ShowDate ASC"; //ARTSHOWS Table Query
                Console.WriteLine("ArtShows Ordered by Date ascending\n");
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                Console.WriteLine();

                //Read the data and write it to console - while rows still exist
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetName(0) + ": " + dataReader[0] + "\n" +
                                     dataReader.GetName(1) + ": " + dataReader[1] + "\n" +
                                     dataReader.GetName(2) + ": " + dataReader[2] + "\n" +
                                     dataReader.GetName(3) + ": " + dataReader[3] + "\n" +
                                     dataReader.GetName(4) + ": " + dataReader[4] + "\n" +
                                     dataReader.GetName(5) + ": " + dataReader[5] + "\n" +
                                     dataReader.GetName(6) + ": " + dataReader[6] + "\n" +
                                     "\n------------");
                } //end while
                Console.WriteLine();

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
        } //end SelectArtShows


          //Select statement
        public void SelectCustomer(bool sort)
        {
            string query;
            if (!sort)
            {
                query = "SELECT * FROM CUSTOMER"; //CUSTOMER Table Query
            } else {
                query = "SELECT * FROM CUSTOMER ORDER BY CustomerNumber ASC"; //CUSTOMER Table Query
                Console.WriteLine("Artist Ordered by Customer Number ascending\n");
            } //end if else
            //Open connection
            if (this.OpenConnection() == true) {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    Console.WriteLine();

                    //Read the data and write it to console - while rows still exist
                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader.GetName(0) + ": " + dataReader[0] + "\n" +
                                    dataReader.GetName(1) + ": " + dataReader[1] + "\n" +
                                    dataReader.GetName(2) + ": " + dataReader[2] + "\n" +
                                    dataReader.GetName(3) + ": " + dataReader[3] + "\n" +
                                    "\n------------");
                    } //end while
                    Console.WriteLine();

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();
            }
        } //end SelectCustomer

        //Select statement
        public void SelectInterestedIn(bool sort)
        {
            string query;
            if (!sort)
            {
                query = "SELECT * FROM INTERESTED_IN"; //INTERESTED_IN Table Query
            } else {
                query = "SELECT * FROM INTERESTED_IN ORDER BY CustomerNo"; //INTERESTED_IN Table Query
                Console.WriteLine("Artist Ordered by Customer # ascending\n");
            }
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                Console.WriteLine();

                //Read the data and write it to console - while rows still exist
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetName(0) + ": " + dataReader[0] + "\n" +
                                     dataReader.GetName(1) + ": " + dataReader[1] + "\n" +
                                     "\n------------");
                } //end while
                Console.WriteLine();

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
        } //end SelectInterestedIn
    }



    class Program {
        static void Main(string[] args)
    {
            String table, sortBy, temp;
            bool sort = false, end = false;

            //new connection
            DBConnect galleryDatabase = new DBConnect();

            do {
                //Get User table input
                Console.WriteLine("Enter exact table to return - Artist, Artwork, ArtShows, Customer, InterestedIn");
                table = Console.ReadLine();

                //get sorted or not
                Console.WriteLine("Sorted? (Y/N)");
                temp = Console.ReadLine();

                //set sorted or not
                if (temp == 'y'.ToString() || temp == 'Y'.ToString())
                {
                    sort = true;
                }
                //call select statement
                switch (table)
                {
                    case "Artist":
                        if (sort)
                            galleryDatabase.SelectArtist(true);
                        else
                            galleryDatabase.SelectArtist(false);
                        break;
                    case "Artwork":
                        if (sort)
                            galleryDatabase.SelectArtwork(true);
                        else
                            galleryDatabase.SelectArtwork(false);

                        break;
                    case "ArtShows":
                        if (sort)
                            galleryDatabase.SelectArtShows(true);
                        else
                            galleryDatabase.SelectArtShows(false);

                        break;
                    case "Customer":
                        if (sort)
                            galleryDatabase.SelectCustomer(true);
                        else
                            galleryDatabase.SelectCustomer(false);

                        break;
                    case "InterestedIn":
                        if (sort)
                            galleryDatabase.SelectInterestedIn(true);
                        else
                            galleryDatabase.SelectInterestedIn(false);
                        break;
                    default:
                        Console.WriteLine($"An unexpected value ({table})");
                        break;
                }
                Console.WriteLine("Continue? Y/N");
                temp = Console.ReadLine();
                if (temp == 'n'.ToString() || temp == 'N'.ToString())
                {
                    end = true;
                }

                table = "";
                sortBy = "";
                temp = "";
                sort = false;
            } while (!end);
        }
    }
}
