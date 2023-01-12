﻿using AutoLectureRecorder.Sections.MainMenu.Dashboard;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Text;

namespace AutoLectureRecorder.WPF.Sections.MainMenu.Dashboard;

public partial class DashboardView : ReactiveUserControl<DashboardViewModel>
{
    public DashboardView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            this.WhenAnyValue(v => v.ViewModel!.NextScheduledLectureTimeDiff)
                .Subscribe(timeDiff => UpdateNextLecture(timeDiff))
                .DisposeWith(disposables);
        });
    }

    /// <summary>
    /// Updates the subject name and time distance text 
    /// </summary>
    private void UpdateNextLecture(TimeSpan? timeDiff)
    {
        if (timeDiff == null || ViewModel!.NextScheduledLecture == null)
        {
            this.nextLectureSubjectNameTextBlock.Text = "There is no lecture scheduled";
            this.nextLectureTimeTextBlock.Text = "-";
            return;
        }

        this.nextLectureSubjectNameTextBlock.Text = ViewModel.NextScheduledLecture.SubjectName;

        // The goal here is show only the relevant times on screen.
        // So for example, if the time distance from now to the closest scheduled lecture
        // is less than a day, we will not show 0 Days, but hide the days completely.
        // The same applies for hours and minutes
        var timeFormatBuilder = new StringBuilder();

        if (TimeSpan.Compare(timeDiff.Value, TimeSpan.FromDays(1)) >= 0)
        {
            timeFormatBuilder.Append(string.Format("{0} Day{1}, ",
                                                        timeDiff.Value.Days, timeDiff.Value.Days == 1 ? "" : "s"));
        }

        if (TimeSpan.Compare(timeDiff.Value, TimeSpan.FromHours(1)) >= 0)
        {
            timeFormatBuilder.Append(string.Format("{0} Hour{1}, ",
                                                        timeDiff.Value.Hours, timeDiff.Value.Hours == 1 ? "" : "s"));
        }

        if (TimeSpan.Compare(timeDiff.Value, TimeSpan.FromMinutes(1)) >= 0)
        {
            timeFormatBuilder.Append(string.Format("{0} Minute{1}, ",
                                        timeDiff.Value.Minutes, timeDiff.Value.Minutes == 1 ? "" : "s"));
        }

        timeFormatBuilder.Append(string.Format("{0} Second{1}",
                                        timeDiff.Value.Seconds, timeDiff.Value.Seconds == 1 ? "" : "s"));

        this.nextLectureTimeTextBlock.Text = timeFormatBuilder.ToString();
    }
}
