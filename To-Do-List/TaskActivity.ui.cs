using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Support.Design;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using To_Do_List.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace To_Do_List
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class TaskActivity : AppCompatActivityBase
    {

        private Toolbar _toolbar;

        public Toolbar Toolbar
        {
            get
            {
                return _toolbar
                       ?? (_toolbar = FindViewById<Toolbar>(Resource.Id.toolbar));
            }
        }

        private TextView _title;

        public TextView Title
        {
            get
            {
                return _title
                       ?? (_title = FindViewById<TextView>(Resource.Id.title));
            }
        }

        private TextView _contentLabel;

        public TextView ContentLabel
        {
            get
            {
                return _contentLabel
                       ?? (_contentLabel = FindViewById<TextView>(Resource.Id.content));
            }
        }

        private TextView _content;

        public TextView Content
        {
            get
            {
                return _content
                       ?? (_content = FindViewById<TextView>(Resource.Id.content));
            }
        }

        private DatePicker _date;

        public DatePicker Date
        {
            get
            {
                return _date
                       ?? (_date = FindViewById<DatePicker>(Resource.Id.date));
            }
        }

        private TextView _dateLabel;

        public TextView DateLabel
        {
            get
            {
                return _dateLabel
                       ?? (_dateLabel = FindViewById<TextView>(Resource.Id.dateLabel));
            }
        }

    }
}