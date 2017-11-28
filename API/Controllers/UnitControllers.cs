using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Client;
//using Opc.Ua;
using Newtonsoft.Json;
using Opc.Ua;
using Client = Client.Client;
using Node = Client.Node;

namespace API.Controllers
{
    public class InitiateClientSession
    {
        public List<Node> NodeCollection { get; set; }

        public InitiateClientSession(Config conf)
        {
            NodeCollection = new List<Node>();

            Console.WriteLine(conf.Name + " configuration loaded.");
            var client = new global::Client.Client(conf.Url);

            List<Node> discoveredNodes = Node.Discover(client.Session);
            
            client.Kill();

            NodeCollection = Node.OrderList(discoveredNodes);
        }
    }

    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        // GET api/unit
        [HttpGet]
        public IEnumerable<Config> Get()
        {
            return Config.LoadConfig();
        }

        // GET api/unit/id
        [HttpGet("{id}")]
        public IEnumerable<Node> Get(int id)
        {
            string result = "";
            
            List<Config> confList = new List<Config>();
            confList = Config.LoadConfig();
            Config conf = confList[id];
            
            var init = new InitiateClientSession(conf);

            Console.WriteLine("JSON response created on " + conf.Name);
            return init.NodeCollection;
        }

        // Add new module configuration to the config.json in root folder. 
        // POST api/unit
        [HttpPost]
        public string Post([FromBody]string value) // expects json format
        {
            Config newConf;

            try
            {
                newConf = JsonConvert.DeserializeObject<Config>(value);
                newConf.Save();
            }
            catch (Exception ex)
            {
                return String.Format("Error in adding a new configuration. Message: {0}", ex.Message);
            }

            Console.WriteLine(String.Format("New configuration added: {0}", newConf.Name));
            return String.Format("New configuration added succesfully.");
        }

    





        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
