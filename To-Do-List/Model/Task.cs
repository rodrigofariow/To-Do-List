using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json;

namespace To_Do_List.Model
{
    public class Task
    {
        public Task(string title, DateTime date, string content = "")
        {
            Title = title;
            Content = content;
            Date = date;
        }

        public Task(string title, string content = "")
        {
            Title = title;
            Content = content;
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime Date { get; private set; }

    }
}