using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core;
using DataAccessLayer;
using System.Drawing.Imaging;
using System.IO;

namespace MirchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public void Add(string name)
        {
            new UserDB().Add(name);
        }

        public void AddWithPicture(string name, string picture)
        {
            Add(name);
            byte[] picBytes = Convert.FromBase64String(picture);
            MemoryStream imgStream = new MemoryStream(picBytes);
            Image image = Image.FromStream(imgStream);

            image.Save("/pictures/" + name + ".jpeg", ImageFormat.Jpeg);
            image.Dispose();

        }

        public User GetUser(int id)
        {
            return new UserDB().Get(id);
        }
    }
}
