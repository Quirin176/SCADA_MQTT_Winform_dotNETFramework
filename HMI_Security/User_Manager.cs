using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HMI_Security
{
    public class User_Manager
    {
        public const string ROOT = "Root";
        public const string USER = "User";
        public const string USERID = "UserID";
        public const string USERNAME = "UserName";
        public const string PASSWORDHASH = "PasswordHash";
        public const string PRIVILEGE = "Privilege";
        public const string ROLE = "Role";

        public const string XML_NAME_DEFAULT = "UserDatabase";

        private static List<User> _Users = new List<User>();

        public static List<User> Users
        {
            get { return _Users; }
            set { _Users = value; }
        }

        public static string XmlPath { set; get; }

        public static void Add(User aalm)
        {
            try
            {
                if (aalm == null) throw new NullReferenceException("The User is null reference exception");
                User fAalm = IsExisted(aalm);
                if (fAalm != null) throw new Exception(string.Format("UserName: '{0}' is existed", aalm.UserName));
                _Users.Add(aalm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(User aalm)
        {
            try
            {
                if (aalm == null) throw new NullReferenceException("The User is null reference exception");
                User fAalm = IsExisted(aalm);
                if (fAalm != null) throw new Exception(string.Format("UserName: '{0}' is existed", aalm.UserName));
                foreach (User item in _Users)
                {
                    if (item.UserID == aalm.UserID)
                    {
                        item.UserName = aalm.UserName;
                        item.PasswordHash = aalm.PasswordHash;
                        item.Privilege = aalm.Privilege;
                        item.Role = aalm.Role;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int aalmId)
        {
            try
            {
                User result = GetByChannelId(aalmId);
                if (result == null) throw new KeyNotFoundException("User ID is not found exception");
                _Users.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(string aalmName)
        {
            try
            {
                User result = GetByChannelName(aalmName);
                if (result == null) throw new KeyNotFoundException("UserName is not found exception");
                _Users.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(User aalm)
        {
            try
            {
                if (aalm == null) throw new NullReferenceException("The User is null reference exception");
                foreach (User item in _Users)
                {
                    if (item.UserID == aalm.UserID)
                    {
                        _Users.Remove(item);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static User IsExisted(User aalm)
        {
            User result = null;
            try
            {
                foreach (User item in _Users)
                {
                    if (item.UserID != aalm.UserID && item.UserName.Equals(aalm.UserName))
                    {
                        result = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static User GetByChannelId(int aalmId)
        {
            User result = null;
            try
            {
                foreach (User item in _Users)
                {
                    if (item.UserID == aalmId)
                    {
                        result = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static User GetByChannelName(string AalmName)
        {
            User result = null;
            try
            {
                foreach (User item in _Users)
                {
                    if (item.UserName.Equals(AalmName))
                    {
                        result = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static List<User> GetChannels()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (string.IsNullOrEmpty(XmlPath) || string.IsNullOrWhiteSpace(XmlPath))
                    XmlPath = ReadKey(XML_NAME_DEFAULT);
                xmlDoc.Load(XmlPath);
                var nodes = xmlDoc.SelectNodes(ROOT);
                foreach (XmlNode rootNode in nodes)
                {
                    XmlNodeList channelNodeList = rootNode.SelectNodes(USER);
                    foreach (XmlNode almNode in channelNodeList)
                    {
                        User newAAlarm = new User();
                        newAAlarm.UserID = int.Parse(almNode.Attributes[USERID].Value);
                        newAAlarm.UserName = almNode.Attributes[USERNAME].Value;
                        newAAlarm.PasswordHash = almNode.Attributes[PASSWORDHASH].Value;
                        newAAlarm.Privilege = int.Parse(almNode.Attributes[PRIVILEGE].Value);
                        newAAlarm.Role = almNode.Attributes[ROLE].Value;

                        _Users.Add(newAAlarm);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Users;
        }

        public static void CreatFile(string pathXml)
        {
            try
            {
                if (File.Exists(pathXml))
                {
                    File.Delete(pathXml);
                }
                XElement element = new XElement(ROOT);
                XDocument doc = new XDocument(element);
                doc.Save(pathXml);
                XmlPath = pathXml;
                WriteKey(XML_NAME_DEFAULT, pathXml);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadKey(string keyName)
        {
            string result = string.Empty;
            try
            {
                Microsoft.Win32.RegistryKey regKey;
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\IndustrialHMI");
                if (regKey != null) result = (string)regKey.GetValue(keyName);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }

        public static void WriteKey(string keyName, string keyValue)
        {
            try
            {
                Microsoft.Win32.RegistryKey regKey;
                regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\IndustrialHMI");
                regKey.SetValue(keyName, keyValue);
                regKey.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        public static void Save(string pathXml)
        {
            try
            {
                WriteKey(XML_NAME_DEFAULT, pathXml);
                CreatFile(pathXml);
                XmlPath = pathXml;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(pathXml);
                XmlNode root = xmlDoc.SelectSingleNode(ROOT);

                // List Channels.
                foreach (User alm in Users)
                {
                    XmlElement AalmElement = xmlDoc.CreateElement(USER);
                    AalmElement.SetAttribute(USERID, string.Format("{0}", alm.UserID));
                    AalmElement.SetAttribute(USERNAME, alm.UserName);
                    AalmElement.SetAttribute(PASSWORDHASH, alm.PasswordHash);
                    AalmElement.SetAttribute(PRIVILEGE, string.Format("{0}", alm.Privilege));
                    AalmElement.SetAttribute(ROLE, alm.Role);

                    root.AppendChild(AalmElement);
                }
                xmlDoc.Save(pathXml);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
