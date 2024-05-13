"use client";

import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import { useLogin } from "@refinedev/core";
import { ThemedTitleV2 } from "@refinedev/mui";
import Container from "@mui/material/Container";

import { AppIcon } from "@components/app-icon";

export default function Login() {
  const { mutate: login } = useLogin();

  return (
    <Container
      style={{
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Box
        display="flex"
        gap="36px"
        justifyContent="center"
        flexDirection="column"
      >
        <ThemedTitleV2
          collapsed={false}
          wrapperStyles={{
            fontSize: "22px",
            justifyContent: "center",
          }}
          text="Rookie Shop"
          icon={<AppIcon />}
        />

        <Button
          style={{ width: "240px" }}
          variant="contained"
          size="large"
          onClick={() => login({})}
        >
          Sign in
        </Button>
      </Box>
    </Container>
  );
}
