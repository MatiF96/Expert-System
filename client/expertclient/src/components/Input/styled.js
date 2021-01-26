import styled from 'styled-components'

export const Container = styled.div`
   display: flex;
   flex-direction: row;
   justify-content: flex-start; 
   margin: 5px;
`

export const Label = styled.p`
    font-size: 2.2em;
    font-weight: bold;
    margin: 5px;
`

export const Field = styled.input`
font-size: 2em;
display: flex;
justify-content: center;
width: 600px;
height: 90px;
border-radius: 10px;
border: 1px solid ${({ theme }) => theme.colors.primary};
background: inherit;
color: ${({ theme }) => theme.colors.primary};

&::placeholder {
font-size: 0.9em;
}
`;