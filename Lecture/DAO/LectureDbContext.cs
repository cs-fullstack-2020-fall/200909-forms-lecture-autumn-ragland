using Microsoft.EntityFrameworkCore;
using Lecture.Models;
namespace Lecture.DAO
{
    public class LectureDbContext : DbContext
    {
        public LectureDbContext(DbContextOptions<LectureDbContext> options) : base (options)
        {
        }
        // add db set(s)
        public DbSet<WriterModel> writers {get;set;}
    }
}