import styled from "styled-components";

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
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 3px;
`;

export const Content = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
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
  font-size: 2.8em;
  padding-bottom: 15px;
`;

export const Text = styled.h2`
  font-size: 1.8em;
  padding-bottom: 15px;
`;
