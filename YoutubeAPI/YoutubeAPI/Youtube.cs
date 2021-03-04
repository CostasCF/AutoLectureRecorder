using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YoutubeAPI
{
    public class YoutubeUploader
    {
        UserCredential credential;
        string videoID;
        Dictionary<string, Playlist> playlists = new Dictionary<string, Playlist>();
        bool authenticate = true;

        //more info about Task classes and methods:
        // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-5.0
        // https://stackoverflow.com/questions/16728338/how-can-i-run-both-of-these-methods-at-the-same-time-in-net-4-5
        //string VideoFilePath, string VideoName, string playlistName, string Description

        //public async Task Run()
        //{
        //    var videoUploadTask = Task.Run(() => videoUploading(VideoFilePath, VideoName, playlistName, Description));
        //    await videoUploadTask;
        //    var playlistVideoAddTask = Task.Run(() => playlistVideoAdder(videoID));
        //    await playlistVideoAddTask;
        //    var retrievePlaylistsTask = Task.Run(() => retrievePlaylists());
        //    await retrievePlaylistsTask;
        //}

        public async Task<bool> Authentication() //Authorization section
        {
            try
            {
                using (var stream = new FileStream("client_id3.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        // This OAuth 2.0 access scope allows for full read/write access to the
                        // authenticated user's account.
                        new[] { YouTubeService.Scope.Youtube },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("C:/Users/kkalo/OneDrive/Documents/GitHub/AutoLectureRecorder/YoutubeAPI/YoutubeAPI/bin/debug", true)
                    );
                }

            }
            catch { authenticate = false;   }

            return authenticate;

        }



        public async Task UploadVideo(string VideoFilePath, string VideoName, string Description)
        {
            bool authenticate = await Authentication();
            if (authenticate)
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer() //recieve authentication file
                {
                    HttpClientInitializer = credential, 
                    ApplicationName = this.GetType().ToString()
                });

                //-----------Video Upload Section-------------------------------------------------
                var video = new Video();
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = VideoName;
                video.Snippet.Description = Description;
                video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                video.Status.PrivacyStatus = "private"; // or "private" or "public"
                var filePath = VideoFilePath; // Replace with path to actual movie file.

                //when video snippet is ready, call videoInsertRequest and upload it to youtube!
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                    videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                    videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived; //moving metadata to the videosInsertRequest_ResponseReceived() function.
                    await videosInsertRequest.UploadAsync();
                }

                void videosInsertRequest_ProgressChanged(IUploadProgress progress)
                {
                    switch (progress.Status)
                    {
                        case UploadStatus.Uploading:
                            MessageBox.Show(String.Format("{0} bytes sent.", progress.BytesSent));

                            break;

                        case UploadStatus.Failed:
                            MessageBox.Show(String.Format("An error prevented the upload from completing.\n{0}", progress.Exception));
                            break;
                    }
                }

                //-----------Playlist Section------------------------------------------------------
                // Define and execute the API request
                var request = youtubeService.Playlists.List("snippet,contentDetails");
                PlaylistListResponse response = new PlaylistListResponse();
                request.MaxResults = 25;
                request.Mine = true; //mine is true means that we are refering to our own channel, the one that is currently authenticated
                response = await request.ExecuteAsync(); //await response


                Console.WriteLine(response.Items.Count);
                bool playlistIsFound = false;
                foreach(var playlist in response.Items)
                {
                    if (playlist.Snippet.Title.Contains(VideoName))
                    {
                        playlistIsFound = true;
                        var newPlaylistItem = new PlaylistItem();
                        newPlaylistItem.Snippet = new PlaylistItemSnippet();

                        newPlaylistItem.Snippet.PlaylistId = playlist.Id;

                        newPlaylistItem.Snippet.ResourceId = new ResourceId();
                        newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
                        newPlaylistItem.Snippet.ResourceId.VideoId = videoID;
                        newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync(); //add video the playlist
                    }
                }

                if(playlistIsFound == false)
                {
                    //create a playlist
                    var newPlaylist = new Playlist();
                    newPlaylist.Snippet = new PlaylistSnippet();
                    newPlaylist.Snippet.Title = VideoName;
                    newPlaylist.Snippet.Description = "";
                    newPlaylist.Status = new PlaylistStatus();
                    newPlaylist.Status.PrivacyStatus = "private";
                    newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync(); //create a playlist

                    var newPlaylistItem = new PlaylistItem();
                    newPlaylistItem.Snippet = new PlaylistItemSnippet();
                    newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
                    newPlaylistItem.Snippet.ResourceId = new ResourceId();
                    newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
                    newPlaylistItem.Snippet.ResourceId.VideoId = videoID;
                    newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync(); //add video to the created playlist
                }
            }
            else { MessageBox.Show("Failed to Authenticate"); }
        }






        public async Task retrievePlaylists()
        {
         bool  authenticate = await Authentication();
            if (authenticate)
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

                // Define and execute the API request
                var request = youtubeService.Playlists.List("snippet,contentDetails");
                PlaylistListResponse response = new PlaylistListResponse();
                request.MaxResults = 25;
                request.Mine = true; //mine is true means that we are refering to our own channel
                response = await request.ExecuteAsync(); //await response

                Console.WriteLine(response.Items.Count);

                foreach (var playlist in response.Items)
                {
                    MessageBox.Show(playlist.Snippet.Title);
                    Console.WriteLine(playlist.Id);
                }
            }else
             MessageBox.Show("Failed to Authenticate"); 
         
        }
        public async Task videoUploading(string VideoFilePath, string VideoName, string playlistName, string Description)
        {
            //int counter = 0;
            //Path.Combine("client_id" + counter, ".json");
          await Authentication();
                
          

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });


           // if (authenticate == true)
           // {
                //video creation
                var video = new Video();
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = VideoName;
                video.Snippet.Description = Description;
                video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                video.Status.PrivacyStatus = "private"; // or "private" or "public"
                var filePath = VideoFilePath; // Replace with path to actual movie file.

                //when it's Snippet is ready, call videoInsertRequest and upload it to youtube!
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                    videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                    videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived; //moving metadata to the videosInsertRequest_ResponseReceived() function.


                    await videosInsertRequest.UploadAsync();
                }

            //    if (!playlists.ContainsKey(playlistName))
            //    {
            //        Console.WriteLine("Entered if");
            //        CreatePlaylist(playlistName);
            //        try
            //        {
            //            playlists[playlistName] = await youtubeService.Playlists.Insert(playlists[playlistName], "snippet,status").ExecuteAsync();
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Couldn't create playlist. Please contact the developers to cry for help");
            //        }
            // //   }



            //    try //addding video the playlist
            //    {

            //        var newPlaylistItem = new PlaylistItem();
            //        newPlaylistItem.Snippet = new PlaylistItemSnippet();

            //        newPlaylistItem.Snippet.PlaylistId = playlists[playlistName].Id;

            //        newPlaylistItem.Snippet.ResourceId = new ResourceId();
            //        newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            //        newPlaylistItem.Snippet.ResourceId.VideoId = videoID;
            //        newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Video was not added to the playlist");
            //    }
            //}

            void videosInsertRequest_ProgressChanged(IUploadProgress progress)
            {
                switch (progress.Status)
                {
                    case UploadStatus.Uploading:
                        MessageBox.Show(String.Format("{0} bytes sent.", progress.BytesSent));

                        break;

                    case UploadStatus.Failed:
                        MessageBox.Show(String.Format("An error prevented the upload from completing.\n{0}", progress.Exception));
                        break;
                }
            }

        }

        void videosInsertRequest_ResponseReceived(Video video) //receiving video.id
        {
            MessageBox.Show("Video id '{0}' was successfully uploaded.", video.Id);
            videoID = video.Id;
        }
            


    }

}

