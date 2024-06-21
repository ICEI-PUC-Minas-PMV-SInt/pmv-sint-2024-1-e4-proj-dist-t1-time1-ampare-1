import React from "react";
import { Grid, Paper, Typography } from "@mui/material";
import axios from "axios";
import styled from "styled-components";

// Styles for the NGO cards
const Container = styled.div`
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  padding: 20px;
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

function VisualizarONGs() {
  const [ongs, setOngs] = useState([]);

  useEffect(() => {
    axios.get("https://your-api-endpoint/ongs") // Replace with your API endpoint
      .then((response) => {
        setOngs(response.data);
      })
      .catch((error) => {
        console.error("Erro ao obter ONGs da API:", error);
      });
  }, []);

  return (
    <div>
      <Typography variant="h3">Visualizar ONGs</Typography>
      <Container>
        {ongs.map((ong) => (
          <ONGCard key={ong.id}>
            <ONGTitulo>{ong.nome}</ONGTitulo>
            <ONGDescricao>{ong.descricao}</ONGDescricao>
            <ONGContato>{ong.contato}</ONGContato>
          </ONGCard>
        ))}
      </Container>
    </div>
  );
}

export default VisualizarONGs;