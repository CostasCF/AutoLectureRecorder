﻿using ReactiveMarbles.ObservableEvents;
using ReactiveUI;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace AutoLectureRecorder.Sections.MainMenu.CreateLecture;

public partial class CreateLectureView : ReactiveUserControl<CreateLectureViewModel>
{
    public CreateLectureView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            DataContext = ViewModel;

            // Observable collection bindings
            this.OneWayBind(ViewModel, vm => vm.DistinctScheduledLectures, v => v.SubjectNameComboBox.ItemsSource)
                .DisposeWith(disposables);

            // Combobox behaviour
            SubjectNameComboBox.Events().GotFocus
                .Subscribe(e =>
                {
                    if (ViewModel!.DistinctScheduledLectures.Count == 0)
                    {
                        SubjectNameComboBox.IsDropDownOpen = false;
                        return;
                    }

                    SubjectNameComboBox.IsDropDownOpen = true;
                }).DisposeWith(disposables);;

            // Fields values bindings
            this.Bind(ViewModel, vm => vm.ScheduledLecture.SubjectName, v => v.SubjectNameComboBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.Semester, v => v.SemesterComboBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.MeetingLink, v => v.MeetingLinkTextBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.Day, v => v.DayComboBox.Text)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.StartTime, v => v.StartTimePicker.SelectedTime)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.EndTime, v => v.EndTimePicker.SelectedTime)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.IsScheduled, v => v.IsScheduledToggleButton.IsChecked)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.ScheduledLecture.WillAutoUpload, v => v.AutoUploadToggleButton.IsChecked)
                .DisposeWith(disposables);

            // Fields validation bindings
            this.OneWayBind(ViewModel, vm => vm.ScheduledLectureValidationErrors.SubjectNameError, v => v.SubjectNameErrorTextBlock.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ScheduledLectureValidationErrors.SemesterError, v => v.SemesterErrorTextBlock.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ScheduledLectureValidationErrors.MeetingLinkError, v => v.MeetingLinkErrorTextBlock.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ScheduledLectureValidationErrors.DayError, v => v.DayErrorTextBlock.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ScheduledLectureValidationErrors.TimeError, v => v.StartTimeErrorTextBlock.Text)
                .DisposeWith(disposables);

            // Fields validation errors visibility
            this.OneWayBind(ViewModel, vm => vm.ValidateErrorsVisibility, v => v.SubjectNameErrorTextBlock.Visibility)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ValidateErrorsVisibility, v => v.SemesterErrorTextBlock.Visibility)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ValidateErrorsVisibility, v => v.MeetingLinkErrorTextBlock.Visibility)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ValidateErrorsVisibility, v => v.DayErrorTextBlock.Visibility)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ValidateErrorsVisibility, v => v.StartTimeErrorTextBlock.Visibility)
                .DisposeWith(disposables);

            // Snackbars
            this.OneWayBind(ViewModel, vm => vm.IsFailedInsertionSnackbarActive, v => v.InsertionFailedSnackbar.IsActive)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsSuccessfulInsertionSnackbarActive, v => v.InsertionSucceededSnackbar.IsActive)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsFailedUpdateSnackbarActive, v => v.UpdateFailedSnackbar.IsActive)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsSuccessfulUpdateSnackbarActive, v => v.UpdateSucceededSnackbar.IsActive)
                .DisposeWith(disposables);

            // Buttons visibility and state
            this.OneWayBind(ViewModel, vm => vm.IsUpdateModeSelected, v => v.UpdateButton.Visibility,
                    value => value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsUpdateModeSelected, v => v.SubmitButton.Visibility,
                    value => value ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsUpdateModeSelected, v => v.UpdateButton.IsEnabled)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.IsUpdateModeSelected, v => v.SubmitButton.IsEnabled,
                    value => !value)
                .DisposeWith(disposables);

            // Commands
            this.BindCommand(ViewModel, vm => vm.AutoFillSemesterAndLinkCommand, 
                    v => v.SubjectNameComboBox, nameof(SubjectNameComboBox.LostFocus))
                .DisposeWith(disposables);;

            this.BindCommand(ViewModel, vm => vm.CreateScheduledLectureCommand, v => v.SubmitButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.UpdateScheduledLectureCommand, v => v.UpdateButton)
                .DisposeWith(disposables);
        });
    }
}
