using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Support.Design;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using To_Do_List.Model;

namespace To_Do_List
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class MainActivity : AppCompatActivityBase
    {
        private RecyclerView _tasks;

        public RecyclerView Tasks
        {
            get
            {
                return _tasks
                       ?? (_tasks = FindViewById<RecyclerView>(Resource.Id.ToDoRecyclerView));
            }
        }
       
    }
}