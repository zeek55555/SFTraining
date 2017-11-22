using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using Telerik.Sitefinity;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.WebApi
{
    [DataContract]
    public class Pet
    {
        private DynamicContent dynamicContent;

        public Pet()
        {
        }

        public Pet(DynamicContent dynamicContent)
        {
            this.Id = dynamicContent.Id;
            this.Name = dynamicContent.GetValue<Lstring>("Name");
            this.Age = dynamicContent.GetValue<decimal?>("Age");
            this.Breed = dynamicContent.GetValue<Lstring>("Breed");
        }

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal? Age { get; set; }
        [DataMember]
        public string Breed { get; set; }
    }

    public class PetsController : ApiController
    {
        public IQueryable<DynamicContent> Pets
        {
            get
            {
                DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
                Type petType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Pets.Pet");
                
                // This is how we get the collection of Pet items
                var myCollection = dynamicModuleManager.GetDataItems(petType).Where(d => d.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live && d.Visible);
                return myCollection;
            }
        }

        public PetsController()
        {
            //Pets = new List<Pet>();
            //Pets.Add(new Pet
            //{
            //    Id = 0,
            //    Name = "Bob",
            //    Age = 2,
            //    Breed = "Golden"
            //});
            //Pets.Add(new Pet
            //{
            //    Id = 1,
            //    Name = "Bobby",
            //    Age = 7,
            //    Breed = "Gold"
            //});
            //Pets.Add(new Pet
            //{
            //    Id = 2,
            //    Name = "Bobert",
            //    Age = 5,
            //    Breed = "Goldendoodle"
            //});
        }

        [HttpGet]
        public List<Pet> Get()
        {
            return Pets.Select(p => new Pet(p)).ToList();
        }

        [HttpGet]
        public Pet Get(Guid id)//(int id)
        {
            var pet = Pets.Where(p => p.Id == id).FirstOrDefault();
            //return new Pet(Pets.FirstOrDefault());
            return new Pet(pet);
        }

        //[HttpGet]
        //public Pet GetByName(string name)
        //{
        //    return Pets.Where(p => p.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
        //}

        //[HttpGet]   //api/pets/getbynameandage?name=Bob&age=2

        //public Pet GetByNameAndAge(string name, int age)
        //{
        //    return Pets.Where(p => p.Name.ToUpper() == name.ToUpper() && p.Age == age).FirstOrDefault();
        //}
        
        [HttpPost]
        public Pet Post([FromBody] Pet pet)
        {
            return new Pet();
        }
    }
}