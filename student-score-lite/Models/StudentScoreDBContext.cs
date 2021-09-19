using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace student_score_lite.Models
{
    public class StudentScoreDBContext : DbContext
    {
        public DbSet<Score> Score { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}