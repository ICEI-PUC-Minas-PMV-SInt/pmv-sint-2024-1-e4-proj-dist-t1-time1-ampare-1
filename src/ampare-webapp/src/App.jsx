import { Container } from "@mui/material";
import { Footer } from "./componets/Footer";
import { Header } from "./componets/Header";
import { OngForm } from "./pages/ONGForm";
// import VisualizarONGs from "./pages/VisualizarONGs";

function App() {
  return (
    <>
      <Header />
      <Container>
        <OngForm />

        {/* <VisualizarONGs /> */}
      </Container>
      <Footer />
    </>
  );
}

export default App;
