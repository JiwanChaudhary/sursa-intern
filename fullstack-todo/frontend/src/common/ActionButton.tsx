import { Button } from "@mantine/core";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import React from "react";
import { deleteTodo } from "../lib/data";

type ActionButtonProps = {
  btnTitle: string;
  bgColor: string;
  itemId: number;
  btnType: string;
};

const ActionButton = ({ props }: { props: ActionButtonProps }) => {
  const queryClient = useQueryClient();

  const deleteMutation = useMutation({
    mutationFn: deleteTodo,
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["delete-todo"] }),
  });
  // handleDelete
  const handleDelete = (id: number) => {
    deleteMutation.mutate(id);
  };

  // handleEdit
  const handleEdit = (id: number) => {
    console.log("edit ", id);
  };

  return (
    <Button
      onClick={() => {
        props.btnType === "delete"
          ? handleDelete(props.itemId)
          : handleEdit(props.itemId);
      }}
      bg={props.bgColor}
    >
      {props.btnTitle}
    </Button>
  );
};

export default ActionButton;
