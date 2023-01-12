﻿using AutoLectureRecorder.Data.ReactiveModels;
using AutoLectureRecorder.Services.DataAccess;

namespace AutoLectureRecorder.UnitTests.Services.DataAccess.Validation.DataAccessMocks;

internal class ScheduledLectureDataMock : IScheduledLectureRepository
{
    private readonly List<ReactiveScheduledLecture> _lectures;

    public ScheduledLectureDataMock(List<ReactiveScheduledLecture> lectures)
    {
        _lectures = lectures;
    }

    public Task<List<ReactiveScheduledLecture>> GetAllScheduledLecturesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ReactiveScheduledLecture>?> GetScheduledLecturesGroupedByName()
    {
        throw new NotImplementedException();
    }

    public Task DeleteScheduledLectureById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>?> GetDistinctSubjectNames()
    {
        throw new NotImplementedException();
    }

    public Task<ReactiveScheduledLecture?> GetScheduledLectureByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ReactiveScheduledLecture?> GetScheduledLectureBySubjectNameAsync(string subjectName)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReactiveScheduledLecture>> GetScheduledLecturesByDayAsync(DayOfWeek? day)
    {
        return Task.FromResult(_lectures);
    }

    public Task<ReactiveScheduledLecture?> InsertScheduledLectureAsync(string subjectName, int semester, string meetingLink, DayOfWeek? day, DateTime? startTime, DateTime? endTime, bool isScheduled, bool willAutoUpload)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReactiveScheduledLecture>> GetAllScheduledLecturesSortedAsync()
    {
        throw new NotImplementedException();
    }
}
