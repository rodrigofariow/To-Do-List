using System;
using System.Collections.Generic;

namespace To_Do_List.Model
{
    public class TaskService : ITaskService
    {
        public void GetTasks(Action<List<Task>, Exception> callback)
        {
            // Use this to connect to the actual data service
            List<Task> tasksList = new List<Task>();

            tasksList.Add(new Task("Do the dishes", System.DateTime.Now));
            tasksList.Add(new Task("Buy some fruit", System.DateTime.Now));
            tasksList.Add(new Task("Replace the gas bottle"));
            tasksList.Add(new Task("Buy a programmer T-shirt", "One that actually makes you look cool"));
            tasksList.Add(new Task("Buy some fruit", System.DateTime.Now));
            tasksList.Add(new Task("Do the dishes", System.DateTime.Now));
            tasksList.Add(new Task("Buy some fruit", System.DateTime.Now));
            tasksList.Add(new Task("Replace the gas bottle"));
            tasksList.Add(new Task("Buy a programmer T-shirt", "One that actually makes you look cool"));
            tasksList.Add(new Task("Buy some fruit", System.DateTime.Now));
            tasksList.Add(new Task("Do the dishes", System.DateTime.Now));
            tasksList.Add(new Task("Buy some fruit", System.DateTime.Now));
            tasksList.Add(new Task("Replace the gas bottle"));
            callback(tasksList, null);
        }
    }
}