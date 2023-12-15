import React, { useEffect } from "react";
import { Box, Button, Input, Text } from "@mantine/core";
import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { getSingleTodo, statusState } from "../lib/data";
import { useTodoContext } from "../context/TodoContext";
import { IconChevronDown } from "@tabler/icons-react";
import EditTodoForm from "./EditTodoForm";
import axios from "axios";

const EditTodo = () => {
  const { setEditTodo } = useTodoContext();

  const { todoId } = useParams();

  const singleTodo = useQuery({
    queryKey: ["single-todo"],
    queryFn: async () => {
      const res = await axios.get(
        `http://localhost:5252/api/todo/get/${todoId}`
      );
      setEditTodo(res.data);
    },
  });

  if (singleTodo.isLoading) return <>Loading...</>;
  if (singleTodo.fetchStatus === "fetching") return <>Fetching...</>;
  return (
    <>
      <EditTodoForm id={Number(todoId)} />
    </>
  );
};

export default EditTodo;
