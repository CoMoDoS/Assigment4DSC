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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetToken(string userName, string password)
        {
            if (userName == "testUser" && password == "testPassword")
            {
                // Authentication Successful
                UserDBO dbc = new UserDBO();
                User user = new User();
                user.name = "Ionut";
                user.admin = "i@i.i";
                user.password = "ion";
                user.admin = "N";
                dbc.Insert(user);
                return "mata suge";
            }
            else
            {
                // Authentication Failed
                return "tot   pula";
            }
        }
    }
}
