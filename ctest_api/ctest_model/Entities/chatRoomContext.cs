using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ctest_model.Entities
{
    public partial class chatRoomContext : DbContext
    {
        public chatRoomContext()
        {
        }

        public chatRoomContext(DbContextOptions<chatRoomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatLog> ChatLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=35.236.165.181;port=3306;user=root;password=ga700807;database=chatRoom", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<ChatLog>(entity =>
            {
                entity.ToTable("chatLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(45)
                    .HasColumnName("displayName");

                entity.Property(e => e.LogTime)
                    .HasColumnType("datetime")
                    .HasColumnName("logTime");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .HasColumnName("userName");

                entity.Property(e => e.UserType).HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
