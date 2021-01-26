import React, {useContext} from 'react';
import {Container, Content, Title, Text} from './styled'
import { UserContext } from '../../contexts/UserContext';

const Home = () => {
  const { user } = useContext(UserContext);

  return (
    <Container>
        {!user?
          <Content>
            <Title>Witamy w najlepszym systemie eksperckim! Zaloguj się, aby skorzystać z serwisu!</Title>
          </Content>:
          <>
          <Content>
          <Title>Twoje dane:</Title>
          <Text>Login: {user.login}</Text>
          <Text>Pełna nazwa: {user.fullname}</Text>
          <Text>Typ konta: {user.accountType}</Text>
          </Content>
          </>
        }
    </Container>
)};

export default Home;
