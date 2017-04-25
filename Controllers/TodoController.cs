using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers {
    //localhost:port/api/todo/*
    [Route("api/[controller]")]
    public class TodoController : Controller {
        private readonly ITodoRepository _todoRepository;
        
        //constructor receives a reference to repository class,
        //stores it in _todoRepository, which cannot be modified
        //after it is set.
        public TodoController(ITodoRepository repository) {
            _todoRepository = repository;
        }
        [HttpGet]
        public IEnumerable<TodoItem> GetAll() {
            return _todoRepository.GetAll();
        }
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id) {
            var item = _todoRepository.Find(id);
            if(item == null) {
                return NotFound(); //404
            }
            //item is serialized by ObjectResult before being returned.
            return new ObjectResult(item);
        }

        //FromBody means item object is found in body of Post request
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item) {
            if(item == null) {
                return BadRequest(); //400
            }
            _todoRepository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item) {
            if(item == null && item.Key != id) {
                return BadRequest();
            }
            var todo = _todoRepository.Find(id);
            if(todo == null) {
                return NotFound();
            }
            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;
            _todoRepository.Update(todo);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var todo = _todoRepository.Find(id);
            if(todo == null) {
                return NotFound();
            }
            _todoRepository.Remove(todo);
            return NoContent();
        }
    }
}