using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Image Picture { get; set; }
        [DataMember]
        public string PicturePath { get; set; }


        public User(string name)
        {
            Name = name;
        }

        public User(string name, string picturePath)
        {
            Name = name;
            Picture = Image.FromFile(picturePath);
            PicturePath = picturePath;
        }

    }
}
