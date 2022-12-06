using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Base;
using WebAPi.Context;
using WebAPi.Models;
using WebAPi.Repositories.Data;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<CategoryRepository, Category>
    {
        private CategoryRepository _categoryRepository;
       
        public CategoryController(CategoryRepository repository) : base(repository)
        {
            _categoryRepository = repository;
            
        }
       
    }
}
