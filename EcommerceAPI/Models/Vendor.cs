namespace EcommerceAPI.Models
{
    public class Vendor
    {
        internal int Id;
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
