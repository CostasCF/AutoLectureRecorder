﻿using AutoLectureRecorder.Pages;
using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using YoutubeAPI;

namespace AutoLectureRecorder
{
    public class ScreenRecorder
    {
        public Dictionary<string, string> AudioInputDevices { get => Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices); }
        public Dictionary<string, string> AudioOutputDevices { get => Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices); }
        public static string SelectedInputDevice { get { return Options.AudioOptions.AudioInputDevice; } set { Options.AudioOptions.AudioInputDevice = value; } }
        public static string SelectedOutputDevice { get { return Options.AudioOptions.AudioOutputDevice; } set { Options.AudioOptions.AudioOutputDevice = value; } }
        public List<RecordableWindow> RecordableWindows { get => Recorder.GetWindows(); }
        public bool IsRecording { get; set; } = false;
        
        public static RecorderOptions Options { get; set; } = new RecorderOptions
        {
            RecorderMode = RecorderMode.Video,
            //If throttling is disabled, out of memory exceptions may eventually crash the program,
            //depending on encoder settings and system specifications.
            IsThrottlingDisabled = false,
            //Hardware encoding is enabled by default.
            IsHardwareEncodingEnabled = true,
            //Low latency mode provides faster encoding, but can reduce quality.
            IsLowLatencyEnabled = true,
            //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
            IsMp4FastStartEnabled = false,

            //DisplayOptions = new DisplayOptions
            //{
            //    WindowHandle = RecordableWindows[0].Handle
            //},

            AudioOptions = new AudioOptions
            {
                Bitrate = AudioBitrate.bitrate_128kbps,
                Channels = AudioChannels.Stereo,
                IsAudioEnabled = true,
                IsInputDeviceEnabled = true,
                IsOutputDeviceEnabled = true,                
                AudioInputDevice = null,
                AudioOutputDevice = null
            },

            VideoOptions = new VideoOptions
            {
                BitrateMode = BitrateControlMode.Quality,
                Quality = 70,
                Framerate = 60,
                IsFixedFramerate = true,
                EncoderProfile = H264Profile.Main
            }
        };

        Recorder recorder;
        public void CreateRecording()
        {
            recorder = Recorder.CreateRecorder(Options);
            recorder.OnRecordingComplete += Rec_OnRecordingComplete;
            recorder.OnRecordingFailed += Rec_OnRecordingFailed;
            recorder.OnStatusChanged += Rec_OnStatusChanged;

            //Record to a file
            string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            recorder.Record(videoPath);

            IsRecording = true;
        }

        public bool WillUploadToYoutube { get; set; } = false;
        public void EndRecording(bool uploadToYoutube, ProgressBar progressBar)
        {
            WillUploadToYoutube = uploadToYoutube;
            _progressBar = progressBar;
            recorder.Stop();
        }

        ProgressBar _progressBar;
        private async void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            //Get the file path if recorded to a file
            Trace.WriteLine("Success!");
            IsRecording = false;

            if (WillUploadToYoutube)
            {
                YoutubeUploader youtube = new YoutubeUploader();
                await youtube.UploadVideo(@"G:\ΠΑΠΕΙ\4o εξάμηνο\Πληροφορική στην εκπαίδευση\2021-03-12 12-27-40.mkv", "TestVideo", "A description", _progressBar);
            }
        }

        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            Trace.WriteLine(e.Error);
            IsRecording = false;
        }

        private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
            Trace.WriteLine(status);
        }
    }
}
