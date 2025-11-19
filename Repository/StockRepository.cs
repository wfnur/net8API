using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net8API.Data;
using net8API.DTOs.Stock;
using net8API.Interfaces;
using net8API.Models;

namespace net8API.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;

        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x=>x.Id ==id);
            if(stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(x=>x.Comments).ToListAsync();
        }

        public async Task<Stock?> GetStockByidAsync(int id)
        {
            return await _context.Stocks.Include(x=>x.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDTO stockDTO)
        {
            var existStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(existStock == null)
            {
                return null;
            }

            existStock.Symbol = stockDTO.Symbol;
            existStock.CompanyName = stockDTO.CompanyName;
            existStock.Purchase = stockDTO.Purchase;
            existStock.Industry = stockDTO.Industry;
            existStock.LastDiv = stockDTO.LastDiv;
            existStock.MarketCap = stockDTO.MarketCap;
            await _context.SaveChangesAsync();
            
            return existStock;
            
        }
    }
}