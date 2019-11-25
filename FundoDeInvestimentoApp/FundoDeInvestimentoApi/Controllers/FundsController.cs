using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundoDeInvestimentoApi.Data;
using FundoDeInvestimentoApi.Model;

namespace FundoDeInvestimentoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly DataContext _context;

        public FundsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Funds
        [HttpGet]
        public async Task<IEnumerable<Fund>> GetFundsAsync()
        {
            return await _context.Funds.ToListAsync();
        }

        // GET: api/Funds/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetFund(string name)
        {
            var fund = await _context.Funds.Where(f => f.Name.Equals(name)).ToListAsync();
            return fund;
        }

        // POST: api/Funds
        [HttpPost]
        public async Task<IActionResult> PostFund([FromBody] Fund fund)
        {
            fund.Date = DateTime.Now;
            _context.Funds.Add(fund);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFund", new { Name = fund.Name }, fund);
        }
    }
}