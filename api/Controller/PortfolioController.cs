using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Microsoft.AspNetCore.Components.Route("api/portfolio")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager; 
        private readonly IStockRepository _stockRepository;

        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
        }


        

    }
}