import { Container } from "@mui/material";
import { Footer } from "./componets/Footer";
import { Header } from "./componets/Header";
import { ProjetoForm } from "./pages/ProjetoForm";
import { OngForm } from "./pages/ONGForm";

function App() {
  return (
    <>
      <Header />
      <Container>
        <OngForm />
      </Container>
      <Footer />
    </>
  );
}

export default App;
