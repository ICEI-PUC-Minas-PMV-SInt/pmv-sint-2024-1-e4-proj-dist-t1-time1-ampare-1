import { Container } from "@mui/material";
import { Footer } from "./componets/Footer";
import { Header } from "./componets/Header";
import { ProjetoForm } from "./pages/ProjetoForm";
import VisualizarONGs from "./pages/VisualizarONGs";

function App() {
  return (
    <>
      <Header />
      <Container>
        <ProjetoForm />
        <VisualizarONGs/>
        <CastroDeVoluntarios/>
      </Container>
      <Footer />
    </>
  );
}

export default App;
