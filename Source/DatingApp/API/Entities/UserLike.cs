using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserID { get; set; }
        public AppUser LikeUser { get; set; }
        public int LikeUserID { get; set; }
    }
}
