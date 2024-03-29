﻿using BlogProject.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Service
{
   public  class EntityService
    {
        public EntityService()
        {
            _categoryService = new CategoryRepository();
            _appuserService = new AppUserRepository();
            _articleService = new ArticleRepository();
            _commentService = new CommentRepository();
            _likeService = new LikeRepository();
        }

        private CategoryRepository _categoryService;
        public CategoryRepository CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private AppUserRepository _appuserService;
        public AppUserRepository AppUserService
        {
            get { return _appuserService; }
            set { _appuserService = value; }
        }

        private ArticleRepository _articleService;
        public ArticleRepository ArticleService
        {
            get { return _articleService; }
            set { _articleService = value; }

        }

        private CommentRepository _commentService;
        public CommentRepository CommentService
        {
            get { return _commentService; }
            set { _commentService = value; }
        }

        private LikeRepository _likeService;
        public LikeRepository LikeService
        {
            get { return _likeService; }
            set { _likeService = value; }
        }
    }
}
