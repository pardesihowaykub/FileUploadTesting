using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUploadTesting.Models
{
    public class ProjectContext:DbContext
    {
        public DbSet<FileUpload> FileUploads { get; set; }
    }
}