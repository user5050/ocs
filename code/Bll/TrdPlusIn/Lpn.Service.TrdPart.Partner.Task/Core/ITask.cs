namespace Lpn.Service.TrdPart.Partner.Task.Core
{
    public interface ITask
    {
        void Run();

        int GetRunInterval();

        string GetTaskId(); 
    }
}
