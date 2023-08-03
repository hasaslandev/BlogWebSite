using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogDetailDto:IDto
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
