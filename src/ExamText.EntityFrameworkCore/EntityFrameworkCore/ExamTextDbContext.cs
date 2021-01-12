using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ExamText.Authorization.Roles;
using ExamText.Authorization.Users;
using ExamText.MultiTenancy;
using ExamText.Examinees;
using ExamText.ExamCompletions;
using ExamText.ExamShortAnswerQuestions;
using ExamText.ExamTestPapers;
using ExamText.ExamChoiceQuestions;

namespace ExamText.EntityFrameworkCore
{
    public class ExamTextDbContext : AbpZeroDbContext<Tenant, Role, User, ExamTextDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Examinee> Examinees { get; set; }

        public virtual DbSet<ExamCompletion> ExCompletions { get; set; }

        public virtual DbSet<ExamChoiceQuestion> ExamQuestions { get; set; }

        public virtual DbSet<ExamShortAnswerQuestion> ExamShortAnswerQuestions { get; set; }

        public virtual DbSet<ExamTestPaper> ExamTestPapers { get; set; }

        public ExamTextDbContext(DbContextOptions<ExamTextDbContext> options)
            : base(options)
        {
        }
    }
}
