using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoinJar.api.Services;
using Kye.CoinJar.Api.Models;

namespace CoinJar.Api.Controllers
{
    [Route("api/coin/[controller]")]
    [ApiController]
    [Authorize]
    public class CoinController : ControllerBase
    {

        private readonly ICoinService coinService;
        private readonly ILogger logger;

        public CoinController(ICoinService coinService, ILogger<CoinController> logger)
        {
            this.coinService = coinService;
            this.logger = logger;
        }


        [HttpGet("getTotalCoins")]
        public IActionResult GetTotalCoins()
        {
            var totalCoins = coinService.GetTotalCoins();
            return Ok(totalCoins);
        }

        [HttpPost("addCoin")]
        public IActionResult AddCoins([FromBody] CoinDetails coinDetails)
        {

            return Ok(coinService.AddCoins(coinDetails));
        }

        [HttpPut("resetCoins")]
        public IActionResult ResetCoins()
        {
            return Ok(coinService.ResetCoins());
        }
    }
}
