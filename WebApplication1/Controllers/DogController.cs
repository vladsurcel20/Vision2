using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using Microsoft.AspNetCore.HttpLogging;
using System.Drawing;

namespace WebApplication1.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;

        public DogController(DogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_dogService.GetAll());
 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(_dogService.IsIdUsed(id) == false)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(_dogService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Dog dog)
        {
            if (!_dogService.IsIdUnique(dog.Id))
            {
                return BadRequest("Id in use");
            }
            _dogService.Add(dog);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_dogService.IsIdUsed(id))
            {
                _dogService.Remove(id);
                return Ok();
            }
            return BadRequest("Invalid Id");
        }


        [HttpPut]
        public IActionResult Put(Dog dog)
        {
             if(_dogService.IsIdUsed(dog.Id) == false)
            {
                return BadRequest("Invalid Id");
            }
            _dogService.Update(dog);
            return Ok();
        }

        [HttpGet("GetOdd")]

        public IActionResult GetOdd()
        {
            return Ok(_dogService.GetOdd());
        }

        [HttpGet("PageItems")]
        
        public IActionResult GetItems(int page, int items)
        {
            return Ok(_dogService.GetPage(page, items));
        }
    }
}
