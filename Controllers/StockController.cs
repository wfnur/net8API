using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net8API.Data;
using net8API.DTOs.Stock;
using net8API.Mapper;

namespace net8API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stock = _context.Stocks.ToList()
                .Select(s => s.ToStockDTO());

            return Ok(stock);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDTO());
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            var stockModel = stockDTO.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new {id = stockModel.Id},
                stockModel.ToStockDTO()
            );
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(
            [FromRoute] int id, 
            [FromBody] UpdateStockRequestDTO updateDTO
        )
        {
            var stockModel = _context.Stocks.FirstOrDefault(x=>x.Id ==id);
            if(stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = updateDTO.Symbol;
            stockModel.CompanyName = updateDTO.CompanyName;
            stockModel.Purchase = updateDTO.Purchase;
            stockModel.Industry = updateDTO.Industry;
            stockModel.LastDiv = updateDTO.LastDiv;
            stockModel.MarketCap = updateDTO.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x=>x.Id ==id);
            if(stockModel == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}