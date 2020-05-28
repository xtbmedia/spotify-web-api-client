using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Xtb.Spotify.Api.Dto
{
    public class PrivateUser
    {
        /// <summary>
        /// The country of the user, as set in the user’s account profile.
        /// 
        /// An ISO 3166-1 alpha-2 country code.
        /// 	
        /// This field is only
        /// available when the current user has granted access to
        /// the user-read-private scope.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The name displayed on the user’s profile. null if not available.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The user’s email address, as entered by the user when creating
        /// their account. Important! This email address is unverified;
        /// there is no proof that it actually belongs to the user.
        /// 
        /// This field is only available when the current user
        /// has granted access to the user-read-email scope.
        /// </summary>
        public string Email { get; set; }

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
        /// The user’s Spotify subscription level: “premium”, “free”, etc.
        /// 
        /// (The subscription level “open” can be considered the same 
        /// as “free”.) 
        /// 
        /// This field is only available when the current user 
        /// has granted access to the user-read-private scope.
        /// </summary>
        public string Product { get; set; }

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
