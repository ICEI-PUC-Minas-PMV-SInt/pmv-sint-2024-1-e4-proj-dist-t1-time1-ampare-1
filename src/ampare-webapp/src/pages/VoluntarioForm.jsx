import React, { useState, useEffect } from "react";
import {
  Button,
  Grid,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import axios from "axios";
import { useForm } from "react-hook-form";
import { toast } from 'react-toastify';

const CadastroDeVoluntarios = () => {
  const [ongs, setOngs] = useState([]);
  const { register, handleSubmit, reset } = useForm();

  useEffect(() => {
    axios.get(`${import.meta.env.VITE_API_URL}/api/ongs`)
      .then((response) => {
        setOngs(response.data);
      })
      .catch((error) => {
        console.error("Erro ao obter ONGs da API:", error);
      });
  }, []);

  const onSubmit = async (data) => {
    await axios.post(`${import.meta.env.VITE_API_URL}/api/voluntarios`, data)
      .then((response) => {
        toast.success('Voluntário cadastrado com sucesso!');
        reset();
      })
      .catch((error) => {
        toast.error('Erro ao cadastrar voluntário!');
        console.error("Erro ao cadastrar voluntário:", error);
      });
  };

  return (
    <Grid container sx={{ my: 3 }}>
      <Grid item xs={12}>
        <Typography variant="h3">Visualizar ONGs</Typography>
      </Grid>
      <Grid item xs={12}>
        <Grid container spacing={2}>
          {ongs.map((ong) => (
            <Grid item key={ong.id} xs={12} sm={6} md={4}>
              <Paper sx={{ p: 2 }}>
                <Typography variant="h5" component="h3">{ong.nome}</Typography>
                <Typography variant="body2">{ong.descricao}</Typography>
                <Typography variant="body2" sx={{ fontStyle: 'italic' }}>{ong.contato}</Typography>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Grid>

      <Grid item xs={12}>
        <Typography variant="h3">Cadastro de Voluntário</Typography>
      </Grid>
      <Grid item xs={12}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Paper sx={{ my: 3, p: 4 }} variant="outlined">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Nome"
                  {...register("nome")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Email"
                  type="email"
                  {...register("email")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Telefone"
                  {...register("telefone")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Endereço"
                  multiline
                  rows={4}
                  {...register("endereco")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Senha"
                  type="password"
                  {...register("senha")}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="CPF"
                  {...register("cpf")}
                />
              </Grid>
              <Grid item>
                <Button variant="contained" type="submit" disableElevation>
                  Enviar
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </form>
      </Grid>
    </Grid>
  );
};

export default CadastroDeVoluntarios;
