using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello entity framework!", "23/03/2021" };
        }

        // CRUD SELECT

        // GET api/values
        [HttpGet("filter/{name}")]
        public ActionResult GetFilter(string name)
        {
            //return new string[] { "Hello entity framework!" };

            var listHero = _context.Heroes
                           .Where(h => h.Name.Contains(name))
                           .ToList();

            //var listHero = (from hero in _context.Heroes
            //                where hero.Name.Contains(name)
            //                select hero).ToList();

            // Lembrar de sempre passar para uma variável a lista retornada 
            // do banco de dados antes de usa-la, para que a conexão com o 
            // banco não fique aberta e acabe o travando.

            return Ok(listHero);
        }

        //// CRUD INSERT

        //// GET api/values/5
        //[HttpGet("{nameHero}")]
        //public ActionResult<string> GetInsert(string nameHero) // Insert no GET??? É...
        //{
        //    var hero = new Hero { Name = nameHero };
            
        //    //context.Heroes.Add(hero);
        //    _context.Add(hero);
        //    _context.SaveChanges();

        //    return Ok();
        //}

        // CRUD UPDATE

        // GET api/values/5
        [HttpGet("update/{heroId}/{nameHero}")]
        public ActionResult<string> GetUpdate(int heroId, string nameHero)
        {
            var hero = _context.Heroes.
                        Where(h => h.Id == heroId)
                        .FirstOrDefault();

            hero.Name = nameHero;
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // CRUD DELETE

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        // DELETE api/values/5
        [HttpGet("delete/{id}")]
        public void GetDelete(int id)
        {
            var hero = _context.Heroes
                        .Where(x => x.Id == id)
                        .Single();
            
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
        }
    }
}
