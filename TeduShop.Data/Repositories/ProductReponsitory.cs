using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Reponsetories
{
    public interface IProductReponsitory
    {

    }
    public class ProductReponsitory : RepositoryBase<Product>,IProductReponsitory
    {
        public ProductReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
