﻿using AutoLectureRecorder.Data.Models;
using AutoLectureRecorder.Services.DataAccess.Interfaces;

namespace AutoLectureRecorder.Services.DataAccess.Seeding;

public class SampleData
{
    public const int RandomSeed = 323454384;

    private readonly ISqliteDataAccess _dataAccess;
    private readonly Random _random;

    public List<ScheduledLecture> ScheduledLectures { get; set; } = new();
    public List<RecordedLecture> RecordedLectures { get; set; } = new();
    public RecordingSettings? RecordingSettings { get; set; }
    public Statistics? Statistics { get; set; }

    public SampleData(ISqliteDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
        _random = new Random(RandomSeed);

        CreateScheduledLectures();
        CreateRecordedLectures();
        CreateRecordingSettings();
        CreateStatistics();
    }

    /// <summary>
    /// Adds sample data to the SQLite database
    /// </summary>
    public async Task Seed()
    {
        await _dataAccess.BeginTransaction();

        var deleteTasks = new List<Task>
        {
            DeleteEverythingFrom("RecordedLectures"),
            DeleteEverythingFrom("RecordingSettings"),
            DeleteEverythingFrom("ScheduledLectures"),
            DeleteEverythingFrom("Statistics")
        };

        await Task.WhenAll(deleteTasks);

        var insertTasks = new List<Task>();

        foreach (var scheduledLecture in ScheduledLectures)
        {
            insertTasks.Add(InsertScheduledLectureToDb(scheduledLecture));
        }

        foreach (var recordedLecture in RecordedLectures)
        {
            insertTasks.Add(InsertRecordedLectureToDb(recordedLecture));
        }

        if (RecordingSettings != null)
        {
            insertTasks.Add(InsertRecordingSettingsToDb(RecordingSettings));
        }

        if (Statistics != null)
        {
            insertTasks.Add(InsertStatisticsToDb(Statistics));
        }

        await Task.WhenAll(insertTasks);

        _dataAccess.CommitPendingTransaction();
    }

    private static readonly string[] CourseNames =
    {
        "Short Course", 
        "Medium Course Name Length",
        "Lengthy Course Name For Testing More Extreme Cases On User Interface"
    };
    private static readonly Dictionary<string, int> CourseNamesByNumberOfAppearances = new() 
    { 
        { CourseNames[0], 0 }, 
        { CourseNames[1], 0 }, 
        { CourseNames[2], 0 }
    };
    private void CreateScheduledLectures()
    {
        int lectureId = 1;
        bool shouldLectureBeActive = true;

        for (int semester = 1; semester <= 8; semester++)
        {
            if (semester > 1)
            {
                shouldLectureBeActive = false;
            }
            for (int day = 0; day < 7; day++)
            {
                // Pick times starting from 10 am
                var startTime = DateTime.MinValue.AddHours(10).AddMinutes(15);
                var endTime = DateTime.MinValue.AddHours(12).AddMinutes(14);

                for (int lectureNum = 0; lectureNum < _random.Next(1,4); lectureNum++)
                {
                    // Pick random name and add indexes at the end of the names according to how many times
                    // a name is used. This is done to simulate different lectures. For example Short Course 1
                    // it a completely different course that Short Course 2
                    var randomNum = _random.Next(3);
                    var randomName = CourseNames[randomNum];
                    CourseNamesByNumberOfAppearances[randomName]++;
                    var subjectName = $"{randomName} {CourseNamesByNumberOfAppearances[randomName]}";

                    var scheduledLecture = new ScheduledLecture
                    {
                        Id = lectureId++,
                        SubjectName = subjectName,
                        Semester = semester,
                        MeetingLink = "https://teams.microsoft.com",
                        Day = day,
                        StartTime = startTime.ToString("HH:mm"),
                        EndTime = endTime.ToString("HH:mm"),
                        IsScheduled = shouldLectureBeActive ? 1 : 0,
                        WillAutoUpload = _random.Next(2)
                    };

                    ScheduledLectures.Add(scheduledLecture);

                    startTime = startTime.AddHours(2);
                    endTime = endTime.AddHours(2);
                }
            }
        }
    }

