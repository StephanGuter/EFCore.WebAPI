using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        public readonly HeroContext _context;

        public HeroController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<HeroController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Hero());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "GetHero")]
        public ActionResult Get(int id)
        {
            return Ok(id);
        }

        // CRUD INSERT

        //// POST api/<HeroController>
        //[HttpPost]
        //public ActionResult Post()
        //{
        //    try
        //    {
        //        var hero = new Hero
        //        {
        //            Name = "Ironman",
        //            Weapons = new List<Weapon>
        //            {
        //                new Weapon { Name = "Mac 3" },
        //                new Weapon { Name = "Mac 5" }
        //            }
        //        };

        //        _context.Heroes.Add(hero);
        //        _context.SaveChanges();

        //        return Ok("Bazinga");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex}");
        //    }
        //}

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Hero model)
        {
            try
            {
                _context.Heroes.Add(model);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD UPDATE

        //// PUT api/<HeroController>/5
        //[HttpPut("{id}")]
        //public ActionResult Put(int id)
        //{
        //    try
        //    {
        //        var hero = new Hero
        //        {
        //            Id = id,
        //            Name = "Ironman",
        //            Weapons = new List<Weapon>
        //            {
        //                new Weapon { Id = 1, Name = "Mark III" },
        //                new Weapon { Id = 2, Name = "Mark V" }
        //            }
        //        };

        //        //_context.Heroes.Update(hero);
        //        _context.Update(hero);
        //        _context.SaveChanges();

        //        return Ok("Bazinga");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro: {ex}");
        //    }
        //}

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Hero model)
        {
            try
            {
                //if(_context.Heroes.Find(id) != null)
                if (_context.Heroes.AsNoTracking()
                    .FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("Bazinga");
                }
                return Ok("Not found!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
