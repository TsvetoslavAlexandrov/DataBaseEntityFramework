namespace Eventimi.Infrastructure.Data;

using Eventimi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Контекст, описващ базата данни
/// </summary>
public class EventmiDbContext : DbContext
{
    /// <summary>
    /// Създава контекст без настройки
    /// </summary>
    public EventmiDbContext()
    {

    }

    /// <summary>
    /// Създава контекст с преварителни натройки 
    /// </summary>
    /// <param name="options"></param>
    public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
        :base(options)
    {
        
    }
    /// <summary>
    /// Таблица със събития
    /// </summary>
    public DbSet<Event> Events { get; set; } = null!;
    
}
