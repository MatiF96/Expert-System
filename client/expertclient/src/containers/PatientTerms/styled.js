import styled from 'styled-components'
import { Link } from 'react-router-dom';

export const Container = styled.div`
  display: flex;
  width: 100%;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
  font-size: 50px;
  color: black;
  overflow:hidden;
`

export const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  background: white;
  height: 70vh;
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
`;

export const Title = styled.h1`
    font-size: 1.2em;
    margin-bottom: 10px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 1px;
`

export const List = styled.ul`
    display: flex;
    width: 100%;
    flex-wrap: wrap;
    list-style:none;
    align-items: center;
`

export const StyledLink = styled(Link)`
    display: flex;
    flex-basis: 100%;
    font-size: 1.8em;
    min-height: 150px;
    min-width: 150px;
    flex-grow: 1;
    justify-content: center;
    align-items: center;
    flex-shrink: 0;
    background:  #ff99dd;
    padding: 10px;
    margin: 5px;
    border-radius: 20px;

    &:hover {
        background: #ffb3e6;
    }
`

export const Row = styled.div`
    display: flex;
    flex-basis: 100%;
    justify-content: center;
    align-items: center;
    margin-top: 5px;
`
