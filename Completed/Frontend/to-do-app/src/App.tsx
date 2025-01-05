import { useEffect, useState } from "react";
import { Todo } from "./components/Todo";
import { axiosInstance } from "./utils/axiosInstance";

export interface Todo {
  id: number;
  content: string;
  isCompleted: boolean;
}

function App() {
  const [todos, setTodos] = useState<Todo[]>([]);

  useEffect(() => {
    getTodos();
  }, []);

  const getTodos = async () => {
    try {
      let response = await axiosInstance.get("/Todos/GetTodos");
      if (response.data) {
        setTodos(response.data);
      } else {
        console.log(response);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const addTodo = async () => {
    try {
      let response = await axiosInstance.post("/Todos/CreateTodo", {
        content: "empty todo",
      });
      if (response.data) {
        setTodos((prevState) => [...prevState, response.data]);
      } else {
        console.log(response);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const deleteTodo = async (id: number) => {
    try {
      let response = await axiosInstance.delete(`/Todos/DeleteTodo?id=${id}`);
      if (response.status === 204) {
        setTodos((prevState) => prevState.filter((x) => x.id != id));
      } else {
        console.log(response);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const updateTodo = async (
    id: number,
    content: string,
    isCompleted: boolean
  ) => {
    try {
      let response = await axiosInstance.post("/Todos/UpdateTodo", {
        id: id,
        content: content,
        isCompleted: isCompleted,
      });
      if (response.data) {
        setTodos((prevState) =>
          prevState.map((item) => {
            if (item.id == id) {
              return response.data;
            }
            return item;
          })
        );
      } else {
        console.log(response);
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div style={{ height: "90vh", overflow: "auto" }}>
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <h2>Yapılacaklar Listesi</h2>
        <button onClick={() => addTodo()} style={{ marginLeft: "5px" }}>
          Görev Ekle
        </button>
      </div>
      <hr />
      {todos.length > 0 ? (
        todos.map((todo) => (
          <Todo
            key={todo.id}
            content={todo.content}
            isCompleted={todo.isCompleted}
            onCheckChange={(checked) =>
              updateTodo(todo.id, todo.content, checked)
            }
            onContentChange={(newContent) =>
              updateTodo(todo.id, newContent, todo.isCompleted)
            }
            onDeleteClick={() => deleteTodo(todo.id)}
          />
        ))
      ) : (
        <>No Data</>
      )}
    </div>
  );
}

export default App;
