using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.models;

namespace WcfService1.DBO
{
    public class PackageDBO
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public PackageDBO()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            // server = "localhost";
            // database = "connectcsharptomysql";
            // uid = "username";
            // password = "password";
            string connectionString;
            //       connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
            // database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connectionString = "SERVER=localhost;DATABASE=assig4;UID=root;PASSWORD=root";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public int Insert(Package package)
        {
            string query = "INSERT INTO package(description,destinationCity,id_reciver, id_sender,name,route,senderCity,tracking) VALUES (@description,@destinationCity,@id_reciver,@id_sender,@name,@route,@senderCity,@tracking)";
            string query2 = "select last_insert_id();";
            //open connection
            try
            {
                this.OpenConnection();

                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Prepare();
                cmd.Parameters.AddWithValue("name", package.name);
                cmd.Parameters.AddWithValue("description", package.description);
                cmd.Parameters.AddWithValue("destinationCity", package.destinationCity);
                cmd.Parameters.AddWithValue("id_reciver", package.id_reciver);
                cmd.Parameters.AddWithValue("id_sender", package.id_sender);
                cmd.Parameters.AddWithValue("route", package.route);
                cmd.Parameters.AddWithValue("senderCity", package.sendercity);
                cmd.Parameters.AddWithValue("tracking", package.tracking);


                //Execute command
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                int id = Convert.ToInt32(cmd2.ExecuteScalar());

                //close connection
                this.CloseConnection();
                return id;

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        //Select statement
        public List<Package> SelectAll()
        {
            string query = "SELECT * FROM package";

            //Create a list to store the result
            List<Package> packages = new List<Package>();

            //Open connection
            try
            {

                this.OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Package package = new Package();
                    package.id = Convert.ToInt32(dataReader["idPackage"].ToString());
                    package.name = dataReader["name"].ToString();
                    package.description = dataReader["description"].ToString();
                    package.destinationCity = dataReader["destinationCity"].ToString();
                    package.id_reciver = Convert.ToInt32(dataReader["id_reciver"].ToString());
                    package.id_sender = Convert.ToInt32(dataReader["id_sender"].ToString());
                    package.route = dataReader["route"].ToString();
                    package.sendercity = dataReader["senderCity"].ToString();
                    package.tracking = dataReader["tracking"].ToString();
                    packages.Add(package);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return packages;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Package> GetPackagesByIduser(int id)
        {
            string query = "SELECT * FROM package where id_sender=@id or id_reciver=@id";

            //Create a list to store the result
            List<Package> packages = new List<Package>();

            //Open connection
            try
            {

                this.OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("id", id);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Package package = new Package();
                    package.id = Convert.ToInt32(dataReader["idPackage"].ToString());
                    package.name = dataReader["name"].ToString();
                    package.description = dataReader["description"].ToString();
                    package.destinationCity = dataReader["destinationCity"].ToString();
                    package.id_reciver = Convert.ToInt32(dataReader["id_reciver"].ToString());
                    package.id_sender = Convert.ToInt32(dataReader["id_sender"].ToString());
                    package.route = dataReader["route"].ToString();
                    package.sendercity = dataReader["senderCity"].ToString();
                    package.tracking = dataReader["tracking"].ToString();
                    packages.Add(package);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return packages;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       


        
    }
}