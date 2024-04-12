using System.Data;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.Serialization;
using WebApplication1.DTO;

namespace WebApplication1.Method
{
    public class GenerateReport : IReportDto
    {
        private readonly GenerateResult _generateResult;

        public GenerateReport(GenerateResult generate)
        {
            _generateResult = generate;
        }
        internal IReportDto GenerateReportDto(int customerId, string mode)
        {
            

           
            IReportDto result = mode switch
            {
                    "product" => _generateResult.GenerateProductReport(customerId, mode),

                    "brand" => _generateResult.GenerateBrandReport(customerId, mode),

                    "category" => _generateResult.GenerateCategoryReport(customerId, mode),

                    _ => throw new NoNullAllowedException(),

            };
            return result;
        }
    }
}

