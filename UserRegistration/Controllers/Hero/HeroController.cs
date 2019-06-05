using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;


namespace UserRegistration.Controllers.Hero
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext HeroContext;
        public HeroController(HeroContext heroContext)
        {
            HeroContext = heroContext;
        }

        [EnableCors]
        [HttpGet]

        public async Task<Object> Get()
        {
            var Hero = from Heros in HeroContext.Heros
                       
                       select Heros;
            return await Hero.ToListAsync();
        }



        [EnableCors]
        [HttpPost]

        public async Task<Object> AddHero(Heros hero )
        {
            HeroContext.Heros.Add(hero);
            return await HeroContext.SaveChangesAsync();
        }

        [EnableCors]
        [HttpPut("{id}")]

        public async Task<Object> putHero(int id, Heros hero)
        {
            if( id != hero.HeroID)
            {
                return BadRequest();
            }

            HeroContext.Entry(hero).State = EntityState.Modified;

            try
            {
                await HeroContext.SaveChangesAsync();
            }
            catch
            {
                
            }
            return Ok();
        }

        [EnableCors]
        [HttpDelete("{id}")]
        public async Task<Object> Delete(int id)
        {
            var hero = await HeroContext.Heros.FindAsync(id);
            if(hero == null)
            {
                return NotFound();
            }
            HeroContext.Heros.Remove(hero);
            await HeroContext.SaveChangesAsync();

            return Ok();
        }

        [EnableCors]
        [HttpPost]
        [Route("Search")]
        [Authorize]
        public async Task<Object> Search(filter String)
        {

            var hero = from Hero in HeroContext.Heros
                       where Hero.HeroName.Contains(String.condition)
                       select Hero;

            return await hero.ToListAsync();
        }


    }
}