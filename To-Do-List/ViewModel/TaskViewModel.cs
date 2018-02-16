using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using JimBobBennett.MvvmLight.AppCompat;
using To_Do_List.Model;

namespace To_Do_List.ViewModel
{
    public class TaskViewModel : ViewModelBase
    {

        private readonly ITaskService _taskService;
        private readonly INavigationService _navigationService;
        private RelayCommand<Task> _navigateCommand;
        private RelayCommand<string> _showDialogCommand;
        private RelayCommand<Task> _taskChangedCommand;

        private Task _previousTask;


        public Task PreviousTask
        {
            get
            {

                return _previousTask;
            }
            set
            {
                Set(ref _previousTask, value);
            }
        }

        private Task _editedTask;


        public Task EditedTask
        {
            get
            {

                return _editedTask;
            }
            set
            {
                Set(ref _editedTask, value);
            }
        }

        public RelayCommand<Task> TaskChangedCommand
        {
            get
            {
                return _taskChangedCommand
                    ?? (_taskChangedCommand = new RelayCommand<Task>(
                        task => {    

                    },
                        task => !(_previousTask.Equals(_editedTask)))); 
            }
        }

        /// <summary>
        /// Gets the ShowDialogCommand.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand<string> ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand<string>(
                           async text =>
                           {
                               var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialogService.ShowMessage(
                                   "This is a message displayed by the dialog service | " + text,
                                   "Dialog sample",
                                   "OK",
                                   () =>
                                   {
                                       Debug.WriteLine("This code is only executed after the dialog closes (1)");
                                   });

                               Debug.WriteLine("This code is only executed after the dialog closes (2)");
                           },
                           text => !string.IsNullOrEmpty(text))); // This line disables the button if the text is null or empty
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public TaskViewModel(
            ITaskService taskService,
            INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;

        }
    }
}