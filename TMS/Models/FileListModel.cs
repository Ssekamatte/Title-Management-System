using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Models
{
    public class FileListModel
    {
        public List<FileList> FileListCollction { get; set; }
        public FileList FileListDetail { get; set; }
    }
    public class FileList
    {
        public string Id { get; set; }
        public string FileURL { get; set; }
        public string FileType { get; set; }
        public string Detail { get; set; }
        public string TitleReference { get; set; }        
        private string Sax;
    }    
}