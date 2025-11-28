using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using net8API.DTOs.Stock;
using net8API.Helpers;
using net8API.Models;

namespace net8API.Interfaces
{
    public interface IStockRepository
    { 
        Task<List<Stock>> GetAllAsync(QueryObject queryObject);
        Task<Stock?> GetStockByidAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock> UpdateAsync(int id,UpdateStockRequestDTO stockDTO);
        Task<Stock> DeleteAsync(int id);
        Task<bool> StockExistsAsync(int id);
    
    
        
    }
}