using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace student_score_lite.Models
{
    public class Score
    {
        public int id { get; set; }
        public decimal grade { get; set; }
        public int idTest { get; set; }
        public int idStudent { get; set; }
    }
}