using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest 
    {
        // Kí thuật này giúp chúng ta test được các chức năng mặc dù chưa hoàn thiện các modun
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private PostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() { ID = 1, Name = "DM1", Status = true},
                new PostCategory() { ID = 2, Name = "DM2", Status = true },
                new PostCategory() { ID = 3, Name = "DM3", Status = true },
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            // Mock --> Tức là giả lập một list mẫu cho trước, giả sử repository lấy được list đó rồi thì ta check xem service có GetAll lại được nữa không
            // Nếu muốn test kết nối sql thì test repository là đủ
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);
            
            //call action
            // Check hàm GetAll của service 
            var result = _categoryService.GetAll() as List<PostCategory>;
            
            //compare
            // So sánh list đầu ra có giống với list cho trước
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory();
            int id = 1;
            postCategory.Name = "Test";
            postCategory.Alias = "test";
            postCategory.Status = true; 
            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            var result = _categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}