﻿using AutoLectureRecorder.Selenium;
using AutoLectureRecorder.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoLectureRecorder.Pages
{
    /// <summary>
    /// Interaction logic for AddLecture.xaml
    /// </summary>
    public partial class AddLecture : Page
    {
        public AddLecture()
        {
            InitializeComponent();
            new Thread(() => LoadTeams()).Start();
        }

        #region LoadTeamsToCombobox
        /* Load, add to the meetings combobox and serialize the microsoft teams 
         * using selenium  and show or hide the wait message accordingly */
        private void LoadTeams()
        {
            if (User.MicrosoftTeams == null)
            {
                Dispatcher.Invoke(() => ShowWaitMessage()); 
                List<string> microsoftTeams = Chrome.Bot.GetMeetings();
                if (microsoftTeams != null)
                {
                    if (microsoftTeams.Count > 0)
                    {
                        Dispatcher.Invoke(() => {
                            foreach (string team in microsoftTeams)
                            {
                                Trace.WriteLine(team);
                                ComboboxMeeting.Items.Add(team);
                            }
                        });
                        User.MicrosoftTeams = microsoftTeams;
                        Serialize.SerializeUserData(User.RegistrationNumber, User.Password, User.MicrosoftTeams);
                        Dispatcher.Invoke(() => ShowAddLectureForm());
                    }
                    else
                    {
                        Dispatcher.Invoke(() => ShowEmptyTeamsListMessage());
                    }
                }
            }
            else
            {
                Dispatcher.Invoke(() => {
                    foreach (string team in User.MicrosoftTeams)
                    {
                        Trace.WriteLine(team);
                        ComboboxMeeting.Items.Add(team);
                    }
                    ShowAddLectureForm();
                });
            }
        }

        private void ShowWaitMessage()
        {
            StackPanelMain.Visibility = Visibility.Hidden;
            StackPanelNoTeamsFound.Visibility = Visibility.Hidden;
            StackPanelLoadingTeams.Visibility = Visibility.Visible;  
        }

        private void ShowAddLectureForm()
        {
            StackPanelMain.Visibility = Visibility.Visible;
            StackPanelNoTeamsFound.Visibility = Visibility.Hidden;
            StackPanelLoadingTeams.Visibility = Visibility.Hidden;
        }

        private void ShowEmptyTeamsListMessage()
        {
            StackPanelMain.Visibility = Visibility.Hidden;
            StackPanelNoTeamsFound.Visibility = Visibility.Visible;
            StackPanelLoadingTeams.Visibility = Visibility.Hidden;
        }
        #endregion

        #region UpdateTeamsCombobox
        private void ButtonUpdateTeams_Click(object sender, RoutedEventArgs e)
        {
            ClearTeamsFromCombobox();
            new Thread(() => LoadTeams()).Start();
        }

        private void ButtonUpdateTeams2_Click(object sender, RoutedEventArgs e)
        {
            var userResponse = MessageBox.Show("Updating microsoft teams can take up to a couple of minutes. During that time you won't be able to create new lectures. Are you sure you want to continue?",
                                               "Continue?", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (userResponse == MessageBoxResult.Yes)
            {
                ClearTeamsFromCombobox();
                new Thread(() => LoadTeams()).Start();
            }
        }

        private void ClearTeamsFromCombobox()
        {
            ComboboxMeeting.Text = string.Empty;
            ComboboxMeeting.Items.Clear();
        }
        #endregion

        #region Add Lecture
        private void ButtonAddLecture_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserInputNotEmpty())
            {
                TimeSpan startTime = TimePickerStartTime.SelectedTime.Value.TimeOfDay;
                TimeSpan endTime = TimePickerEndTime.SelectedTime.Value.TimeOfDay;

                if (endTime <= startTime)
                {
                    MessageBox.Show("The end time must be greater than the start time", "Wrong time input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string name = TextboxLectureName.Text;
                string meetingTeam = ComboboxMeeting.Text;
                string day = ComboboxDay.Text; 
                bool isYoutubeActive = CheckboxYoutube.IsChecked.Value;

                Lecture lecture = new Lecture(name, startTime, endTime, meetingTeam, isYoutubeActive, day);
                Schedule.AddLecture(lecture);
                
                ((MainWindow)Application.Current.Windows[1]).AddNewLectureModels();

                MessageBox.Show("Lecture added successfully!");
            }
            else
                MessageBox.Show("Make sure that all fields are filled", "Empty fields detected", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool IsUserInputNotEmpty()
        {
            bool IsUnputCorrect = true;

            if (string.IsNullOrWhiteSpace(TextboxLectureName.Text))
            {
                TextboxLectureName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AD2817"));
                IsUnputCorrect = false;
            }
                
            if (string.IsNullOrWhiteSpace(ComboboxMeeting.Text))
            {
                ComboboxMeeting.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AD2817"));
                IsUnputCorrect = false;
            }

            if (ComboboxDay.SelectedIndex == -1)
            {
                ComboboxDay.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AD2817"));
                IsUnputCorrect = false;
            }

            if (TimePickerStartTime.SelectedTime == null)
            {
                TimePickerStartTime.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AD2817"));
                IsUnputCorrect = false;
            }

            if (TimePickerEndTime.SelectedTime == null)
            {
                TimePickerEndTime.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AD2817"));
                IsUnputCorrect = false;
            }

            return IsUnputCorrect;
        }
        #endregion
   
    }
}
