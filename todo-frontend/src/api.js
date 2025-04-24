const API_BASE_URL = "https://localhost:7268"; // Your backend URL

export async function getTodos() {
    const response = await fetch(`${API_BASE_URL}/api/Todo`);
    if (!response.ok) throw new Error("Failed to fetch todos");
    return response.json();
}

// You can add more like:
// export async function addTodo(todo) { ... }
// export async function deleteTodo(id) { ... }

