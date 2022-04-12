namespace PortfolioService.Core.Interfaces.DTOs
{
    public record GetTotalPortfolioValueDto
    {
        //string portfolioId, string currency = "USD"
        public string portfolioId { get; set; }
        public string currency { get; set; }
    }
}
