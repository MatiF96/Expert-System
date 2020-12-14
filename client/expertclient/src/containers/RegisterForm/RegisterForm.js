import React, { useState } from 'react';
import {Container, CenterContainer, StyledForm,  Text, StyledButton, Label, Alert, Message} from './styled';
import { withRouter } from "react-router-dom"
import AuthApi from '../../api/AuthApi'

const RegisterForm = (props) => {

  const [login, setLogin] = useState('')
  const [password, setPassword] = useState('')
  const [showAlert, setShowAlert] = useState(false)

  const handleSubmit = (e) => {
    e.preventDefault()
    
    const fullname = `${login}${login}`
    const birthdate = "2020-12-14T11:49:19.458Z"

    AuthApi.register(login,password,fullname,birthdate).then(
    () => {
      props.history.push("/");
    },
    error => {
      console.log(error)
      setShowAlert(true)
    })
  }

  const handleChange = (e) => {
    const { target } = e;
    const { name, value } = target;

    name==="login"?
    setLogin(value):
    setPassword(value)
  };

  return (
    <Container>
      <CenterContainer>
        <Message>Zarejestruj się!</Message>
        <StyledForm onSubmit={handleSubmit}>
            <Label type="text">Login:</Label>
            <Text 
            type="text"
            id="login"
            name="login"
            value={login}
            onChange={handleChange}
            placeholder="Wpisz nowy login"
            />
            <Label>Hasło:</Label>
            <Text 
            type="password"
            id="password"
            name="password"
            value={password}
            onChange={handleChange}
            placeholder="Wpisz hasło"
            />
            <StyledButton type="submit" >Zarejestruj</StyledButton>
            {showAlert?<Alert>Niepoprawne dane!</Alert>:null}
        </StyledForm>
      </CenterContainer>
    </Container>
)};

export default withRouter(RegisterForm);