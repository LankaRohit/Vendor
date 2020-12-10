using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;

namespace VendorMicroService.Repository
{
    public interface IVendorRepository
    {
        public List<Vendor> GetVendorDetails(int ProductId);
        
    }
}
