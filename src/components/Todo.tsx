import React from "react";
import AddTodo from "./AddTodo";
import Todos from "./Todos";
import { Link } from "react-router-dom";

const Todo = () => {
  return (
    <>
      <div className="w-[500px] border border-gray-400 p-5 rounded-lg">
        <h1 className=" font-bold text-2xl">Welcome to Todo App</h1>
        <AddTodo />
        <Todos />
      </div>
      <Link to={"/weather"} className="mt-5 bg-white/60 text-black py-2 px-3 rounded-md text-lg">Get your weather here</Link>
    </>
  );
};

export default Todo;
