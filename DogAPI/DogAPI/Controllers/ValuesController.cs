using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace DogAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private List<Dog> dogs = new List<Dog>();
        public ValuesController()
        {
            string[] files = Directory.GetFiles("DogFiles", "*.json");
            foreach (string file in files)
            {
                Dog dog = (JsonConvert.DeserializeObject<Dog>(System.IO.File.ReadAllText(file)));
                dogs.Add(dog);
            }
        }

        // GET api/values
        [HttpGet]
        public List<Dog> Get()
        {
            return dogs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Dog Get(string id)
        {
            return dogs.Where(x => x.BreedName == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post(Dog dog)
        {
            dogs.Add(dog);
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

//var files = Directory.GetFiles("DogFiles", "*.json");
//List<Dog> dogs = new List<Dog>();
//            foreach (var file in files)
//            {
//                dogs.Add(JsonConvert.DeserializeObject<Dog>(System.IO.File.ReadAllText(file)));
//            }
//            return dogs.Select(d => d.BreedName).ToArray();


//dogs.Add(new Dog { ID = 0, BreedName = "Pug", Description = "Small, cute and noisy", WikipediaUrl = "https://en.wikipedia.org/wiki/Pug" });
//            dogs.Add(new Dog { ID = 1, BreedName = "Labrador", Description = "Energetic and hungry", WikipediaUrl = "https://en.wikipedia.org/wiki/Labrador_Retriever" });
//            dogs.Add(new Dog { ID = 2, BreedName = "Chihuahua", Description = "Small but nasty", WikipediaUrl = "https://en.wikipedia.org/wiki/Chihuahua_(dog)" });
