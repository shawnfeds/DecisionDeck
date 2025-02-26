using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DecisionDeck.Models;

public partial class DecisionDeckContext : DbContext
{
    public DecisionDeckContext()
    {
    }

    public DecisionDeckContext(DbContextOptions<DecisionDeckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlreadyVoted> AlreadyVoteds { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Poll> Polls { get; set; }

    public virtual DbSet<PollOption> PollOptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlreadyVoted>(entity =>
        {
            entity.HasKey(e => e.AlreadyVotedId).HasName("PK__AlreadyV__D204EAB749DB3492");

            entity.ToTable("AlreadyVoted");

            entity.HasIndex(e => new { e.UserId, e.PollId }, "UQ__AlreadyV__A991854988DED23F").IsUnique();

            entity.Property(e => e.AlreadyVotedId).HasColumnName("AlreadyVotedID");
            entity.Property(e => e.PollId).HasColumnName("PollID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Poll).WithMany(p => p.AlreadyVoteds)
                .HasForeignKey(d => d.PollId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlreadyVo__PollI__29572725");

            entity.HasOne(d => d.User).WithMany(p => p.AlreadyVoteds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlreadyVo__UserI__286302EC");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF30A114506C3");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupName).HasMaxLength(100);
        });

        modelBuilder.Entity<Poll>(entity =>
        {
            entity.HasKey(e => e.PollId).HasName("PK__Polls__E1949E4A5FCF578A");

            entity.Property(e => e.PollId).HasColumnName("PollID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.PollEndDate).HasColumnType("datetime");
            entity.Property(e => e.PollName).HasMaxLength(100);

            entity.HasOne(d => d.Group).WithMany(p => p.Polls)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Polls__GroupID__182C9B23");
        });

        modelBuilder.Entity<PollOption>(entity =>
        {
            entity.HasKey(e => e.PollOptionId).HasName("PK__PollOpti__03F0E9C44ED8567D");

            entity.Property(e => e.PollOptionId).HasColumnName("PollOptionID");
            entity.Property(e => e.OptionName).HasMaxLength(100);
            entity.Property(e => e.PollId).HasColumnName("PollID");
            entity.Property(e => e.SelectedCount).HasDefaultValue(0);

            entity.HasOne(d => d.Poll).WithMany(p => p.PollOptions)
                .HasForeignKey(d => d.PollId)
                .HasConstraintName("FK__PollOptio__PollI__1BFD2C07");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AC25FF1FE");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACC153A811");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.Users)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Users__GroupID__15502E78");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__145C0A3F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
