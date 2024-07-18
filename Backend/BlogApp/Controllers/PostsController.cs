using BlogApp.Data;
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers{

    public class PostsController : Controller{

        private IPostRepository _repository;
        public PostsController(IPostRepository repository){
            _repository = repository;
        }
        public IActionResult Index(){
            return View(_repository.Posts.ToList());
        }
    }
}