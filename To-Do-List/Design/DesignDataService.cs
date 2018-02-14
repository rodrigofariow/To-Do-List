using System;
using System.Collections.Generic;
using To_Do_List.Model;

namespace To_Do_List.Design
{
    public class DesignDataService : ITaskService
    {
      public void GetTasks(Action<List<Task>, Exception> callback)
        {
            // Use this to create design time data
            throw new NotImplementedException();
        }
    }
}