namespace EcommerceAPI.Models
{
    public class Vendor
    {
        internal int Id;
        public int VendorId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
