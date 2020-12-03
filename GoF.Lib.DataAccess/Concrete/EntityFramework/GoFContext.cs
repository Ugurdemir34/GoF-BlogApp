using GoF.Core.Entities.Concrete;
using GoF.Lib.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class GoFContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=*******;Database=******;User Id=*****;Password=********;");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }   
        public DbSet<Comment> Comments { get; set; }   
        public DbSet<SecondLevelComment> SecondLevelComments { get; set; }   
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AdminOperationClaim> UserOperationClaims { get; set; }
    }
}
