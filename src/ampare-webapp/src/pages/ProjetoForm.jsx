import {
  Autocomplete,
  Button,
  Grid,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import axios from "axios";
import React from "react";
import { useForm } from "react-hook-form";

const ongMockedList = [
  { id: 1, label: "OXFAM" },
  { id: 2, label: "Catapiri" },
  { id: 3, label: "APATA" },
];

export const ProjetoForm = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = async (data) => {
    await axios.post(import.meta.env.VITE_API_URL, data);
    console.log(data);
  };

  return (
    <Grid container sx={{ my: 3 }}>
      <Grid item xs={12}>
        <Typography variant="h3">Projeto</Typography>
      </Grid>
      <Grid item xs={12}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Paper sx={{ my: 3, p: 4 }} variant="outlined">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <Autocomplete
                  disablePortal
                  id="ong-selector"
                  options={ongMockedList}
                  sx={{ width: 300 }}
                  renderInput={(params) => (
                    <TextField {...params} label="ONG" />
                  )}
                  {...register("ongId")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Nome do projeto"
                  placeholder="Qual o nome do seu projeto?"
                  {...register("projectName")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  label="Descrição"
                  placeholder="Descreva o seu projeto em poucas frases"
                  multiline
                  fullWidth
                  {...register("description")}
                />
              </Grid>
              <Grid item>
                <Button variant="contained" type="submit" disableElevation>
                  Salvar
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </form>
      </Grid>
    </Grid>
  );
};
