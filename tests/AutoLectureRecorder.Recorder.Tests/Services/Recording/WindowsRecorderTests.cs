using System.Runtime.InteropServices;
using AutoLectureRecorder.Services.Recording;
using Xunit.Abstractions;

namespace AutoLectureRecorder.Recorder.Tests.Services.Recording;

public class WindowsRecorderTests
{
    private readonly string TestVideosDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestVideos");

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    private readonly ITestOutputHelper _output;

    public WindowsRecorderTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task StartRecording_ShouldRecordScreenFor3Seconds()
    {
        await TestSuccessfulRecording("SimpleRecordScreenTest", TimeSpan.FromSeconds(3));
    }

    [Fact]
    public async Task StartRecording_ShouldRecordWindowFor3Seconds()
    {
        IntPtr thisWindowHandle = GetForegroundWindow();
        await TestSuccessfulRecording("RecordWindowTest", TimeSpan.FromSeconds(3), thisWindowHandle);
    }

    [Fact]
    public async Task StartRecording_ShouldDetectIdenticalNameAndCreateNewFile()
    {
        var recorder = await TestSuccessfulRecording("IdenticalVideo", TimeSpan.FromSeconds(1));
        recorder.StartRecording(autoDeleteIdenticalFile: false);

        await Task.Delay(TimeSpan.FromSeconds(2));
        recorder.StopRecording();
        while (recorder.IsRecording)
        {
            await Task.Delay(200);
        }

        recorder.StartRecording(autoDeleteIdenticalFile: false);

        await Task.Delay(TimeSpan.FromSeconds(2));
        recorder.StopRecording();
        while (recorder.IsRecording)
        {
            await Task.Delay(200);
        }

        Assert.True(File.Exists(Path.Combine(TestVideosDirectory, "IdenticalVideo (1).mp4")));
        Assert.True(File.Exists(Path.Combine(TestVideosDirectory, "IdenticalVideo (2).mp4")));
    }

    private async Task<IRecorder> TestSuccessfulRecording(string videoFileName, TimeSpan recordingTime, IntPtr? windowHandle = null)
    {
        var logger = XUnitLogger.CreateLogger<WindowsRecorder>(_output);

        var recorder = new WindowsRecorder(logger)
        {
            RecordingDirectoryPath = TestVideosDirectory,
            RecordingFileName = videoFileName
        };

        var settings = recorder.GetDefaultSettings(1920, 1080);
        recorder.ApplyRecordingSettings(settings);

        recorder.StartRecording(windowHandle);

        Assert.True(recorder.IsRecording);

        await Task.Delay(recordingTime);

        bool finishedSuccessfully = false;
        bool recordingFailed = false;

        recorder.StopRecording()
            .OnRecordingComplete(() =>
            {
                finishedSuccessfully = true;
            })
            .OnRecordingFailed(() =>
            {
                recordingFailed = true;
            });

        while (recorder.IsRecording)
        {
            await Task.Delay(200);
        }

        Assert.True(File.Exists(Path.Combine(TestVideosDirectory, $"{videoFileName}.mp4")));
        Assert.True(finishedSuccessfully);
        Assert.False(recorder.IsRecording);
        Assert.False(recordingFailed);

        return recorder;
    }
}