import styled from 'styled-components'
import { TextField, Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    justify-content: center;
    min-width: 740px;
`

export const CenterContainer = styled.div`
    display: flex;
    min-height: 100vh;
    width: 1500px;
    flex-direction: column;
    align-items: center;
    background: #ff80aa;
    padding: 20px 50px 50px 30px;
`

export const StyledForm = styled.form`
    display: flex;
    width: 90%;
    flex-direction: column;
    align-items: center;
    padding: 10px;
    background: #ff99bb;
    border-radius: 20px;
    margin: 20px;
`

export const Text = styled(TextField)`
    &&{
        min-width: 500px;
        padding: 20px;
        background: #ffb3d9;
        border-radius: 30px;
        margin-bottom: 10px;
    }
`

export const StyledButton = styled(Button)`
    &&{
        min-width: 240px;
        margin: 20px;
        padding: 10px;
        background: #ffb3d9;
        font-size: 1.4em;
        font-weight: bold;
        color: #e6e6e6;
        border-radius: 20px;
    }
`

export const Message = styled.h1`
    font-size: 2.8em;
    font-weight: bold;
    margin: 20px;
`

export const Label = styled.p`
    font-size: 2.2em;
    font-weight: bold;
    margin: 5px;
`

export const Alert = styled(Label)`
    color: red;
    font-size: 1.4em;
    font-weight: bold;
`