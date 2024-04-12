using System.Security.Claims;
using BikeStoresApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;


namespace BikeStoresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeStoresController: ControllerBase
    {
        private readonly GenerateReport _service;
        private readonly CustomerService _customerService;
        //private readonly FilterByDate _filterByDate; // yet to DI

        public BikeStoresController(GenerateReport service, CustomerService customerService)
        {
            _service         = service;
            _customerService = customerService;
        }


        // localhost:7045/BikeStores/Report
        [HttpGet("[action]/{customerId}")]
        public IActionResult Report(int customerId, string mode)
        {
            var report = _service.GenerateReportDto(customerId, mode);
            
            return Ok(report);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomersByRange(int id)
        {
            var customers = await _customerService.GetCustomersByRange(id);

            return Ok(customers);

        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> FilterByDate(int id)
        //{
        //    return Ok();
        //}
    }
}
