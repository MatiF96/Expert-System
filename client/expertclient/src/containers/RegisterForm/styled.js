import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  width: 100%;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  font-size: 40px;
`;

export const Message = styled.h1`
  font-size: 3.4em;
  font-weight: bold;
  margin-bottom: 30px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 2px;
`;

export const StyledForm = styled.form`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background: white;
  height: 60vh;
  width: 50%;
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
  margin-bottom: 60px;
`;

export const Text = styled.input`
  font-size: 2em;
  display: flex;
  justify-content: center;
  width: 500px;
  height: 90px;
  border-radius: 10px;
  border: 1px solid ${({ theme }) => theme.colors.primary};
  background: inherit;
  color: ${({ theme }) => theme.colors.primary};
`;

export const Label = styled.p`
  font-size: 2.2em;
  font-weight: bold;
  margin: 20px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 2px;
`;

export const StyledButton = styled.button`
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 60px;
  font-size: 1.2em;
  font-weight: bold;
  padding: 15px 30px;
  background: ${({theme}) => theme.colors.secondary};
  border: 2px solid white;
  border-radius: 20px;
  text-decoration: none;
  cursor: pointer;

  &:hover{
      background: ${({theme}) => theme.colors.hover};
  }
`

export const Alert = styled.p`
  color: red;
  font-size: 1.4em;
  font-weight: bold;
  margin-top: 20px;
`;
