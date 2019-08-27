using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        /// <summary>
        /// Hàm khởi tạo chạy đầu tiên, thiếp lập các tham số, đối tượng (chú ý không phải constructor)
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        /// <summary>
        /// Test chức năng tạo đối tượng PostCategory
        /// Chú ý convention: Tên đối tượng - Thư mục - Method
        /// </summary>
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category second";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();
            // Test bằng đối tượng Assert của UnitTesing namespace
            Assert.IsNotNull(result);
            Assert.AreEqual(17,category.ID);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            // ToList() là của linq
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(5, list.Count());
        }
    }
}
