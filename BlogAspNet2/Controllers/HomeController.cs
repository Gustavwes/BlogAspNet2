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
                else
                {
                    postModel.FkCategoryId = postList.Max(x => x.FkCategoryId) + 1;
                }
            }
            dataAccess.CreateNewPost(postModel.Title,postModel.Post,postModel.FkCategoryId);
            return View();
        }
    }


    
}