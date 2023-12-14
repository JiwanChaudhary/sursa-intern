import React, { useEffect } from "react";
import { Table } from "@mantine/core";
import { useTodoContext } from "../context/TodoContext";
import { useQuery } from "@tanstack/react-query";
import { getAllTodos, getStatusString } from "../lib/data";
import ActionButton from "./ActionButton";

const TableData = () => {
  const { todo, setTodo } = useTodoContext();

  const getTodos = useQuery({
    queryKey: ["getAllTodos"],
    queryFn: getAllTodos,
  });

  useEffect(() => {
    if (getTodos.isSuccess) {
      setTodo(getTodos.data);
    }
  }, [getTodos]);

  const rows = todo.map((item) => (
    <Table.Tr key={item.todoId}>
      <Table.Td>{item.todoTitle}</Table.Td>
      <Table.Td>{item.description}</Table.Td>
      <Table.Td>{getStatusString(item.todoStatus)}</Table.Td>
      <Table.Td>{item.categoryName}</Table.Td>
      <Table.Td style={{ display: "flex", gap: "5px" }}>
        <ActionButton
          props={{ btnTitle: "Delete", bgColor: "red", itemId: item.todoId, btnType: "delete" }}
        />
        <ActionButton
          props={{ btnTitle: "Edit", bgColor: "blue", itemId: item.todoId, btnType: "edit" }}
        />
      </Table.Td>
    </Table.Tr>
  ));

  return (
    <Table>
      {/* head */}
      <Table.Thead>
        <Table.Tr>
          <Table.Th>Title</Table.Th>
          <Table.Th>Description</Table.Th>
          <Table.Th>Status</Table.Th>
          <Table.Th>Category</Table.Th>
          <Table.Th>Action</Table.Th>
        </Table.Tr>
      </Table.Thead>
      {/* body */}
      <Table.Tbody>{rows}</Table.Tbody>
    </Table>
  );
};

export default TableData;
