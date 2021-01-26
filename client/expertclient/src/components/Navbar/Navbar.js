import React, { useContext, useEffect } from "react";
import {
  Container,
  Menu,
  NavItem,
  AuthContainer,
  LoginText,
  StyledButton,
} from "./styled";
import { PagesContext } from "../../contexts/PagesContext";
import { UserContext } from "../../contexts/UserContext";
import AuthApi from "../../api/AuthApi";

import { withRouter } from "react-router-dom";
import { Link } from "react-router-dom";


const Navbar = (props) => {
  const { pages } = useContext(PagesContext);
  const { user, saveUser } = useContext(UserContext);

  const handleLogout = () => {
    AuthApi.logout();
    saveUser(null)
    props.history.push("/");
  };

  useEffect(() => {
    async function getCurrentUser() {
      await AuthApi.whoami().then(response => {
        if(response)
        {
          saveUser(response.data)
        }
      });
    }
    getCurrentUser();
  }, []);

  return (
    <Container>
      <AuthContainer>
        {user ? (
          <>
            <LoginText>Zalogowany jako: {user.login} ({user.accountType})</LoginText>
            <StyledButton to="/" onClick={handleLogout}>
              Wyloguj
            </StyledButton>
          </>
        ) : (
          <>
            <StyledButton to="/login">Zaloguj</StyledButton>
            <StyledButton to="/register">Rejestracja</StyledButton>
          </>
        )}
      </AuthContainer>
      <Menu>
        {pages.map((page) =>
          !page.role ? (
            <NavItem key={page.url}>
              <Link to={page.url}>
                <page.icon />
                {page.label}
              </Link>
            </NavItem> // PUBLIC NAVLINKS
          ) : user && user.accountType === page.role ? ( // PROTECTED NAVLINKS
            <NavItem key={page.url}>
              <Link to={page.url}>
                <page.icon />
                {page.label}
              </Link>
            </NavItem>
          ) : null
        )}
      </Menu>
    </Container>
  );
};

export default withRouter(Navbar);
