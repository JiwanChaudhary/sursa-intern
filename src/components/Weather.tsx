// import React from "react";
import { QueryClient, useQuery } from "@tanstack/react-query";
import axios from "axios";
import { useEffect, useState } from "react";
import WeatherComponent from "./WeatherComponent";
import { Button, Input } from "@mantine/core";

type ApiDataProps = {
  sys: {
    country: string;
  };
};

// const apiKey = "16c0c2743ef9f95d8d0530f7ea8150be";

// query client
export const queryClient = new QueryClient();

// query key
const queryKey = ["weatherAPI"];

const Weather = () => {
  const [apiData, setApiData] = useState<ApiDataProps | null>(null);
  const [country, setCountry] = useState<string>("nepal");

  const url = `https://api.openweathermap.org/data/2.5/weather?q=${country}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`;

  const weather = useQuery({
    queryKey,
    queryFn: async () => {
      const res = await axios.get(url);
      const data = res.data;
      return data;
    },
  });

  //   run when weather is available
  useEffect(() => {
    if (weather.isSuccess) {
      setApiData(weather.data);
    } else if (weather.isError) {
      console.error(weather.error.message);
    }
  }, [weather]);
  console.log(apiData);

  //   loading
  if (weather.isLoading) return <div>"Loading..."</div>;

  //   error
  if (weather.isError)
    return <div>Something went wrong: {weather.error.message}</div>;

  return (
    <div>
      <div className="mb-5">
        <h1 className=" text-2xl">Weather Data</h1>
        <div className="flex gap-2 bg-yellow-400">
          <Input size="md" placeholder="Enter Country Name" value={country} />
          <Button variant="filled" color="indigo" size="md" radius="xl">
            Button
          </Button>
        </div>
      </div>
      <WeatherComponent />
    </div>
  );
};

export default Weather;
