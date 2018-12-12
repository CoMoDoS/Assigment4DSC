using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.models;

namespace WcfService1.DBO
{
    public class UserDBO
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public UserDBO()
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
        public int Insert(User user)
        {
            string query = "INSERT INTO user (name, email, password, admin) VALUES(@name,@email,@pass,@admin)";
            string query2 = "select last_insert_id();";
            //open connection
            try
            {
                this.OpenConnection();
                
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Prepare();
                cmd.Parameters.AddWithValue("name", user.name);
                cmd.Parameters.AddWithValue("email", user.email);
                cmd.Parameters.AddWithValue("pass", user.password);
                cmd.Parameters.AddWithValue("admin", user.admin);


                //Execute command
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                int id = Convert.ToInt32(cmd2.ExecuteScalar());

                //close connection
                this.CloseConnection();
                return id;
                
            }catch(Exception e)
            {
                throw e;
            }
            
        }

        //Update statement
        public int Update(User user, int id)
        {
            string query = "UPDATE user SET name=@name, email=@email, password=@pass, admin=@admin  WHERE iduser=@id";

            //Open connection
           try
            {
                this.OpenConnection();
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("name", user.name);
                cmd.Parameters.AddWithValue("email", user.email);
                cmd.Parameters.AddWithValue("pass", user.password);
                cmd.Parameters.AddWithValue("admin", user.admin);
                cmd.Parameters.AddWithValue("id", user.id);

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                return id;
            }catch(Exception e)
            {
                throw e;
            }
        }

        //Delete statement
        public int Delete(int id)
        {
            string query = @"DELETE FROM user WHERE iduser = @id ";

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
               
                cmd.Parameters.AddWithValue("id",id);
                
                cmd.ExecuteNonQuery();
                this.CloseConnection();
                return id;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        //Select statement
        public List<User> SelectAll()
        {
            string query = "SELECT * FROM user";

            //Create a list to store the result
            List<User> users = new List<User>();

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
                    User user = new User();
                    user.id = Convert.ToInt32(dataReader["iduser"].ToString());
                    user.name = dataReader["name"].ToString();
                    user.email = dataReader["email"].ToString();
                    user.password = dataReader["password"].ToString();
                    user.admin = dataReader["admin"].ToString();
                    users.Add(user);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return users;
            }catch( Exception e)
            {
                throw e;
            }
        }

        public User GetUserById(int id)
        {
            string query = "SELECT * FROM user WHERE iduser=@id";

            //Create a list to store the result
            User user = new User();

            //Open connection
          try
            {
                this.OpenConnection();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                cmd.Prepare();
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                user.id = Convert.ToInt32(dataReader["iduser"].ToString());
                user.name = dataReader["name"].ToString();
                user.email = dataReader["email"].ToString();
                user.password = dataReader["password"].ToString();
                user.admin = dataReader["admin"].ToString();
                this.CloseConnection();
                return user;

            }catch (Exception e)
            {
                throw e;
            }
        }
       
    }
}