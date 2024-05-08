import { Container } from "@mui/material";
import { Footer } from "./componets/Footer";
import { Header } from "./componets/Header";
import { ProjetoForm } from "./pages/ProjetoForm";

function App() {
  return (
    <>
      <Header />
      <Container>
        <ProjetoForm />
      </Container>
      <Footer />
    </>
  );
}

export default App;
