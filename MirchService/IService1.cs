using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core;
using System.Drawing;

namespace MirchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void Add(string name);

        [OperationContract]
        void AddWithPicture(string name, string picture);


    }
}
