import React, {useContext} from 'react';
import {Container, CenterContainer, Wrapper, Title, Text} from './styled'
import {UserContext} from '../../contexts/UserContext';

const Home = () => {
  const { user } = useContext(UserContext);

  return (
    <Container>
      <CenterContainer>
        <Wrapper>
        {!user?
          <Title>Najlepszy system ekspercki! Zaloguj się!</Title>:
          <>
          <Title>Twoje dane:</Title>
          <Text>Login: {user.login}</Text>
          <Text>Pełna nazwa: {user.fullname}</Text>
          <Text>Typ konta: {user.accountType}</Text>
          </>
        }
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Home;
