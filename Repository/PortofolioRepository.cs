using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net8API.Data;
using net8API.Interfaces;
using net8API.Models;

namespace net8API.Repository
{
    public class PortofolioRepository : IportofolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortofolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortofolio(AppUser user)
        {
            return await _context.Portofolios.Where(u => u.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.Stock.Id,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap
                }).ToListAsync();
        }
    }
}