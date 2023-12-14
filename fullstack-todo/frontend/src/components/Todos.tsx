import React from "react";
import { Box, Text } from "@mantine/core";
import CommonButton from "../common/Button";
import classes from "../styles/Todos.module.css";
import TableData from "../common/Table";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const Todos = () => {
  const queryClient = new QueryClient();

  return (
    <>
      <Text size="lg" fw={700} c={"blue"} tt={"uppercase"}>
        Welcome To Todo
      </Text>
      <Box className={classes.TodoBox}>
        <Text size="lg" fw={700} c={"blue"} tt={"uppercase"}>
          My Todos
        </Text>
        <CommonButton props={{ btnTitle: "Create Todo" }} />
      </Box>
      <hr />
      <Box>
        <QueryClientProvider client={queryClient}>
          <TableData />
        </QueryClientProvider>
      </Box>
    </>
  );
};

export default Todos;
