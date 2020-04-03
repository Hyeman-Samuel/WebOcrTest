using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOcrTest.Models
{
    public class OCRClass
    {
        public long app_id { get; set; }
        public long app_key { get; set; }
        public string src { get; set; }
        public string[] ocr { get; set; }
        public bool skip_recrop { get; set; }
        public string[] formats { get; set; }
    }

    public class auth
    {
        public long app_id { get; set; }
        public long app_key { get; set; }
    }
}
