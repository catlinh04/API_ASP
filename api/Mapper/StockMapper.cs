using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Symbol = stock.Symbol,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Purchase = stock.Purchase,
                Comments = stock.Comments.Select(x => x.ToCommentDto()).ToList(),
            };
        }

        public static Stock CreateStock(this CreateStockDto stock)
        {
            return new Stock
            {
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Symbol = stock.Symbol,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Purchase = stock.Purchase
            };
        }

    }
}