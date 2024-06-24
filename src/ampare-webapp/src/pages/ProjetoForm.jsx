import {
  Autocomplete,
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import axios from "axios";
import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { toast } from 'react-toastify';

export const ProjetoForm = () => {
  const { register, handleSubmit, setValue, getValues } = useForm();
  const [ongList, setOngList] = React.useState([]);

  useEffect(() => {
    const fetchOngs = async () => {
      const { data } = await axios.get(`${import.meta.env.VITE_API_URL}/api/Ong`);
      setOngList(data);
    };
    fetchOngs();
  }, []);

  const onSubmit = async (data) => {
    await axios.post(`${import.meta.env.VITE_API_URL}/api/Projetos`, data).then(() => toast.success('Projeto cadastrado com sucesso!')).catch(() => toast.error('Erro ao cadastrar projeto!'));
  };

  return (
    <Grid container sx={{ my: 3 }}>
      <Grid item xs={12}>
        <Typography variant="h3">Cadastro de Projeto</Typography>
      </Grid>
      <Grid item xs={12}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Paper sx={{ my: 3, p: 4 }} variant="outlined">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <FormControl fullWidth size="medium">
                  <InputLabel htmlFor="select-ongs">ONG</InputLabel>
                  <Select
                    labelId="select-ongs"
                    id="select-ongs"
                    value={getValues("ongId")}
                    placeholder="Escolha uma ONG"
                    label="ONG"
                    onChange={(event) => {
                      setValue('ongId', event.target.value);
                    }}
                  >
                    {ongList.map(({ ongId, nome }) => (
                      <MenuItem value={ongId}>{nome}</MenuItem>
                    ))}
                  </Select>
                </FormControl>
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
