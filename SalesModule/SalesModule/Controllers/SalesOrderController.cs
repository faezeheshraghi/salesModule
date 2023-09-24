using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesModule.Data;
using SalesModule.Models;

namespace SalesModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private IRepository<SalesOrder> _SalesOrderRepository;

        public SalesOrderController(IRepository<SalesOrder> SalesOrderRepository)
        {
            _SalesOrderRepository = SalesOrderRepository;
        }
        [HttpGet]
        [Route("GetAllSalesOrders")]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetAllSalesOrders()
        {
            return Ok(await _SalesOrderRepository.GetAllAsync());
        }
       
        [HttpPost]
        [Route("AddSalesOrder")]
        public async Task<IActionResult> AddSalesOrder([FromBody] SalesOrder SalesOrder)
        {
            _SalesOrderRepository.Add(SalesOrder);
            return Ok(await _SalesOrderRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateSalesOrder")]
        public async Task<IActionResult> UpdateSalesOrder([FromBody] SalesOrder SalesOrder)
        {
            _SalesOrderRepository.Update(SalesOrder);
            return Ok(await _SalesOrderRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteSalesOrder")]
        public async Task<IActionResult> DeleteSalesOrder(Int64 id)
        {
            await _SalesOrderRepository.Delete(id);
            return Ok(await _SalesOrderRepository.SaveChangesAsync());
        }
    }
}
