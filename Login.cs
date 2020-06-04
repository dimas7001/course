using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace LoginNamespace
{
    class Login
    {
        public static char CheckPassword (string login, string password, ref int user)
        {
            JObject profiles = JObject.Parse((string)File.ReadAllText("../../data/LoginsPasswords.json"));
            for (int i = 0; i < profiles["data"].Count(); i++)
            {
                if ((string)profiles["data"][i]["login"] == login && (string)profiles["data"][i]["password"] == password)
                {
                    user = i;
                    return 'e';
                }
                else
                if ((string)profiles["data"][i]["login"] == login && (string)profiles["data"][i]["password"] != password)
                    return 'p';
                else
                if ((string)profiles["data"][i]["login"] != login && (string)profiles["data"][i]["password"] == password)
                    return 'l';
            }
            return 'a';
        }
    }
}
