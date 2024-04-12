

namespace BikeStoresApplication.Dto
{
    public class ReportBrandDTO : IReportDto
    {
        public int CustomerId { get; set; }
        public string Mode { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalCountofBrands { get; set; }
        public decimal AvgPriceForBrands { get; set; }
        public List<BrandDetail> BrandDetails { get; set; }
    }

    public class BrandDetail
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}

