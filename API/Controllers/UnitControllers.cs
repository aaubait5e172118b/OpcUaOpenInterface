using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opc.Ua;
using Client;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class InitiateClientSession
    {
        public List<ReferenceDescriptionCollection> ReferencesList { get; set; }

        public InitiateClientSession(Config conf)
        {
            ReferencesList = new List<ReferenceDescriptionCollection>();

            Console.WriteLine(conf.Name + " configuration loaded.");
            var client = new Client.Client(conf.Url);

            ReferencesList.Add(Client.utils.Namespace.BrowseRoot(client.Session));

            client.Kill();
        }
    }

    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        // GET api/unit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Config.LoadConfigToString();
        }

        // GET api/unit/id
        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            List<string> result = new List<string>();
            Config conf;

            try
            {
                List<Config> confList = new List<Config>();
                confList = Config.LoadConfig();
                conf = confList[id];
            }
            catch (Exception ex)
            {
                result.Add(String.Format("Error occured when loading configuration. Message: >> {0} <<", ex.Message));
                return result;
            }

            try
            { 
                var init = new InitiateClientSession(conf);

                foreach (var collection in init.ReferencesList)
                {
                    foreach (var reference in collection)
                    {
                        result.Add(reference.ToString());
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                result.Add(String.Format("Error occured: Connection could not be established. Message: >> {0} <<", ex.Message));
                return result;
            }
            catch (Exception ex)
            {
                result.Add(String.Format("Error occured. Message: >> {0} <<", ex.Message));
                return result;
            }

            return result;
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
