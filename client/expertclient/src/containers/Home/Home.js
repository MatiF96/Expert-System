import React, {useContext} from 'react';
import {Container, Content, SecondContent, Title, Info ,Description, Text, ImageContainer, Image, ProfileContainer} from './styled'
import { UserContext } from '../../contexts/UserContext';

const Home = () => {
  const { user } = useContext(UserContext);

  return (
    <Container>
        {!user?
          <Content>
            <Title>Witamy w najlepszym systemie wspierającym służbę zdrowia!</Title>
            <Description>Wykorzystujemy system ekspercki w celu pomocy lekarzom, w ich codziennych obowiązkach. Jest to jedno z wielu zastosowań, które daje nam sztuczna inteligencja </Description>
            <Info>Zaloguj się, aby skorzystać z serwisu!</Info>
          </Content>:
          <>
          <SecondContent>
            <ImageContainer>
              <Image />
            </ImageContainer>
            <ProfileContainer>
              <Title>Twoje dane:</Title>
              <Description>Login: {user.login}</Description>
              <Description>Pełna nazwa: {user.fullname}</Description>
              <Description>Typ konta: {user.accountType}</Description>
            </ProfileContainer>
          </SecondContent>
          </>
        }
    </Container>
)};

export default Home;
