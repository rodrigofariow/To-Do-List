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
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using To_Do_List.Model;

namespace To_Do_List
{
    [Activity(Label = "Task Page", Theme = "@style/AppTheme")]
    public partial class TaskActivity
    {
        Task currentTask;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "Second" layout resource
            SetContentView(Resource.Layout.Task_details);

            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            currentTask = nav.GetAndRemoveParameter(Intent) as Task;

            if(currentTask != null)
            {
                Toast.MakeText(this, currentTask.ToString(), ToastLength.Short).Show();

            }
            // Retrieve navigation parameter and set as current "DataContext"
            //var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            //var p = nav.GetAndRemoveParameter<string>(Intent);

            //if (string.IsNullOrEmpty(p))
            //{
            //    NavigationParameterText.Text = "No navigation parameter";
            //}
            //else
            //{
            //    NavigationParameterText.Text = "Navigation parameter: " + p;
            //}

            //GoBackButton.Click += (s, e) => nav.GoBack();
        }
    }
}