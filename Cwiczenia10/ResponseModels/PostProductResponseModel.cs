namespace Cwiczenia10.ResponseModels;

public class PostProductResponseModel
{
    public string productName { get; set; }
    public decimal productWeight { get; set; }
    public decimal productWidth { get; set; }
    public decimal productHeight { get; set; }
    public decimal productDepth { get; set; }
    public IEnumerable<int> productCategories { get; set; }
}