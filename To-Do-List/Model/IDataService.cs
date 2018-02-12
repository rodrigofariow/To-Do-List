using System;

namespace To_Do_List.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}