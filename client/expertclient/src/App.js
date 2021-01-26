import React from "react";
import AppRouter from "../src/components/AppRouter/AppRouter";
import PagesContextProvider from "../src/contexts/PagesContext";
import UserContextProvider from "../src/contexts/UserContext";
import styled, { ThemeProvider, createGlobalStyle } from "styled-components";
import { BrowserRouter as Router } from "react-router-dom";
import Navbar from "../src/components/Navbar";
import { theme } from "./utils/theme";

const GlobalStyle = createGlobalStyle`
  * , *::before, *::after{
    box-sizing: border-box;
    margin: 0;
    padding: 0;
    font-family: 'Alegreya', serif;
  }

  body {
    width: 100vw;
    height: 100vh;
  }

`;

const Container = styled.div`
  display: flex;
  min-width: 100vh;
  background: url("./images/background.jpg");
  background-size: cover;
`;

const App = () => {
  return (
    <React.Fragment>
      <GlobalStyle />
      <ThemeProvider theme={theme}>
        <PagesContextProvider>
          <UserContextProvider>
            <Router>
              <Container>
                <Navbar />
                <AppRouter />
              </Container>
            </Router>
          </UserContextProvider>
        </PagesContextProvider>
      </ThemeProvider>
    </React.Fragment>
  );
};

export default App;
