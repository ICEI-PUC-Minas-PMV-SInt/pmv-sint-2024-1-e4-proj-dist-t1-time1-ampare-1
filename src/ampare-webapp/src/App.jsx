import { Container } from "@mui/material";
import { Footer } from "./componets/Footer";
import { Header } from "./componets/Header";
import { OngForm } from "./pages/OngForm";
import { ProjetoVoluntario } from "./pages/ProjetoVoluntario";
import { Route, Routes } from "react-router-dom";
import { Home } from "./componets/Home";
import { ProjetoForm } from "./pages/ProjetoForm";
import { VoluntarioForm } from "./pages/VoluntarioForm";



function App() {
  return (
    <>
      <Header />
      <Container>
        <Routes>
          <Route index element={<Home />} />
          <Route path="/cadastro-ong" element={<OngForm />} />
          <Route path="/cadastro-voluntario" element={<VoluntarioForm />} />
          <Route path="/cadastro-projeto" element={<ProjetoForm />} />
          <Route path="/listagem-projetos" element={<ProjetoVoluntario />} />
        </Routes>
      </Container>
      <Footer />
    </>
  );
}

export default App;
