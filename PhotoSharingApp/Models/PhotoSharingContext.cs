using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using PhotoSharingApp.Model;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingContext : DbContext
    {
        DbSet<Photo> Photos { get; set; }
        DbSet<Comment> Comments { get; set; }
    }
}