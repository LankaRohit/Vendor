using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;
using VendorMicroService.Repository;

namespace VendorMicroService.Provider
{
    public class VendorProvider:IVendorProvider
    {
        private readonly IVendorRepository venrepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorProvider));
        public VendorProvider(IVendorRepository _venrepository)
        {
            venrepository = _venrepository;
        }
        public List<Vendor> GetDetailsOfVendor(int ProductId)

        {
            try
            {

                _log4net.Info(" Http GET in provider is accesed");
                return venrepository.GetVendorDetails(ProductId);
            }
            catch (Exception)
            {
                _log4net.Error("error in get request");
                return null;
               
            }
        }
    }
}
