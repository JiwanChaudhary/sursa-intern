import React from "react";
import "@mantine/core/styles.css";
import Todos from "./components/Todos";
import TodoContextProvider from "./context/TodoContext";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Form from "./common/Form";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

function App() {
  const queryClient = new QueryClient();

  return (
    <>
      <BrowserRouter>
        <TodoContextProvider>
          <QueryClientProvider client={queryClient}>
            <Routes>
              <Route path="/" Component={Todos} />
              <Route path="/create-todo" Component={Form} />
            </Routes>
          </QueryClientProvider>
        </TodoContextProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
