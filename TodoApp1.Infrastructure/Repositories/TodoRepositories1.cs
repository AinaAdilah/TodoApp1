using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp1.Application.Interfaces;
using TodoApp1.Core.Entities;
using TodoApp1.Infrastructure.Data;

namespace TodoApp1.Infrastructure.Repositories
{
    public class TodoRepositories1 : ITodoRepository1
    {
        private readonly TodoDBContext1 _context;

        public TodoRepositories1(TodoDBContext1 context)
        {
            _context = context;
        }

        public async Task<List<TodoItem1>> GetAllAsync() =>
            await _context.TodoItems.ToListAsync();

        public async Task<TodoItem1?> GetByIdAsync(int id) =>
            await _context.TodoItems.FindAsync(id);

        public async Task<TodoItem1> AddAsync(TodoItem1 item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
                return item;
        }

        public async Task UpdateAsync(TodoItem1 item)
        {
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
