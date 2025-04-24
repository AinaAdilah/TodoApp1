using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp1.Core.Entities;
using TodoApp1.Application.Interfaces;

namespace TodoApp1.Application.Services
{
    public class TodoServices1
    {
        private readonly ITodoRepository1 _repository;

        public TodoServices1(ITodoRepository1 repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem1>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TodoItem1> AddTodoAsync(TodoItem1 todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
                throw new ArgumentException("Todo title cannot be empty.");

            return await _repository.AddAsync(todo);
        }

        public async Task<TodoItem1?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TodoItem1 todo)
        {
            await _repository.UpdateAsync(todo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
