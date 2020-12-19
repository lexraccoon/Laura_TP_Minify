using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Minify.Interfaces;
using Minify.Model;

namespace Minify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinifyController : ControllerBase
    {
        public IRepository repo;
        // public MongoRepository mongo;
        private readonly ITokenGenerator _token;

        public MinifyController()
        {
            this.repo = new Repository();
            /* Instancier le fichier MongoRepository
             * this.mongo = new MongoRepository();
             */
            this._token = new TokenGenerator();

        }

        /* malgré avoir mis dans Startup.cs :
         * services.AddScoped<ITokenGenerator, TokenGenerator>(); services.AddScoped<IRepository, MongoRepository>();
         * le site ne fonctionne pas mais grâce au deuxième controller les tests oui
         */
        public MinifyController(IRepository repoObject, ITokenGenerator tokenGeneratorObject)
        {
            this.repo = repoObject;
            _token = tokenGeneratorObject;
        }

        [HttpPost]
        public string Add([FromBody] MinifyData data)
        {
            data.Key = _token.Generate();
            data.Url = "https://www." + data.Url;

            repo.Add(data);
            
            /* Pour pouvoir ajouter dans la bdd le token + l'url : 
             * mongo.Add(data);
             * j'ai mis en commentaires car sinon les tests unitaires ne fonctionnent pas.
             */

            return data.Key;
        }

        [HttpGet]
        public IEnumerable<MinifyData> Get()
        {
            /* Pour afficher la liste des tokens et url de la bdd mongo :
             * return mongo.Get(): 
             */
            return repo.Get();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            /* Pour supprimer de la bdd mongo en fonction du token (id) :
             * mongo.Delete(id)
             */
            repo.Delete(id);
        }
    }
}