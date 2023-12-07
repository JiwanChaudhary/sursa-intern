import React from "react";
import { Badge, Card, Group, Text } from "@mantine/core";

const WeatherComponent = () => {
  return (
    <Card shadow="sm" padding="lg" radius="md" withBorder m="xl">
      <Group justify="space-between" mt="md" mb="xs">
        <Text fw={500}>Current Temperature: </Text>
        <Badge color="pink">
          30 degree Celcius
        </Badge>
      </Group>
    </Card>
  );
};

export default WeatherComponent;
