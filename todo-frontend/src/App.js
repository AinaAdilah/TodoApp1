import React, { useState, useEffect } from 'react';
import { FaTrash, FaEdit, FaPlus } from 'react-icons/fa';
import './App.css';

function App() {
    const [todos, setTodos] = useState([]);
    const [newTodo, setNewTodo] = useState("");

    useEffect(() => {
        fetch('https://localhost:7268/api/Todo')
            .then(response => response.json())
            .then(data => setTodos(data))
            .catch(error => console.error('Error fetching data: ', error));
    }, []);

    const handleInputChange = (event) => {
        setNewTodo(event.target.value);
    };

    const handleAddTodo = (event) => {
        event.preventDefault();

        if (newTodo.trim() === "") return;

        const todo = { title: newTodo };

        fetch('https://localhost:7268/api/Todo', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(todo),
        })
            .then(response => response.json())
            .then(data => {
                setTodos([...todos, data]);
                setNewTodo("");
            })
            .catch(error => console.error('Error adding to-do list: ', error));
    };

    const handleDelete = (id) => {
        fetch(`https://localhost:7268/api/Todo/${id}`, {
            method: 'DELETE',
        })
            .then(() => {
                setTodos(todos.filter(todo => todo.id !== id));
            })
            .catch(error => console.error('Error deleting to-do list: ', error));
    };

    const handleUpdate = (id, newTitle) => {
        fetch(`https://localhost:7268/api/Todo/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id, title: newTitle }),
        })
            .then(() => {
                setTodos(todos.map(todo =>
                    todo.id === id ? { ...todo, title: newTitle } : todo
                ));
            })
            .catch(error => console.error('Error updating to-do list: ', error));
    };

    const handleToggle = (id) => {
       
        const updatedTodos = todos.map(todo =>
            todo.id === id ? { ...todo, completed: !todo.completed } : todo
        );

        setTodos(updatedTodos); 
    };

    return (
        <div className="App">
            <h1>To-do Checklist</h1>
            <form onSubmit={handleAddTodo}>
                <input
                    type="text"
                    value={newTodo}
                    onChange={handleInputChange}
                    placeholder="Enter new to-do list"
                />
                <button type="submit"><FaPlus /> Add</button>
            </form>

            <ul className="todo-list">
                {todos.map((todo) => (
                    <li key={todo.id} className="todo-item">
                        <input
                            type="checkbox"
                            checked={todo.completed}  
                            onChange={() => handleToggle(todo.id)} 
                        />
                        <span className={todo.completed ? 'completed' : ''}>{todo.title}</span>
                        <button onClick={() => handleDelete(todo.id)} title="Delete"><FaTrash /></button>
                        <button
                            onClick={() => {
                                const newTitle = prompt("Update list:", todo.title);
                                if (newTitle) handleUpdate(todo.id, newTitle);
                            }}
                            title="Edit"
                        >
                            <FaEdit />
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;
