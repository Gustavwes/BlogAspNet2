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
                        FkCategoryId = post.FkCategoryId
                       
                    };

                
                BindingList<PostModel> selectedPosts = new BindingList<PostModel>(postQuery.ToList());
                foreach (var item in selectedPosts)
                {
                    item.FkCategory = GetCategories(item.FkCategoryId);
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

        public CategoryModel GetCategories(int? catId)
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
    }
}
