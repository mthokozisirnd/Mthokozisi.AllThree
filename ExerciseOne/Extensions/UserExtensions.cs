using ExerciseOne.Models;
using System.Xml.Linq;

namespace ExerciseOne.Web.Extensions
{
    public static class UserExtensions
    {
        public static User ToModel(this XElement xElement)
        {
            var user = new User();
            if (xElement != null)
            {
                var userId = Guid.Parse(xElement.Element("Id").Value);

                user.Id = userId;
                user.Name = xElement.Element("Name").Value;
                user.Surname = xElement.Element("Surname").Value;
                user.CellPhone = xElement.Element("Cellphone").Value;
            }
            return user;
        }

        public static List<User> ToModelList(this List<XElement> xElements)
        {
            var users = new List<User>();
            if (xElements != null)
            {
                foreach (var xElement in xElements)
                {
                    var user = new User();
                    var userId = Guid.Parse(xElement.Element("Id").Value);

                    user.Id = userId;
                    user.Name = xElement.Element("Name").Value;
                    user.Surname = xElement.Element("Surname").Value;
                    user.CellPhone = xElement.Element("Cellphone").Value;
                    users.Add(user);
                }
            }
            return users;
        }

        public static XElement ToXmlElement(this User user)
        {
            var xElement = new XElement("User");
            if (user != null)
            {
                xElement.SetElementValue("Id", user.Id);
                xElement.SetElementValue("Name", user.Name);
                xElement.SetElementValue("Surname", user.Surname);
                xElement.SetElementValue("Cellphone", user.CellPhone);
            }
            return xElement;
        }
    }
}
