using AIScheduleUI5.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIScheduleUI5.DAL.EF
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
            // Intentionally no EnsureCreated() here:
            // it interferes with design-time `dotnet ef` and migrations workflows.
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<University> Universities { get; set; } = null!;
        public DbSet<Major> Majors { get; set; } = null!;
        public DbSet<StudyData> StudyData { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial universities and majors
            var tuWienId = Guid.Parse("4c15882b-6e1e-4140-94d2-6f4380a1eab2");
            var wuWienId = Guid.Parse("a246e01a-25c8-4a07-88a3-67c4132c1188");

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(200);
                b.Property(x => x.Email).HasMaxLength(320);
                b.Property(x => x.Password).HasMaxLength(500);

                b.HasMany(x => x.Schedules)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.StudyData)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<University>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(200);
                b.Property(x => x.Link).HasMaxLength(2000);

                b.HasMany(x => x.Majors)
                    .WithOne(x => x.University)
                    .HasForeignKey(x => x.UniId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.StudyData)
                    .WithOne(x => x.University)
                    .HasForeignKey(x => x.UniId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasData(
                    new University
                    {
                        Id = tuWienId,
                        Name = "TU Wien",
                        Link = "https://tiss.tuwien.ac.at/curriculum/studyCodes.xhtml?dswid=7598&dsrid=30"
                    },
                    new University
                    {
                        Id = wuWienId,
                        Name = "WU Wien",
                        Link = null
                    });
            });

            modelBuilder.Entity<Major>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(200);

                b.HasMany(x => x.StudyData)
                    .WithOne(x => x.Major)
                    .HasForeignKey(x => x.MajorId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasData(
                    new Major
                    {
                        Id = Guid.Parse("a6a5f195-2a56-4df1-a39b-0a4d3d8d9a97"),
                        UniId = tuWienId,
                        Name = "Informatik"
                    },
                    new Major
                    {
                        Id = Guid.Parse("c8be4d86-ec07-4a1e-85cd-6e60de9e0cd4"),
                        UniId = wuWienId,
                        Name = "WISO"
                    },
                    new Major
                    {
                        Id = Guid.Parse("a4baaa3f-7739-4750-b57f-7e24fc61346c"),
                        UniId = tuWienId,
                        Name = "Elektrotechnik"
                    },
                    new Major
                    {
                        Id = Guid.Parse("bd2c3b2d-1b25-4b72-bbb8-9ab3c2f15b3c"),
                        UniId = tuWienId,
                        Name = "Maschinenbau"
                    });

            });

            modelBuilder.Entity<StudyData>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Semester).IsRequired();

                b.HasOne(x => x.User)
                    .WithMany(x => x.StudyData)
                    .HasForeignKey(x => x.UserId);

                b.HasOne(x => x.University)
                    .WithMany(x => x.StudyData)
                    .HasForeignKey(x => x.UniId);

                b.HasOne(x => x.Major)
                    .WithMany(x => x.StudyData)
                    .HasForeignKey(x => x.MajorId);
            });

            modelBuilder.Entity<Schedule>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(200);
                b.Property(x => x.Info).HasMaxLength(4000);

                b.HasOne(x => x.User)
                    .WithMany(x => x.Schedules)
                    .HasForeignKey(x => x.UserId);
            });
        }
    }
}
