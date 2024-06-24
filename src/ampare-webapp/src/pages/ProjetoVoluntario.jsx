import {
    Button,
    Grid,
    Paper,
    Typography,
} from "@mui/material";
import axios from "axios";
import React, { useEffect, useState } from "react";

export const ProjetoVoluntario = () => {
    const [projetos, setProjetos] = useState([]);

    useEffect(() => {
        const fetchProjetos = async () => {
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/api/ProjetoVoluntario`);
            setProjetos(response.data);
        };

        fetchProjetos();
    }, []);

    const handleInscricao = (projetoId) => {

        console.log(`Inscrição para o projeto ${projetoId} realizada!`);
    };

    return (
        <Grid container sx={{ my: 3 }} spacing={2}>
            <Grid item xs={12}>
                <Typography variant="h3">Ajude um Projeto</Typography>
            </Grid>
            {projetos.map((projeto, index) => (
                <Grid item xs={6} key={index}>
                    <Paper sx={{ my: 3, p: 4 }} variant="outlined">
                        <Typography variant="h5">{projeto.nome}</Typography>
                        <Typography variant="body1">{projeto.descricao}</Typography>
                        <Button variant="contained" onClick={() => handleInscricao(projeto.id)} disableElevation>
                            Inscrever-se
                        </Button>
                    </Paper>
                </Grid>
            ))}
        </Grid>
    );
};
