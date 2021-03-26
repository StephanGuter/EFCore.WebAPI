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
    public class BattleController : ControllerBase
    {
        public HeroContext _context { get; }

        public BattleController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<BattleController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Battle());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BattleController>/5
        [HttpGet("{id}", Name = "GetBattle")]
        public ActionResult Get(int id)
        {
            return Ok(id);
        }

        // CRUD INSERT

        // POST api/<BattleController>
        [HttpPost]
        public ActionResult Post(Battle model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();

                return Ok("Success!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD UPDATE

        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Battle model)
        {
            try
            {
                if (_context.Battles.AsNoTracking()
                   .FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("Success!");
                }
                return Ok("Not found!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
