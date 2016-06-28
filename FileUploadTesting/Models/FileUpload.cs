using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUploadTesting.Models
{
    public class FileUpload
    {
        [Key]
        public int   ID { get; set; }
        public string FileName { get; set; }
        public string Path  { get; set; }
    }
}