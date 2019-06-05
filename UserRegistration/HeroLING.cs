using System;
using System.Collections.Generic;
using System.Linq;

using UserRegistration;
using UserRegistration.Models;


namespace UserRegistration
{
    public class HeroLING
    {
        private HeroContext heroContext;

        public HeroLING(HeroContext context)
        {
            heroContext = context;
        }

        public void addHero()
        {

            for (int i = 1; i < 15; i++)
            {
                HeroNameGenerator generator = new HeroNameGenerator();
                Random random = new Random();
                
                heroContext.Heros.Add(new Heros
                {
                    HeroID = i,
                    HeroName = generator.getName(),
                    Health = random.Next(0,500),
                    Offense = random.Next(0, 500),
                    Speed = random.Next(0, 500),
                    Defense = random.Next(0, 500),

                });
                heroContext.SaveChanges();
            }
            
        }

        private class HeroNameGenerator {

            string[] HeroNames = {"Jax", "kay", "kayyue", "kaylu", "kayyuelu", "lukay", "lukayyue", "Jinx", "Jayce", "Rammus", "Tan", "Gophi", "Ajet", "Sujin"}; 

            public string getName()
            {
                Random random = new Random();
                int i = random.Next(0, 14);
                return HeroNames.GetValue(i).ToString();
            }
        }

    }
}