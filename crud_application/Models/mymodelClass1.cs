using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_application.Models
{
    public class mymodelClass1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Nullable<int> mobile { get; set; }
        public string dept { get; set; }
        public Nullable<int> sal { get; set; }
        public Nullable<int> zip { get; set; }
    }
}