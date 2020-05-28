using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Authentication
{
    public static class SpotifyAuthorizationScopes
    {
        public static class Images
        {
            public static readonly string UgcImageUpload = "ugc-image-upload";
        }

        public static class SpotifyConnect
        {
            public static readonly string UserReadPlaybackState = "user-read-playback-state";
            public static readonly string UserModifyPlaybackState = "user-modify-playback-state";
            public static readonly string UserReadCurrentlyPlaying = "user-read-currently-playing";
        }

        public static class Playback
        {
            public static readonly string Streaming = "streaming";
            public static readonly string AppRemoteControl = "app-remote-control";
        }

        public static class Users
        {
            public static readonly string UserReadEmail = "user-read-email";
            public static readonly string UserReadPrivate = "user-read-private";
        }

        public static class Playlists
        {
            public static readonly string PlaylistReadCollaborative = "playlist-read-collaborative";
            public static readonly string PlaylistModifyPublic = "playlist-modify-public";
            public static readonly string PlaylistReadPrivate = "playlist-read-private";
            public static readonly string PlaylistModifyPrivate = "playlist-modify-private";
        }

        public static class Library
        {
            public static readonly string UserLibraryModify = "user-library-modify";
            public static readonly string UserLibraryRead = "user-library-read";
        }

        public static class ListeningHistory
        {
            public static readonly string UserTopRead = "user-top-read";
            public static readonly string UserReadPlaybackPosition = "user-read-playback-position";
            public static readonly string UserReadRecentlyPlayed = "user-read-recently-played";
        }

        public static class Follow
        {
            public static readonly string UserFollowRead = "user-follow-read";
            public static readonly string UserFollowModify = "user-follow-modify";
        }

        public static IEnumerable<string> All => new string[]{
            Images.UgcImageUpload,
            SpotifyConnect.UserModifyPlaybackState,
            SpotifyConnect.UserReadCurrentlyPlaying,
            SpotifyConnect.UserReadPlaybackState,
            Playback.AppRemoteControl,
            Playback.Streaming,
            Users.UserReadEmail,
            Users.UserReadPrivate,
            Playlists.PlaylistModifyPrivate,
            Playlists.PlaylistModifyPublic,
            Playlists.PlaylistReadCollaborative,
            Playlists.PlaylistReadPrivate,
            Library.UserLibraryModify,
            Library.UserLibraryRead,
            ListeningHistory.UserReadPlaybackPosition,
            ListeningHistory.UserReadRecentlyPlayed,
            ListeningHistory.UserTopRead,
            Follow.UserFollowModify,
            Follow.UserFollowRead
        };
    }
}
