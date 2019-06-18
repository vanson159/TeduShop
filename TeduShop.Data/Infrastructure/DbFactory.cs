namespace TeduShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TeduShopDbContext dbContext;

        /// <summary>
        /// Hàm khởi tạo một dbContext
        /// Check null, nếu null mới được khởi tạo
        /// </summary>
        /// <returns>DBContext</returns>
        public TeduShopDbContext Init()
        {
            return dbContext ?? (dbContext = new TeduShopDbContext());
        }

        /// <summary>
        /// Huy DbContext
        /// </summary>
        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}