using Microsoft.AspNetCore.Mvc;
using TaskAPI.Model;
using TaskAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;

        public TaskController(ITaskService service)
        {
            this.service = service;
        }

    
        // GET: api/<TaskController>
        [HttpGet]
        [Route("GetTasks")]
        public async Task<ActionResult<List<TaskModel>>> Get()
        {
            var tasks= await service.GetAllTasks();
            return Ok(tasks);
        }

        // GET api/<TaskController>/5
        [HttpGet]
        [Route("GetTaskById/{id}")]
        public async Task<ActionResult<TaskModel>> Get(int id)
        {
           var task=await service.GetTaskById(id);
            if(task!=null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        // POST api/<TaskController>
        [HttpPost]
        [Route("AddTask")]
        public async Task<ActionResult<TaskModel>> Post([FromBody] TaskModel taskModel)
        {
           if(string.IsNullOrWhiteSpace(taskModel.Title))
            {
                return BadRequest();
            }
            var newTask = await service.AddTask(taskModel.Title);
            return Ok(newTask);
           // return CreatedAtAction(nameof(service.GetTaskById), new {taskid=newTask.Id}, newTask);
        }

        

        // PUT api/<TaskController>/5
        [HttpPut]
        [Route("UpdateTask/{id}")]
        public async Task<ActionResult<TaskModel>> Put(int id, [FromBody] TaskModel taskModel)
        {
            var updatedTask = await service.UpdateTask(id, taskModel.Title, taskModel.Completed);
            if(updatedTask!=null)
            {
                return Ok(updatedTask);
            }
            return NotFound();
        }

        // DELETE api/<TaskController>/5
        [HttpDelete]
        [Route("deleteTask/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteTask(id);
            return NoContent();
        }
    }
}
