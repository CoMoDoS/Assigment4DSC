using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.DBO;
using WcfService1.models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<User> GetAllUsers()
        {
            UserDBO dbc = new UserDBO();
            List<User> list = dbc.SelectAll();

            return list;
        }

        public List<User> GetToken(string userName, string password)
        {
            if (userName == "testUser" && password == "testPassword")
            {
                // Authentication Successful
                UserDBO dbc = new UserDBO();
                User user = new User();
               //dbc.Delete(6);

                //user.name = "Ionut";
                //user.email = "a@i.i";
                //user.password = "ion";
                //user.admin = "N";
                //int w = dbc.Insert(user);
                //Console.WriteLine(w);

                //User a = new User();
                //a = dbc.GetUserById(2);
                //Console.WriteLine(a.ToString() + a.email) ;

                //int q = dbc.Update(a, 7);
                //Console.WriteLine(q);

                List<User> list = dbc.SelectAll();




                return list;
            }
            else
            {
                // Authentication Failed
                return null;
            }
        }

        public int Insert(User u)
        {
            UserDBO dbc = new UserDBO();
            int w = dbc.Insert(u); 
            return w;
        }
    }
}
