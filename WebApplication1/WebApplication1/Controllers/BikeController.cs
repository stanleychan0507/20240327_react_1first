
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Method;
using WebApplication1.Model;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeController : ControllerBase
{
    private readonly BikeStoresContext _context ;
    private readonly GenerateReport _generateReport;

    public BikeController(BikeStoresContext context, GenerateReport generateReport)
    {
        _context        = context;
        _generateReport = generateReport;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> Report(int customerId, string mode)
    {
        // check if customer ID exist 
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

        if (customer is null) return BadRequest("The customer does not exist");

        var result = _generateReport.GenerateReportDto(customerId, mode);

        return Ok(result);

    }
 


}