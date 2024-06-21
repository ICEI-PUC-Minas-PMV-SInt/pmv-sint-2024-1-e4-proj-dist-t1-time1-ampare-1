import React, { useState, useEffect } from "react";
import { Typography, TextField, Button, Paper } from "@mui/material";
import styled from "@emotion/styled";
import axios from "axios";

// Styles for the NGO cards and form
const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
`;

const ONGContainer = styled.div`
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin-top: 20px;
`;

const ONGCard = styled.div`
  border: 1px solid #ccc;
  padding: 20px;
  margin: 10px;
  width: 300px;
`;

const ONGTitulo = styled.h2`
  font-weight: bold;
  margin-bottom: 10px;
`;

const ONGDescricao = styled.p`
  margin-bottom: 10px;
`;

const ONGContato = styled.p`
  font-style: italic;
`;

const FormContainer = styled(Paper)`
  padding: 20px;
  margin: 20px;
  width: 100%;
  max-width: 600px;
`;

export const VoluntarioForm = () => {
  const [ongs, setOngs] = useState([]);
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [telefone, setTelefone] = useState("");
  const [mensagem, setMensagem] = useState("");

  useEffect(() => {
    axios.get("https://your-api-endpoint/ongs") // Replace with your API endpoint
      .then((response) => {
        setOngs(response.data);
      })
      .catch((error) => {
        console.error("Erro ao obter ONGs da API:", error);
      });
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();
    // Handle form submission
    const voluntario = { nome, email, telefone, mensagem };
    console.log(voluntario);
    // Optionally, send this data to an API
    axios.post("https://your-api-endpoint/voluntarios", voluntario)
      .then((response) => {
        console.log("Voluntário cadastrado com sucesso:", response.data);
        // Clear form fields after submission
        setNome("");
        setEmail("");
        setTelefone("");
        setMensagem("");
      })
      .catch((error) => {
        console.error("Erro ao cadastrar voluntário:", error);
      });
  };

  return (
    <Container>
      <Typography variant="h3" gutterBottom>Visualizar ONGs</Typography>
      <ONGContainer>
        {ongs.map((ong) => (
          <ONGCard key={ong.id}>
            <ONGTitulo>{ong.nome}</ONGTitulo>
            <ONGDescricao>{ong.descricao}</ONGDescricao>
            <ONGContato>{ong.contato}</ONGContato>
          </ONGCard>
        ))}
      </ONGContainer>

      <FormContainer elevation={3}>
        <Typography variant="h4" gutterBottom>Cadastro de Voluntário</Typography>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Nome"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Telefone"
            value={telefone}
            onChange={(e) => setTelefone(e.target.value)}
            fullWidth
            margin="normal"
          />
          <TextField
            label="Mensagem"
            value={mensagem}
            onChange={(e) => setMensagem(e.target.value)}
            fullWidth
            margin="normal"
            multiline
            rows={4}
          />
          <Button variant="contained" color="primary" type="submit" style={{ marginTop: 20 }}>
            Enviar
          </Button>
        </form>
      </FormContainer>
    </Container>
  );
};