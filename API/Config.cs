using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Connection;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;

namespace API
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
   
            using (StreamWriter str = new StreamWriter(GetConfDir()))
            {
                confList.Add(this);
                str.Write(JsonConvert.SerializeObject(confList));
            }
        }

        public static List<Config> LoadConfig()
        {
            List<Config> configs = new List<Config>();

            using (StreamReader r = new StreamReader(GetConfDir()))
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

        private static string GetConfDir()
        {
            string dir = Directory.GetCurrentDirectory();
            
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                dir += @"\config.json";
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
                System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                dir += @"/config.json";
               
            return dir;
        }
    }

    public class Security
    {
        public ConnectionType Option { get; set; }
        public string CertificatePath { get; set; }
        public string Credentials { get; set; }
    }
    
    
}
