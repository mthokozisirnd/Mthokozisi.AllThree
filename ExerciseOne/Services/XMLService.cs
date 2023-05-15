using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ExerciseOne.Models;
using ExerciseOne.Web.Extensions;

namespace ExerciseOne.Web.Services
{
    public class XMLService : IXMLService
    {
        public async Task Create(User user)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(@"Data/Users.xml");
                // Update Element value  

                if (xmlDoc != null)
                {
                    xmlDoc.Element("Users").
                                    Elements("User").
                                    ElementAt(0).
                                    AddAfterSelf(user.ToXmlElement());
                }

                await using FileStream fileStream = File.Open(@"Data/Users.xml", FileMode.OpenOrCreate);
                await xmlDoc.SaveAsync(fileStream, SaveOptions.None, CancellationToken.None);
            }
            catch(Exception ex)
            {
                throw;
            }
            Console.WriteLine();
        }

        public async Task<User> GetUserById(string userId)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(@"Data/Users.xml");
                // Update Element values 
                var itemObject = from item in xmlDoc.Descendants("User")
                                 where (string)item.Element("Id") == userId
                                 select item;

              
                var savedItem = itemObject.FirstOrDefault().ToModel();
                return savedItem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(@"Data/Users.xml");
                // Select Element values 

                IEnumerable<XElement> itemObject = xmlDoc.Descendants("User")
                                        .OrderBy(order => order.Attribute("Name"));

                var users = itemObject.ToList().ToModelList();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(@"Data/Users.xml");
                // Update Element values 
                var itemObject = from item in xmlDoc.Descendants("User")
                                 where item.Element("Id").Value == user.Id.ToString()
                                 select item;
                if (itemObject != null)
                {
                    foreach (XElement itemElement in itemObject)
                    {
                        itemElement.SetElementValue("Name", user.Name);
                        itemElement.SetElementValue("Surname", user.Surname);
                        itemElement.SetElementValue("Cellphone", user.CellPhone);
                    }
                }

                await using FileStream fileStream = File.Open(@"Data/Users.xml", FileMode.OpenOrCreate);
                await xmlDoc.SaveAsync(fileStream, SaveOptions.None, CancellationToken.None);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(string UserId)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(@"Data/Users.xml");
                // Update Element values 
                var itemObject = from item in xmlDoc.Descendants("User")
                                 where item.Element("Id").Value == UserId
                                 select item;
                if (itemObject != null)
                {
                    itemObject.Remove();
                }
                
                await using FileStream fileStream = File.Open(@"Data/Users.xml", FileMode.OpenOrCreate);
                await xmlDoc.SaveAsync(fileStream, SaveOptions.None, CancellationToken.None);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
