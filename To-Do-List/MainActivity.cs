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

namespace To_Do_List
{
    [Activity(Label = "MVVM LIGHT SAMPLE", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public partial class MainActivity : AppCompatActivityBase
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the MainViewModel from the ViewModelLocator.
        /// </summary>
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

            recyclerView = (RecyclerView)FindViewById(Resource.Id.ToDoRecyclerView);

            tAdapter = new TasksAdapter(tasksList);
            prepareToDoListData();
            RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(ApplicationContext);
            recyclerView.SetLayoutManager(mLayoutManager);
            recyclerView.SetItemAnimator(new DefaultItemAnimator());
            recyclerView.SetAdapter(tAdapter);

            
            // Illustrates how to use the Messenger by receiving a message
            // and sending a message back.
            Messenger.Default.Register<NotificationMessageAction<string>>(
                this,
                HandleNotificationMessage);

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

        private void prepareToDoListData()
        {
            Task task = new Task("Do the dishes", System.DateTime.Now);
            tasksList.Add(task);

            tAdapter.NotifyDataSetChanged();
        }

        private void HandleNotificationMessage(NotificationMessageAction<string> message)
        {
            // Execute a callback to send a reply to the sender.
            message.Execute("Success! (from MainActivity.cs)");
        }

        protected override void OnResume()
        {
            // Start the clock background thread on the MainViewModel.
            Vm.StartClock();
            base.OnResume();
        }

        protected override void OnPause()
        {
            // Stop the clock background thread on the MainViewModel.
            Vm.StopClock();
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            // Stop the clock background thread on the MainViewModel.
            Vm.StopClock();
            base.OnDestroy();
        }
    }
}

