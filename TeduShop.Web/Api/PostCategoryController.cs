using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategoryService ) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        /// <summary>
        /// Select post category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // Kiểm tra validate theo các trường trong PostCategory
                //if (ModelState.IsValid)
                //{
                //    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                //}
                //else
                //{
                //    var listCategory = _postCategoryService.GetAll();
                //    response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                //}
                var listCategory = _postCategoryService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }


        /// <summary>
        /// Create post category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postCategory"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // Kiểm tra validate theo các trường trong PostCategory
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    var category =_postCategoryService.Add(postCategory);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        /// <summary>
        /// Update post category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postCategory"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // Kiểm tra validate theo các trường trong PostCategory
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        /// <summary>
        /// Delete post category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postCategory"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                // Kiểm tra validate theo các trường trong PostCategory
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }


    }
}