using Microsoft.AspNetCore.Mvc;
using WebAPi.Repositories.Interface;

namespace WebAPi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = repository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        message = "Data hasn't been Retrieved"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Data has been Retrieved",
                        StatusCode = 200,
                        data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var data = repository.GetById(Id);
                if (data == null)
                {
                    return Ok(new
                    {
                        message = "Data hasn't been Retrieved"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Data has been Retrieved",
                        statusCode = 200,
                        data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            try
            {
                var data = repository.Create(entity);
                if (data == null)
                {
                    return Ok(new
                    {
                        message = "Data hasn't been Created"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Data has been Created",
                        StatusCode = 200,
                        data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            try
            {
                var data = repository.Update(entity);
                if (data == null)
                {
                    return Ok(new
                    {
                        message = "Data hasn't been Updated"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Data has been Updated",
                        statusCode = 200,
                        data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = repository.Delete(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        message = "Data hasn't been Deleted"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Data has been Deleted",
                        statusCode = 200,
                        data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
    }
}
