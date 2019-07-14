using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        // Hàm này sẽ thực thi khởi tạo DbContext
        TeduShopDbContext Init();
    }
}
