using System;
using System.Collections.Generic;

namespace To_Do_List.Model
{
    public interface ITaskService
    {
        void GetTasks(Action<List<Task>, Exception> callback);
    }
}