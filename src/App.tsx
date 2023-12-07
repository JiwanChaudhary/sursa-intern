import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Weather, { queryClient } from "./components/Weather";
import Todo from "./components/Todo";
import { QueryClientProvider } from "@tanstack/react-query";

function App() {
  return (
    <BrowserRouter>
    <QueryClientProvider client={queryClient}>
        <div className="w-full h-[100vh] flex flex-col justify-center items-center bg-gray-700 text-white text-center">
          <Routes>
            <Route path="/" Component={Todo} />
            <Route path="/weather" Component={Weather} />
          </Routes>
        </div>
    </QueryClientProvider>
      </BrowserRouter>
  );
}

export default App;
