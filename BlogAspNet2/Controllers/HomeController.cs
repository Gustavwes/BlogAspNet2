﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAspNet2.DAL;
using BlogAspNet2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAspNet2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult StartView()
        {

            DataAccess dataAccess = new DataAccess();
            List<PostModel> allPosts = dataAccess.GetAllPosts().ToList();

            
            return View(allPosts);
        }

        public IActionResult NewPost()
        {
            return View();
        }

        public IActionResult SubmitPost(PostModel postModel)
        {
            DataAccess dataAccess = new DataAccess();
            var postList = dataAccess.GetAllPosts();
            foreach (var item in postList)
            {
                if (item.FkCategory.Name == postModel.FkCategory.Name)
                {
                    postModel.FkCategoryId = item.FkCategoryId;
                }
               
            }
            if(postModel.FkCategoryId == null)
            {
                dataAccess.CreateNewCategory(postModel.FkCategory.Name);

                postModel.FkCategoryId = dataAccess.GetNewCategoryId();


            }
            dataAccess.CreateNewPost(postModel.Title,postModel.Post,postModel.FkCategoryId);
            return View();
        }

        public IActionResult SelectSinglePost(int postId)
        {
            var dataAccess = new DataAccess();
            var selectedPost = dataAccess.GetSinglePost(postId);
            return View(selectedPost);
        }
        [HttpPost]
        public IActionResult SearchResults(string searchValue)
        {
            DataAccess dataAccess = new DataAccess();
            List<PostModel> allPosts = dataAccess.SearchPosts(searchValue).ToList();


            return View(allPosts);
        }
    }


    
}