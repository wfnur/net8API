using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using net8API.Extentions;
using net8API.Interfaces;
using net8API.Models;

namespace net8API.Controllers
{
    [Route("api/portofolio")]
    [ApiController]
    public class PortofolioController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IportofolioRepository _portofolioRepo;
        public PortofolioController(
            UserManager<AppUser> userManager,
            IStockRepository stockRepo,
            IportofolioRepository portofolioRepo
        )
        {
            _userManager = userManager;
            _stockRepo = stockRepo ;
            _portofolioRepo = portofolioRepo;
        
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortofolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortofolio = await _portofolioRepo.GetUserPortofolio(appUser);
            return Ok(userPortofolio);
        }
    }
}