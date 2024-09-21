using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
using api.Helper;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _db;
        public StockRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
           await _db.Stocks.AddAsync(stock);
           await _db.SaveChangesAsync();
           return stock;
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            var stock = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }
            _db.Stocks.Remove(stock);
            await _db.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject queryObject)
        {
            var stock = _db.Stocks.Include(c => c.Comments).AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryObject.CompanyName))
            {
                stock =  _db.Stocks.Where(c => c.CompanyName.Contains(queryObject.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(queryObject.Symbol))
            {
                stock = _db.Stocks.Where(c => c.Symbol.Contains(queryObject.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if(queryObject.SortBy.Contains("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stock = queryObject.IsDesending ? stock.OrderByDescending(s => s.Symbol) : stock.OrderBy(s => s.Symbol);
                }
            }

            int skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;
            return await stock.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _db.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
            if(stock == null)
                return null;
            return stock;
        }

        public async Task<Stock> UpdateAsync(int id, UpDateStockDto updateStock)
        {
            var stock = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if(stock == null)
                return null;
            stock.Purchase = updateStock.Purchase;
            stock.MarketCap = updateStock.MarketCap;
            stock.LastDiv = updateStock.LastDiv;
            stock.Industry = updateStock.Industry;
            stock.CompanyName = updateStock.CompanyName;
            stock.Symbol = updateStock.Symbol;
            await _db.SaveChangesAsync();
            return stock;
        }
    }
}