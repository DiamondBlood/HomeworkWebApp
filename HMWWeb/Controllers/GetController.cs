using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL3.Models;

namespace HMWWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetController : Controller
    {
        [HttpGet("getMonstersName")]
        public string[] GetAllMonsters()
        {
            return new string[]
                 { "Endrega warrior", "Bruxa", "Basilisks", "Viverna", "Ghoul", "Ice troll", "Rock troll" };

        }

        [HttpGet("getAllMonsterInfo")]
        public List<Monster> GetAllMonstersInfo()
        {
            return new List<Monster>()
            {
                new Monster()
                {
                    Name = "Basilisk",
                    Class = "Draconid",
                    Damage =1200
                },
                new Monster()
                {
                    Name = "Endrega worker",
                    Class = "Insectoid",
                    Damage = 300
                },
                new Monster()
                {
                    Name = "Cyclopse",
                    Class = "Ogroid",
                    Damage = 1000
                },
                new Monster()
                {
                    Name = "Dettlaff van der Eretein",
                    Class = "Vampire",
                    Damage = 800
                }
            };
        }
    }
}
