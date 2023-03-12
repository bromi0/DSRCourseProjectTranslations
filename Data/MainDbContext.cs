using DsrCourseProjectTranslations.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsrCourseProjectTranslations.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TranslationRequest> Translations { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Language>().ToTable("languages");
            builder.Entity<Language>().Property(l => l.Name).IsRequired();
            builder.Entity<Language>().Property(l => l.Name).HasMaxLength(40);
            builder.Entity<Language>().HasIndex(l => l.Name).IsUnique();

            builder.Entity<Tag>().ToTable("tags");
            builder.Entity<Tag>().Property(t => t.Value).IsRequired();
            builder.Entity<Tag>().Property(t => t.Value).HasMaxLength(20);
            builder.Entity<Tag>().HasIndex(t => t.Value).IsUnique();


            builder.Entity<TranslationRequest>().ToTable("translations");
            builder.Entity<TranslationRequest>().HasMany<Tag>(r => r.Tags).WithMany(t => t.Translations).UsingEntity(t => t.ToTable("request_tags"));
            builder.Entity<TranslationRequest>().
                HasOne<Language>(r => r.SourceLanguage).
                WithMany(l => l.RequestsFromLanguage).
                HasForeignKey(r => r.SourceLanguageId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TranslationRequest>().
                HasOne<Language>(r => r.TargetLanguage).
                WithMany(l => l.RequestsToLanguage).
                HasForeignKey(r => r.TargetLanguageId).OnDelete(DeleteBehavior.Restrict);


        }

    }
}
