using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesModule.Data;
using SalesModule.Models;

namespace SalesModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderLineController : ControllerBase
    {
        private IRepository<SalesOrderLine> _SalesOrderLineRepository;

        public SalesOrderLineController(IRepository<SalesOrderLine> SalesOrderLineRepository)
        {
            _SalesOrderLineRepository = SalesOrderLineRepository;
        }
        [HttpGet]
        [Route("GetAllSalesOrderLinesLine")]
        public async Task<ActionResult<IEnumerable<SalesOrderLine>>> GetAllSalesOrderLinesLine()
        {
            return Ok(await _SalesOrderLineRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetSalesOrderLineById/{id}")]
        public async Task<ActionResult<SalesOrderLine>> GetSalesOrderLineById(Int64 id)
        {
            return Ok(await _SalesOrderLineRepository.GetByIdAsync(id));
        }


        [HttpPost]
        [Route("AddSalesOrderLine")]
        public async Task<IActionResult> AddSalesOrderLine([FromBody] SalesOrderLine SalesOrderLine)
        {
            _SalesOrderLineRepository.Add(SalesOrderLine);
            await _SalesOrderLineRepository.SaveChangesAsync();
            //return Ok(await _SalesOrderLineRepository.SaveChangesAsync());
            return CreatedAtAction(nameof(AddSalesOrderLine), new { id = SalesOrderLine.Id }, SalesOrderLine);
        }
        [HttpPut]
        [Route("UpdateSalesOrderLine")]
        public async Task<IActionResult> UpdateSalesOrderLine([FromBody] SalesOrderLine SalesOrderLine)
        {
            _SalesOrderLineRepository.Update(SalesOrderLine);
            return Ok(await _SalesOrderLineRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteSalesOrderLine")]
        public async Task<IActionResult> DeleteSalesOrderLine(Int64 id)
        {
            await _SalesOrderLineRepository.Delete(id);
            return Ok(await _SalesOrderLineRepository.SaveChangesAsync());
        }
    }
}
