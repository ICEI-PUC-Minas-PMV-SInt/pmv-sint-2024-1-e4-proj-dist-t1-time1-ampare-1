import {
    Autocomplete,
    Button,
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
    DialogTitle,
    FormControl,
    Grid,
    InputLabel,
    MenuItem,
    Paper,
    Select,
    Typography,
} from "@mui/material";
import axios from "axios";
import React, { useEffect, useState } from "react";
import { toast } from 'react-toastify';

export const ProjetoVoluntario = () => {
    const [projetos, setProjetos] = useState([]);
    const [voluntarios, setVoluntarios] = useState([]);
    const [projetoSelecionado, setProjetoSelecionado] = useState(null);
    const [voluntarioSelecionado, setVoluntarioSelecionado] = useState(null);
    const [openConfirmation, setOpenConfirmation] = useState(false);

    useEffect(() => {
        const fetchProjetos = async () => {
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/api/Projetos`);
            setProjetos(response.data);
        };

        const fetchVoluntarios = async () => {
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/api/voluntarios`);
            setVoluntarios(response.data);
        };

        fetchProjetos();
        fetchVoluntarios();
    }, []);

    const handleInscricao = async () => {
        await axios
            .post(`${import.meta.env.VITE_API_URL}/api/ProjetoVoluntario`, { ProjetoId: projetoSelecionado, VoluntarioId: voluntarioSelecionado })
            .then(() => { toast.success("Voluntário cadastrado com sucesso no projeto!") })
            .catch(() => toast.error("Erro ao cadastrar voluntário no projeto!"));
        handleConfirmation();
    };

    const handleConfirmation = () => {
        setOpenConfirmation(!openConfirmation);
    }

    return (
        <>
            <Dialog maxWidth={'sm'} fullWidth open={openConfirmation} setOpenConfirmation={setOpenConfirmation}>
                <DialogTitle>Confirmação</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        <FormControl fullWidth size="medium">
                            <InputLabel htmlFor="select-voluntario">Voluntário</InputLabel>
                            <Select
                                labelId="select-voluntario-label-id"
                                id="select-voluntario"
                                value={voluntarioSelecionado}
                                placeholder="Escolha um voluntário"
                                label="Voluntário"
                                onChange={(event) => {
                                    setVoluntarioSelecionado(event.target.value)
                                }}
                            >
                                {voluntarios.map(({ voluntarioId, nome }) => (
                                    <MenuItem value={voluntarioId}>{nome}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleConfirmation}>Cancelar</Button>
                    <Button onClick={handleInscricao}>Confirmar</Button>
                </DialogActions>
            </Dialog>
            <Grid container sx={{ my: 3 }} spacing={2}>
                <Grid item xs={12}>
                    <Typography variant="h3">Ajude um Projeto</Typography>
                </Grid>
                {projetos.map((projeto, index) => (
                    <Grid item xs={6} key={index}>
                        <Paper sx={{ my: 3, p: 4 }} variant="outlined">
                            <Typography variant="h5">{projeto.projectName}</Typography>
                            <Typography variant="body1">{projeto.description}</Typography>
                            <Button variant="contained" onClick={() => {
                                setProjetoSelecionado(projeto.projetoId);
                                handleConfirmation();
                            }
                            } disableElevation>
                                Inscrever-se
                            </Button>
                        </Paper>
                    </Grid>
                ))}
            </Grid>
        </>
    );
};
