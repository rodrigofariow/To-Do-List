using System.Collections.Generic;
using Android.App;
using Android.OS;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using JimBobBennett.MvvmLight.AppCompat;
using To_Do_List.ViewModel;
using Messenger = GalaSoft.MvvmLight.Messaging.Messenger;
using Android.Support.V7.Widget;
using To_Do_List.Model;
using Android.Widget;
using Android.Content;
using Newtonsoft.Json;
using System;

namespace To_Do_List
{
    [Activity(Label = "TODO", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public partial class MainActivity
    {

        private ObservableRecyclerAdapter<Task, CachingViewHolder> _adapter;
        private List<Task> tasksList = new List<Task>();
        private RecyclerView _taskRecyclerView;
        private TasksAdapter tAdapter;
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

        private void BindViewHolder(CachingViewHolder holder,
                    Task taskModel,
                    int position)
        {
            var title = holder.FindCachedViewById<TextView>(Resource.Id.title);
            title.Text = taskModel.Title;

            var date = holder.FindCachedViewById<TextView>(Resource.Id.date);
            date.Text = taskModel.Date.HasValue ? ((DateTime)taskModel.Date).ToShortDateString() : "";
        }

        public RecyclerView TaskRecyclerView
        {
            get
            {
                return _taskRecyclerView ??
                  (_taskRecyclerView = FindViewById<RecyclerView>(
                        Resource.Id.ToDoRecyclerView));
            }
        }

        private MainViewModel Vm
        {
            get
            {
                return App.Locator.Main;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _taskRecyclerView = (RecyclerView)FindViewById(Resource.Id.ToDoRecyclerView);

            _adapter = Vm.Tasks.GetRecyclerAdapter(BindViewHolder,
                                          Resource.Layout.task_list_row);

            //tAdapter = new TasksAdapter(tasksList);
            //tAdapter.ItemClick += OnItemClick;
            //prepareToDoListData();
            _taskRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            //recyclerView.SetLayoutManager(mLayoutManager);
            //recyclerView.AddItemDecoration(new DividerItemDecoration(this, LinearLayoutManager.Vertical));
            //recyclerView.SetItemAnimator(new DefaultItemAnimator());
            Vm.Tasks.GetRecyclerAdapter(BindViewHolder, Resource.Layout.task_list_row);

            _taskRecyclerView.SetAdapter(_adapter);

            
            // Illustrates how to use the Messenger by receiving a message
            // and sending a message back.
            Messenger.Default.Register<NotificationMessageAction<string>>(
                this,
                HandleNotificationMessage);

            Tasks.SetCommand(
                "Click",
                Vm.NavigateCommand);

            // Binding and commanding

            // Binding between the first TextView and the WelcomeTitle property on the VM.
            // Keep track of the binding to avoid premature garbage collection
            //_bindings.Add(
            //    this.SetBinding(
            //        () => Vm.WelcomeTitle,
            //        () => WelcomeText.Text));

            //// Actuate the IncrementCommand on the VM.
            //IncrementButton.SetCommand(
            //    "Click",
            //    Vm.IncrementCommand);

            //// Create a binding that fires every time that the EditingChanged event is called
            //var dialogNavBinding = this.SetBinding(
            //        () => DialogNavText.Text);

            //// Keep track of the binding to avoid premature garbage collection
            //_bindings.Add(dialogNavBinding);

            //// Actuate the NavigateCommand on the VM.
            //// This command needs a CommandParameter of type string.
            //// This is what the dialogNavBinding provides.
            //TapText.SetCommand(
            //    "Click",
            //    Vm.NavigateCommand,
            //    dialogNavBinding);

            //// Actuate the ShowDialogCommand on the VM.
            //// This command needs a CommandParameter of type string.
            //// This is what the dialogNavBinding provides.
            //// This button will be disabled when the content of DialogNavText
            //// is empty (see ShowDialogCommand on the MainViewModel class).
            //ShowDialogButton.SetCommand(
            //    "Click",
            //    Vm.ShowDialogCommand,
            //    dialogNavBinding);

            //// Create a binding between the Clock property of the VM
            //// and the ClockText TextView.
            //// Keep track of the binding to avoid premature garbage collection
            //_bindings.Add(this.SetBinding(
            //    () => Vm.Clock,
            //    () => ClockText.Text));

            //// Actuate the SendMessageCommand on the VM.
            //SendMessageButton.SetCommand(
            //    "Click",
            //    Vm.SendMessageCommand);
        }

        //void OnItemClick(object sender, int position)
        //{

        //    Intent i = new Intent(this, typeof(TaskActivity));
        //    i.PutExtra("task", tasksList[position]);
        //    StartActivity(i);
        //}

        private void prepareToDoListData()
        {
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

            _adapter.NotifyDataSetChanged();
        }

        private void HandleNotificationMessage(NotificationMessageAction<string> message)
        {
            // Execute a callback to send a reply to the sender.
            message.Execute("Success! (from MainActivity.cs)");
        }

        //protected override void OnResume()
        //{
        //    // Start the clock background thread on the MainViewModel.
        //    Vm.StartClock();
        //    base.OnResume();
        //}

        //protected override void OnPause()
        //{
        //    // Stop the clock background thread on the MainViewModel.
        //    Vm.StopClock();
        //    base.OnPause();
        //}

        //protected override void OnDestroy()
        //{
        //    // Stop the clock background thread on the MainViewModel.
        //    Vm.StopClock();
        //    base.OnDestroy();
        //}
    }
}

