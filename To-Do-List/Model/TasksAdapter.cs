using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace To_Do_List.Model
{
    class TasksAdapter : RecyclerView.Adapter
    {

        public List<Task> TasksList { get; private set; }

        public class MyViewHolder : RecyclerView.ViewHolder
        {
            public MyViewHolder(View view) : base(view)
            {
                Title = (TextView)view.FindViewById(Resource.Id.title);
                Date = (TextView)view.FindViewById(Resource.Id.date);
            }

            public TextView Title { get; private set; }
            public TextView Date { get; private set; }
        }


        public TasksAdapter(List<Task> tasksList)
        {
            TasksList = tasksList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.task_list_row, parent, false);

            return new MyViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Task task = TasksList[position];
            var mv = holder as MyViewHolder;
            mv.Title.Text = task.Title;
            mv.Date.Text = task.Date.HasValue ? ((DateTime)task.Date).ToShortDateString() : "";
        }

        public override int ItemCount
        {
            get { return TasksList.Count; }
        }
    }
}