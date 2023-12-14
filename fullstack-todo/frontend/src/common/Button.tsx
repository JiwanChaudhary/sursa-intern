import React from "react";
import { Button } from "@mantine/core";
// import Form from "./Form";
import { Link } from "react-router-dom";

type CommonButtonProps = {
  btnTitle: string;
};

const CommonButton = ({ props }: { props: CommonButtonProps }) => {
  return (
    <>
      <Link to={"/create-todo"}>
        <Button>{props.btnTitle}</Button>
      </Link>
    </>
  );
};

export default CommonButton;
