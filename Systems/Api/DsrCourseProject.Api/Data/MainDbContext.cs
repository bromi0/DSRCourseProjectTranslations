using DsrCourseProjectTranslations.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsrCourseProjectTranslations.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TranslationRequest> Translations { get; set; }
        public DbSet<TranslationAnswer> Answers { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");
                entity.Property(l => l.Name).IsRequired();
                entity.Property(l => l.Name).HasMaxLength(40);
                entity.HasIndex(l => l.Name).IsUnique();
            });

            builder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");
                entity.Property(t => t.Value).IsRequired();
                entity.Property(t => t.Value).HasMaxLength(20);
                entity.HasIndex(t => t.Value).IsUnique();
            });

            builder.Entity<TranslationRequest>(entity =>
            {
                entity.ToTable("translations");
                entity.HasMany<Tag>(r => r.Tags).WithMany(t => t.Translations).UsingEntity(t => t.ToTable("request_tags"));
                entity.
                    HasOne<Language>(r => r.SourceLanguage).
                    WithMany(l => l.RequestsFromLanguage).
                    HasForeignKey(r => r.SourceLanguageId).OnDelete(DeleteBehavior.Restrict);
                entity.
                    HasOne<Language>(r => r.TargetLanguage).
                    WithMany(l => l.RequestsToLanguage).
                    HasForeignKey(r => r.TargetLanguageId).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TranslationAnswer>(entity =>
            {
                entity.ToTable("answers");
                entity.HasOne<TranslationRequest>(a => a.Request).
                    WithMany(r => r.Answers).
                    HasForeignKey(a => a.TranslationRequestId).OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
