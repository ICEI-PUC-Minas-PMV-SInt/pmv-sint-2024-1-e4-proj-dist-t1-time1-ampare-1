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
import { toast } from 'react-toastify';

export const OngForm = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = async (data) => {
    await axios.post(`${import.meta.env.VITE_API_URL}/api/Ong`, data).then(() => toast.success('ONG cadastrada com sucesso!')).catch(() => toast.error('Erro ao cadastrar ONG!'));
    console.log(data);
  };

  return (
    <Grid container sx={{ my: 3 }}>
      <Grid item xs={12}>
        <Typography variant="h3">Cadastro de ONG</Typography>
      </Grid>
      <Grid item xs={12}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Paper sx={{ my: 3, p: 4 }} variant="outlined">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Nome"
                  placeholder="Qual o nome da sua ONG?"
                  {...register("Nome")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Razão Social"
                  {...register("razaoSocial")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField fullWidth label="Cnpj" {...register("Cnpj")} />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Email"
                  placeholder="Informe um email válido"
                  {...register("Email")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Senha"
                  type="password"
                  {...register("Senha")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Telefone"
                  placeholder="(XX) XXXX-XXXX"
                  {...register("Telefone")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Endereço"
                  {...register("Endereco")}
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
