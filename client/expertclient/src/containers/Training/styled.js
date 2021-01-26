import styled from 'styled-components'

export const Container = styled.div`
  display: flex;
  width: 100%;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
  font-size: 30px;
  color: black;
  overflow: hidden;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 2px;
`;

export const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  background: white;
  height: 80vh;
  width: 90%;
  background: linear-gradient(
    to right bottom,
    rgba(255, 255, 255, 0.7),
    rgba(255, 255, 255, 0.3)
  );
  border-radius: 1.6rem;
  border: 2px solid rgba(255, 255, 255, 0.8);
  box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
  backdrop-filter: blur(7px);
  overflow: hidden;
  padding: 60px 0px;
`

export const Title = styled.h1`
    font-size: 2.8em;
    padding-bottom: 15px;
`

export const Text = styled.h1`
    font-size: 2.0em;
    padding-bottom: 15px;
`

export const StyledButton = styled.button`
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 10px;
  font-size: 2.6em;
  font-weight: bold;
  padding: 5px 40px;
  background: ${({theme}) => theme.colors.secondary};
  border: 4px solid white;
  border-radius: 20px;
  text-decoration: none;
  cursor: pointer;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 2px;

  &:hover{
      background: ${({theme}) => theme.colors.hover};
  }
`