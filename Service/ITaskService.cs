using TaskAPI.Model;

namespace TaskAPI.Service
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(string title);

        Task<TaskModel> UpdateTask(int taskid,string  title,bool completed);

        Task DeleteTask(int taskid);
    }
}
