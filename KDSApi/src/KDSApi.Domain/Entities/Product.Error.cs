namespace KDSApi.Domain.Entities
{
    public partial class Product
    {
        public enum Error
        {
            ProductShouldHaveDescription,
            ProductShouldHaveValue
        }
    }
}
