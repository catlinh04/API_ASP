using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
using api.Helper;
using api.Models;

namespace api.Interface
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync(QueryObject queryObject);
       public Task<Stock?> GetByIdAsync(int id);
       public Task<Stock> CreateAsync(Stock stock);
       public Task<Stock> UpdateAsync(int id, UpDateStockDto stock);

       public Task<Stock> DeleteAsync(int id);
    }
}