using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp1.Core.Entities;

namespace TodoApp1.Infrastructure.Data
{
    public class TodoDBContext1 : DbContext
    {
        public TodoDBContext1(DbContextOptions<TodoDBContext1> options) : base(options) { }
        public DbSet<TodoItem1> TodoItems { get; set; }
        //public DbSet<TodoItem1> TodoItems => Set<TodoItem1>();
    }
}
