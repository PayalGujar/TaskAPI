using TaskAPI.Model;

namespace TaskAPI.Service
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskModel> tasks = new List<TaskModel>
        {
            new TaskModel{ Id = 1, Title="Task 1",Completed=false},
            new TaskModel{ Id = 2, Title="Task2",Completed=true }
        };
        public async Task<TaskModel> AddTask(string title)
        {
            await Task.Delay(0);
            var newTask=new TaskModel { Id = 1, Title=title,Completed=false};
            tasks.Add(newTask);
            return newTask;
        }

        public async Task DeleteTask(int taskid)
        {
            await Task.Delay(0);
            tasks.RemoveAll(x => x.Id == taskid);
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            await Task.Delay(0);
            return tasks;
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            await Task.Delay(0);
            return tasks.Find(task => task.Id == id);
        }

        public async Task<TaskModel> UpdateTask(int taskid, string title, bool completed)
        {
            await Task.Delay(0);
            var existingTask=tasks.Find(task=>task.Id == taskid);
            if(existingTask != null)
            {
                existingTask.Title = title;
                existingTask.Completed = completed;
                return existingTask;
            }
            return null;
        }
    }
}
