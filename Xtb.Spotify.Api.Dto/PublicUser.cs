using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xtb.Spotify.Api.Dto
{
    public class PublicUser
    {
        /// <summary>
        /// The name displayed on the user’s profile. null if not available.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Known external URLs for this user.
        /// </summary>
        public ExternalUrl ExternalUrl { get; set; }

        /// <summary>
        /// Information about the followers of the user.
        /// </summary>
        public Followers Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint for this user.
        /// </summary>
        public string HRef { get; set; }

        /// <summary>
        /// The Spotify user ID for the user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user’s profile image.
        /// </summary>
        public IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// The object type: “user”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the user.
        /// </summary>
        public string Uri { get; set; }
    }
}
