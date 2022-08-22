using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Testing");

            Seller s1 = new Seller(1, "Bob", "@gmail", new System.DateTime(1998, 4, 21), 1000, d1);

            SalesRecord sr1 = new SalesRecord(1, new System.DateTime(), 11000, Models.Enums.SalesStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(sr1);

            _context.SaveChanges();
        }
    }
}
