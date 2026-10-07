using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManager.Infra.Data.Models;

[Table("tasks")]
public partial class Task
{
    [Key]
    public int Id { get; set; }

    [StringLength(45)]
    public string Title { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public sbyte IsCompleted { get; set; }

    public int Priority { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }
}
