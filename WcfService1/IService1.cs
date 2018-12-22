using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WcfService1.models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]

    // [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Literal)]
    [XmlSerializerFormat(Style = OperationFormatStyle.Document, Use = OperationFormatUse.Literal)]
    public interface IService1
    {

        
        [OperationContract(Action = "/GetToken")]

        List<User> GetToken(string userName, string password);
        
        //CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract(Action = "/GetAllUsers")]
        List<User> GetAllUsers();
        
        [OperationContract(Action = "/InsertUser")]
        int InsertUser(User u);
        
        [OperationContract(Action = "/InsertPackage")]
        int InsertPackage(Package u);
        
        [OperationContract(Action = "/GetAllPackages")]
        List<Package> GetAllPackages();
        
        [OperationContract(Action = "/GetPackagesByIdUser")]
        //[WebInvoke(Method = "POST", UriTemplate = "*")]
        [EnableCors(origins: "", headers: "", methods: "*")]
        List<Package> GetPackagesByIdUser(int id);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }


   
}
