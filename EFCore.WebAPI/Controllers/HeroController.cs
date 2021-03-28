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
        private readonly IEFCoreRepository _repo;

        public HeroController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var heroes = await _repo.GetAllHeroes();
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "GetHero")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var hero = await _repo.GetHeroById(id, true);
                if (hero != null)
                {
                    return Ok(hero);
                }
                return BadRequest("Not found!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD INSERT

        // POST api/<HeroController>
        [HttpPost]
        public async Task<IActionResult> Post(Hero model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Success!");
                }
                return BadRequest("Not saved!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD UPDATE

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hero model)
        {
            try
            {
                var hero = await _repo.GetHeroById(id);
                if (hero != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Success!");
                    }
                    return BadRequest("Not saved!");
                }
                return BadRequest("Not updated!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD DELETE

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hero = await _repo.GetHeroById(id);
                if (hero != null)
                {
                    _repo.Delete(hero);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Success!");
                    }
                    return BadRequest("Not saved!");
                }
                return BadRequest("Not deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
