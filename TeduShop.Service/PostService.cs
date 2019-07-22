using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;


namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int ID);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        Post GetByID(int ID);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        /// <summary>
        /// Commit của unit of work
        /// </summary>
        void SaveChanges();
    }
    /// <summary>
    /// Tầng service sẽ tương tác với API
    /// </summary>
    public class PostService : IPostService
    {
        // Biến của class thì thêm đấu gạch dưới
        IPostRepository _postReposotory;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postReposotory = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postReposotory.Add(post);
        }

        public void Delete(int ID)
        {
            _postReposotory.Delete(ID);
        }

        public IEnumerable<Post> GetAll()
        {
            // Lấy ra cả Post và Category của Post đó
            return _postReposotory.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            // TODO: Select all post by Tag
            return _postReposotory.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postReposotory.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetByID(int id)
        {
            return _postReposotory.GetSingleById(id);
        }

        public void Update(Post post)
        {
            _postReposotory.Update(post);
        }

        /// <summary>
        /// Xác nhận các thao tác thêm , sửa , xóa database
        /// </summary>
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

       
       
    }
}
