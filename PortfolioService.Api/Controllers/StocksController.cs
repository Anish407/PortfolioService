using System;
using System.Net.Http;
using System.Threading.Tasks;
using CodeTest.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PortfolioService.Core.Implementations.Handler;
using PortfolioService.Core.Interfaces.DTOs;

namespace CodeTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        // need to handle exceptions better.. Would have created a middleware to handle exceptions. 
        private IStockHandler _stockHandler { get; }

        public PortfolioController(IStockHandler stockHandler) => _stockHandler = stockHandler;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => Ok(await _stockHandler.GetPortfolio(id));

        [HttpGet("/value")]
        public async Task<IActionResult> GetTotalPortfolioValue(string portfolioId, string currency = "USD")
         => Ok(await _stockHandler.GetTotalPortfolioValue(new GetTotalPortfolioValueDto
         {
             currency = currency,
             portfolioId = portfolioId
         }));

        [HttpDelete("/delete")]
        public async Task<IActionResult> DeletePortfolio(string portfolioId)
        {
            await _stockHandler.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}