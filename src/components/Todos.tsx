import React from "react";
import { useTodoContext } from "../context/TodoContext";
import UpdateTodo from "./UpdateTodo";
import CompleteTodo from "./CompleteTodo";

const Todos = () => {
  const { todoList, setTodoList, isChecked } = useTodoContext();

  return (
    // main section
    <section className="mt-5">
      <div className="p-4 border border-gray-300 rounded-lg">
        {/* all todo */}
        <h2 className="m-2 text-lg font-semibold">My Todo</h2>
        <hr />
        {todoList?.length === 0 ? (
          <div className=" m-2 text-lg">No todos</div>
        ) : (
          <>
            {todoList?.map((todo, index) => (
              <>
                <li
                  className="m-2 p-2 rounded-md flex items-center justify-between"
                  key={index}
                >
                  <span
                    className={`flex-[4] text-left ${
                      isChecked && "line-through text-red-600"
                    }`}
                  >
                    {todo}
                  </span>
                  {/* update button */}
                  <div className="flex flex-[2] justify-between items-center gap-2">
                    <UpdateTodo index={index} />

                    {/* delete button */}
                    <button
                      type="submit"
                      className="p-1 bg-red-700 rounded-md"
                      onClick={() =>
                        setTodoList(todoList.filter((item) => item !== todo))
                      }
                    >
                      Delete
                    </button>

                    {/* checkbox */}
                    <CompleteTodo index={index} />
                  </div>
                </li>
                <hr />
              </>
            ))}
          </>
        )}
      </div>
    </section>
  );
};

export default Todos;
