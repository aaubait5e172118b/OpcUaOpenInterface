using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Connection;
using Newtonsoft.Json;
using System.IO;

namespace API.Controllers
{
    public class Config
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Security Security { get; set; }

        public Config() { }

        public Config(string name, string description, string url)
        {
            Name = name;
            Description = description;
            Url = url;
        }


        public void Save() //TODO: Check i tilfælde af multiple users.
        {
            List<Config> confList = LoadConfig();
            if (confList == null)
                confList = new List<Config>();

            string dir = Directory.GetCurrentDirectory() + @"\config.json";
            using (StreamWriter str = new StreamWriter(dir))
            {
                confList.Add(this);
                str.Write(JsonConvert.SerializeObject(confList));
            }
        }

        public static List<Config> LoadConfig()
        {
            List<Config> configs = new List<Config>();

            string dir = Directory.GetCurrentDirectory() + @"\config.json";
            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();
                configs = JsonConvert.DeserializeObject<List<Config>>(json);
            }
            return configs;
        }

        public override string ToString()
        {
            return String.Format("{0}|{1}|{2}", Name, Description, Url); ;
        }

        public static LinkedList<string> LoadConfigToString()
        {
            List<Config> confList = new List<Config>();
            LinkedList<string> result = new LinkedList<string>();
            confList = LoadConfig();

            foreach (var conf in confList)
            {
                result.AddLast(conf.ToString());
            }

            return result;
        }
    }

    public class Security
    {
        public ConnectionType Option { get; set; }
        public string CertificatePath { get; set; }
        public string Credentials { get; set; }
    }
}
