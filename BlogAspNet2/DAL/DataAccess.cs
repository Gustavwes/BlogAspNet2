using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlogAspNet2.Models;

namespace BlogAspNet2.DAL
{
    public class DataAccess
    {
        //public PostModel GetSinglePost(int postId)
        //{
        //    using (var dataContext = new BlogAspNetContext())
        //    {
        //        var postquery = from post in dataContext.Post
        //                        where post.Id == postId
        //            select new PostModel()
        //            {
        //                Post = post.Post1,
        //                Title = post.Title,
        //                Datetime = post.Datetime,
        //                FkCategoryId = post.FkCategoryId,
        //                Id = post.Id
                        
        //            };
        //        PostModel selectedPost = postquery.SingleOrDefault(x => x.Id == postId);
        //        return selectedPost;
        //    }
            

        //}
        public BindingList<PostModel> GetAllPosts()
        {
            
            using (var dataContext = new BlogAspNetContext())
            {
                var postQuery = from post in dataContext.Post
                    
                    select new PostModel()

                    {
                        Post = post.Post1,
                        Title = post.Title,
                        Datetime = post.Datetime,
                        FkCategoryId = post.FkCategoryId,
                        Id = post.Id
                       
                    };

                
                BindingList<PostModel> selectedPosts = new BindingList<PostModel>(postQuery.ToList());
                foreach (var item in selectedPosts)
                {
                    item.FkCategory = GetCategory(item.FkCategoryId);
                }
                return selectedPosts;
            }
            
        }

        public void CreateNewPost(string title, string post, int? categoryId)
        {
            using (var dataContext = new BlogAspNetContext())
            {
                var newPost = new Post();
                newPost.Post1 = post;
                newPost.Datetime = DateTime.Now;
                newPost.Title = title;
                newPost.FkCategoryId = categoryId;
                
                

                dataContext.Add(newPost);
                dataContext.SaveChanges();
            }
        }

        //public BindingList<PostModel> SearchPosts(string searchValue)
        //{
        //    var resultList = new BindingList<PostModel>();

        //    using (var dataContext = new BlogAspNetContext())
        //    {
        //        var postQuery = from post in dataContext.Post
        //                        where post.Post1.Contains(searchValue)
        //                            || post.Title.Contains(searchValue)
        //                              select new PostModel()
        //                              {

        //                Post = post.Post1,
        //                Title = post.Title,
        //                Datetime = post.Datetime,
        //                FkCategoryId = post.FkCategoryId,
        //                Id = post.Id

        //            };


        //        BindingList<PostModel> selectedPosts = new BindingList<PostModel>(postQuery.ToList());
        //        foreach (var item in selectedPosts)
        //        {
        //            item.FkCategory = GetCategory(item.FkCategoryId);
        //        }
        //        return selectedPosts;
        //    }
        //}

        public void CreateNewCategory(string catName)
        {
            using (var dataContext = new BlogAspNetContext())
            {
                var newCategory = new Category();
                newCategory.Name = catName;
                dataContext.Add(newCategory);
                dataContext.SaveChanges();
            }
        }

        public CategoryModel GetCategory(int? catId)
        {
            var categoryModel = new CategoryModel();                                                                                      
            using (var dataContext = new BlogAspNetContext())
            {
                var categoryQuery = from category in dataContext.Category
                    where category.Id == catId
                    select new CategoryModel()
                    {
                        Id = category.Id,
                        Name = category.Name
                    };
                categoryModel = categoryQuery.SingleOrDefault();
                return categoryModel;
            }
            
        }

        public int GetNewCategoryId()
        {
            using (var dataContext = new BlogAspNetContext())
            {
                int maxCatId = dataContext.Category.Max(x => x.Id);

                return maxCatId;
            }
        }
    }
}
