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
        private readonly IEFCoreRepository _repo;

        public BattleController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BattleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var battles = await _repo.GetAllBattles();
                return Ok(battles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BattleController>/5
        [HttpGet("{id}", Name = "GetBattle")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var battle = await _repo.GetBattleById(id, true);
                if (battle != null)
                {
                    return Ok(battle);
                }
                return BadRequest("Not found!");
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // CRUD INSERT

        // POST api/<BattleController>
        [HttpPost]
        public async Task<IActionResult> Post(Battle model)
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

        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Battle model)
        {
            try
            {
                var battle = await _repo.GetBattleById(id);
                if (battle != null)
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

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var battle = await _repo.GetBattleById(id);
                if (battle != null)
                {
                    _repo.Delete(battle);
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
