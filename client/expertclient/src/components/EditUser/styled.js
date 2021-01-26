import styled from 'styled-components'
import { Button } from '@material-ui/core';
import { RiDeleteBin6Line } from 'react-icons/ri';

export const Container = styled.div`
    display: flex;
    width: 100%;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin: 5px;
    padding: 5px;
    border-radius: 30px;
`

export const Wrapper = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    width: 60%;
    background: linear-gradient(
    to right bottom,
    rgba(255, 255, 255, 0.8),
    rgba(255, 255, 255, 0.4)
  );
  border-radius: 1.6rem;
  border: 2px solid rgba(255, 255, 255, 0.8);
  box-shadow: 20px 20px 50px rgba(0, 0, 0, 0.5);
    align-items: center;
    justify-content: center;
    padding: 20px;
    border-radius: 20px;
    font-size: 1.8em;
`

export const Title = styled.h1`
    display: flex;
    font-weight: bold;
    font-size: 1.2em;
    margin: 5px;
    white-space: nowrap;
`

export const StyledButton = styled(Button)`
    &&{
        width: 200px;
        margin:20px;
        padding: 10px;
        color:  ${({ theme }) => theme.colors.text};
        background: ${({ theme }) => theme.colors.secondary};
        font-size: 0.8em;
        border-radius: 20px;

        &:hover{
            background: ${({ theme }) => theme.colors.hover};
        }
    }
`

export const CurrentButton = styled(StyledButton)`
    &&{
        color:  ${({ theme }) => theme.colors.text};
        background: ${({ theme }) => theme.colors.primary};

        &:hover{
            background: ${({ theme }) => theme.colors.hover};
        }
    }
`

export const DeleteIcon = styled(RiDeleteBin6Line)`
    cursor: pointer;
    margin-left: 30px;
    font-size: 50px;
`
