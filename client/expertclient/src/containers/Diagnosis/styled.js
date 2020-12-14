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

export const GroupInputs = styled.div`
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    padding-right: 100px;
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

export const Wrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 80%;
    align-items: center;
`

export const Title = styled.h1`
    font-size: 2.2em;
    padding-bottom: 15px;
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
    color: #f1f1f1;
    background: #ff3377;
    font-size: 1.6rem;
    font-weight: bold;
    padding: 20px 50px;
    margin: 20px;
    margin-bottom: 40px;
    &:hover
    {
        background: #ff3377;
    }
    }
`

export const Label = styled.p`
    font-size: 2.2em;
    font-weight: bold;
    margin: 5px;
`