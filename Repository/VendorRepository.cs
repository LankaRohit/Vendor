using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;

namespace VendorMicroService.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private List<Vendor> vendors;
        private List<VendorStock> vendorstocks;
        private List<VendorDto> vendordto;

        public   VendorRepository()
        {
            vendors = new List<Vendor>()
            {
                new Vendor { VendorId = 1, VendorName = "Reebok",  DeliveryCharge= 100,Rating = 2 },
                  new Vendor { VendorId = 2, VendorName = "Puma", DeliveryCharge = 200, Rating = 3 },
                    new Vendor { VendorId = 3, VendorName = "Adidas", DeliveryCharge = 150, Rating = 3 },

                    new Vendor { VendorId = 4, VendorName = "Nike", DeliveryCharge= 250, Rating = 5 },
                     new Vendor { VendorId = 5, VendorName = "checklast", DeliveryCharge = 300, Rating = 4 },
            };
            vendorstocks = new List<VendorStock>()
            {
                new VendorStock {ProductId=1, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,7,6) },
                 new VendorStock {ProductId=1, VendorId = 2,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,7,6) },
                  new VendorStock { ProductId = 2, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
                    new VendorStock { ProductId = 3,VendorId = 1,StockInHand=0,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },

                    new VendorStock {ProductId = 4,VendorId = 1,StockInHand=0,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
                     new VendorStock {ProductId = 5, VendorId = 1,StockInHand=1,  ExpectedStockReplenishmentDate=new DateTime(2020,6,15) },
            };
        }

            public List<VendorDto> GetVendorDetails(int ProductId)
        {
            var availablevendors = from p in vendorstocks where p.ProductId == ProductId && p.StockInHand >= 1 select p.VendorId;
            List<int> availableist = availablevendors.ToList();

            List<VendorDto> vendorslist = new List<VendorDto>();
            foreach(int i in availableist)
            {
                Vendor matched = vendors.FirstOrDefault(o => o.VendorId == i);

                VendorDto m = new VendorDto() { VendorId = matched.VendorId, VendorName = matched.VendorName, DeliveryCharge = matched.DeliveryCharge, Rating = matched.Rating };
                vendorslist.Add(m);

            }
            
                return vendorslist;
            
            
        

        }
    }
}
