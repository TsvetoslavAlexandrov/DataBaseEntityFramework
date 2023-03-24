namespace Eventimi.Infrastructure.Data.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 /// <summary>
 /// Събития
 /// </summary>
[Comment("Събития")]

public class Event
{
    /// <summary>
    /// Идентификатор на запис
    /// </summary>
    [Key]
    [Comment("Идентификатор на запис")]
    public int Id { get; set; }

    /// <summary>
    ///   Име на събитието  
    /// </summary>
    [Required]
    [StringLength(50)]
    [Comment("Име на събитието")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    [Comment("Цена")]
    public decimal Price { get; set; }
    /// <summary>
    /// Начална дата и час
    /// </summary>
    [Required]
    [Comment("Начална дата и час")]
    public DateTime Start { get; set; }

    /// <summary>
    /// Крайна дата и час
    /// </summary>
    [Required]
    [Comment("Крайна дата и час")]
    public DateTime End { get; set; }

    /// <summary>
    /// Място на провеждането
    /// </summary>
    [Required]
    [StringLength(100)]
    [Comment("Място на провеждането")]
    public string Place { get; set; } = null!;
}
