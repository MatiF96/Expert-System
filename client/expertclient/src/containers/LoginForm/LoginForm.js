import React, { useState, useContext } from 'react';
import {Container, CenterContainer, StyledForm,  Text, StyledButton, Label, Alert, Message} from './styled';
import { withRouter } from "react-router-dom"
import AuthApi from '../../api/AuthApi'
import {UserContext} from '../../contexts/UserContext';

const LoginForm = (props) => {

  const [login, setLogin] = useState('')
  const [password, setPassword] = useState('')
  const [showAlert, setShowAlert] = useState(false)
  const { saveUser } = useContext(UserContext);

  const handleSubmit = (e) => {
    e.preventDefault()
    
    AuthApi.login(login,password).then(
    response => {
      saveUser(response)
      props.history.push("/");
    },
    error => {
      console.log(error)
      setShowAlert(true)
    })
  }

  const handleChange = (e) => {
    setShowAlert(false)
    const { target } = e;
    const { name, value } = target;

    name==="login"?
    setLogin(value):
    setPassword(value)
  };

  return (
    <Container>
      <CenterContainer>
        <Message>Zaloguj się!</Message>
        <StyledForm onSubmit={handleSubmit}>
            <Label type="text">Login:</Label>
            <Text 
            type="text"
            id="login"
            name="login"
            value={login}
            onChange={handleChange}
            placeholder="Podaj login"
            />
            <Label>Hasło:</Label>
            <Text 
            type="password"
            id="password"
            name="password"
            value={password}
            onChange={handleChange}
            placeholder="Podaj hasło"
            />
            <StyledButton type="submit" >Zaloguj</StyledButton>
            {showAlert && <Alert>Niepoprawne dane!</Alert>}
        </StyledForm>
      </CenterContainer>
    </Container>
)};

export default withRouter(LoginForm);