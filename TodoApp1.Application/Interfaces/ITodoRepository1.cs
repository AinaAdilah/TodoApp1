using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp1.Core.Entities;

namespace TodoApp1.Application.Interfaces
{
    public interface ITodoRepository1
    {
        Task<List<TodoItem1>> GetAllAsync();
        Task<TodoItem1?> GetByIdAsync(int id);
        ///Task AddAsync(TodoItem1 item);
        Task<TodoItem1> AddAsync(TodoItem1 todo);
        Task UpdateAsync(TodoItem1 item);
        Task DeleteAsync(int id);
    }
}
