import styled from 'styled-components'
import { Link } from 'react-router-dom'

export const Container = styled.nav`
  display: flex;
  flex-direction: column;
  position: sticky;
  top: 0;
  left: 0;
  height: 100vh;
  min-width: 340px;
  max-width: 340px;
  color: ${({theme}) => theme.colors.text};
  background: ${({theme}) => theme.colors.primary};
  border-left: 1px solid white;
  border-right: 1px solid white;
  overflow: hidden;
`

export const Menu = styled.ul`
  display: flex;
  flex-direction: column;
`

export const NavItem = styled.li`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 160px;
  font-size: 30px;
  font-weight: bold;
  border-top: 1px solid white;
  overflow: hidden;
  border-bottom: 1px solid white;
  padding: 20px;

  &:hover{
      background: ${({theme}) => theme.colors.hover};
  }

  a {
    svg {
      font-size: 50px;
    }
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    text-decoration: none;
    color: ${({theme}) => theme.colors.text};
    white-space: nowrap;
  }
`

export const LoginText = styled.p`
    text-align: center;
    margin: 10px 10px;
    font-size: 30px;
    color: ${({theme}) => theme.colors.text};

`

export const AuthContainer = styled.div`
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 180px;
    border-bottom: 2px solid white;
`

export const StyledButton = styled(Link)`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  max-height: 60px;
  margin: 10px;
  background: transparent;
  color: ${({theme}) => theme.colors.text};
  font-size: 34px;
  border: 2px solid white;
  border-radius: 20px;
  text-decoration: none;

  &:hover{
      background: ${({theme}) => theme.colors.hover};
  }
`
