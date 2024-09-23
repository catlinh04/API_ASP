using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
using api.Helper;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _repo; 
       
        public StockController(IStockRepository repo)
        {
           
            _repo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _repo.GetAllAsync(queryObject);
            var stockDtos = stocks.Select(s => s.ToStockDto());
            return Ok(stockDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _repo.GetByIdAsync(id);
            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto stock)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newStock = stock.CreateStock();
            await _repo.CreateAsync(newStock);
            return CreatedAtAction(nameof(Get), new {id = newStock.Id}, newStock.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpDateStockDto stock)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   
            var updateStock = await _repo.UpdateAsync(id, stock);
            return Ok(updateStock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public  async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deleteStock = await _repo.DeleteAsync(id);
            return Ok(deleteStock);
        }
    }
}