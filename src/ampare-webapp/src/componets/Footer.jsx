import { AppBar, Box, Toolbar } from "@mui/material";
import { grey } from "@mui/material/colors";
import React from "react";

export const Footer = () => {
  return (
    <Box position={"fixed"} bottom={0} width={"100%"}>
      <Toolbar sx={{ bgcolor: grey[300] }}>
        Copyright &copy; 2024 - Ampare
      </Toolbar>
    </Box>
  );
};
