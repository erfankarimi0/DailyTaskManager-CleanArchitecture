using System;
using System.Collections.Generic;
using DailyTaskManager.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

using InfraTask = DailyTaskManager.Infra.Data.Models.Task;

namespace DailyTaskManager.Infra.Data.Context;

public partial class DailyTaskManagerCleanContext : DbContext
{
    public DailyTaskManagerCleanContext()
    {
    }

    public DailyTaskManagerCleanContext(DbContextOptions<DailyTaskManagerCleanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InfraTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<InfraTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Priority).HasDefaultValueSql("'1'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