    private void CreateRecordedLectures()
    {
        int id = 1;

        var lastDateTimeByDay = new Dictionary<DayOfWeek, DateTime?>
        {
            { DayOfWeek.Sunday, new DateTime(2021, 1, 3) },
            { DayOfWeek.Monday, new DateTime(2021, 1, 4) },
            { DayOfWeek.Tuesday, new DateTime(2021, 1, 5) },
            { DayOfWeek.Wednesday, new DateTime(2021, 1, 6) },
            { DayOfWeek.Thursday, new DateTime(2021, 1, 7) },
            { DayOfWeek.Friday, new DateTime(2021, 1, 8) },
            { DayOfWeek.Saturday, new DateTime(2021, 1, 9) },
        };

        foreach (var scheduledLecture in ScheduledLectures)
        {
            bool shouldHaveCloudLink = _random.Next(3) != 2;
            var scheduledLectureDay = (DayOfWeek)scheduledLecture.Day;
            var recordingDate = lastDateTimeByDay[scheduledLectureDay];
            var startTime = Convert.ToDateTime(scheduledLecture.StartTime);
            var endTime = Convert.ToDateTime(scheduledLecture.EndTime);

            var startDateTime = recordingDate!.Value.Add(startTime.TimeOfDay).Subtract(TimeSpan.FromHours(1));
            var endDateTime = recordingDate!.Value.Add(endTime.TimeOfDay);
            for (int i = 0; i < _random.Next(2, 20); i++)
            {
                var recordedLecture = new RecordedLecture
                {
                    Id = id++,
                    StudentRegistrationNumber = "p19165",
                    CloudLink = shouldHaveCloudLink 
                        ? "https://link.storjshare.io/s/jwwlss3g44lwvp5etxkxcn6oo6ya/newdemo/Big%20Buck%20Bunny%20Demo.mp4?wrap=0" 
                        : null,
                    StartedAt = startDateTime.ToString("G"),
                    EndedAt = endDateTime.ToString("G"),
                    ScheduledLectureId = scheduledLecture.Id
                };
                RecordedLectures.Add(recordedLecture);
                startDateTime = startDateTime.Add(TimeSpan.FromHours(1));
                endDateTime = endDateTime.Add(TimeSpan.FromHours(1));
            }

            lastDateTimeByDay[scheduledLectureDay] = lastDateTimeByDay[scheduledLectureDay]!
                .Value.Add(TimeSpan.FromDays(7));
        }
    }

    private void CreateRecordingSettings()
    {

    }

    private void CreateStatistics()
    {

    }

    private async Task DeleteEverythingFrom(string tableName)
    {
        string sql = $"delete from {tableName}";
        await _dataAccess.SaveData(sql, new { });
    }

    private async Task InsertRecordedLectureToDb(RecordedLecture recordedLecture)
    {
        string sql = "insert into RecordedLectures (Id, StudentRegistrationNumber, CloudLink, StartedAt, EndedAt, ScheduledLectureId) " +
                     "values (@Id, @StudentRegistrationNumber, @CloudLink, @StartedAt, @EndedAt, @ScheduledLectureId)";

        await _dataAccess.SaveData(sql, recordedLecture).ConfigureAwait(false);
    }

    private async Task InsertRecordingSettingsToDb(RecordingSettings recordingSettings)
    {
        string sql = "insert into RecordingSettings (RecordingsLocalPath, OutputDevice, InputDevice, IsInputDeviceEnabled, Quality, Fps, OutputFrameWidth, OutputFrameHeight) " +
                     "values (@RecordingsLocalPath, @OutputDevice, @InputDevice, @IsInputDeviceEnabled, @Quality, @Fps, @OutputFrameWidth, @OutputFrameHeight)";

        await _dataAccess.SaveData(sql, recordingSettings).ConfigureAwait(false);
    }

    private async Task InsertScheduledLectureToDb(ScheduledLecture scheduledLecture)
    {
        string sql = "insert into ScheduledLectures (Id, SubjectName, Semester, MeetingLink, Day, StartTime, EndTime, IsScheduled, WillAutoUpload) " +
                     "values (@Id, @SubjectName, @Semester, @MeetingLink, @Day, @StartTime, @EndTime, @IsScheduled, @WillAutoUpload)";

        await _dataAccess.SaveData(sql, scheduledLecture).ConfigureAwait(false);
    }

    private async Task InsertStatisticsToDb(Statistics statistics)
    {
        string sql = "insert into Statistics (TotalRecordAttempts, RecordingSucceededNumber, RecordingFailedNumber) " +
                     "values (@TotalRecordAttempts, @RecordingSucceededNumber, @RecordingFailedNumber)";

        await _dataAccess.SaveData(sql, statistics).ConfigureAwait(false);
    }
}
