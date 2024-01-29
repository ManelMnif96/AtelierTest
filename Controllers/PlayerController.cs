using AtelierTest.Models;
using AtelierTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Xml.Linq;

namespace AtelierTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PlayerController> _logger;



        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
        {
            _logger = logger;
            this.playerService = playerService;
        }

        [HttpGet]
        [Route("/players")]
        public List<Player> GetPlayers()
        {
            return this.playerService.GetPlayersOrderByRank();
        }

        [HttpGet]
        [Route("/players/{id}")]
        public Player GetPlayerById(int id)
        {
            return this.playerService.GetPlayerById(id);
        }

        [HttpGet]
        [Route("/statistics/wonCountry")]
        public string GetWonCountry()
        {
            return this.playerService.GetWonCountry();
        }

        [HttpGet]
        [Route("/statistics/imc/")]
        public float GetImc()
        {
            return this.playerService.GetIMC();
        }

        [HttpGet]
        [Route("/statistics/median/")]
        public double GetMedian()
        {
            return this.playerService.GetMedian();
        }
        
    }
}
