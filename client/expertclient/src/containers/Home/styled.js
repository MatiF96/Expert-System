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
`;

export const Content = styled.div`
  display: flex;
  justify-content: center;
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

export const SecondContent = styled(Content)`
  display: flex;
  flex-direction: row;
`;

export const Title = styled.h1`
  font-size: 1.8em;
  padding-bottom: 15px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 2px;
`;

export const Description = styled.h2`
  font-size: 1.2em;
  padding-bottom: 15px;
  margin: 40px 0px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 1px;
`;

export const Info = styled.p`
  font-size: 1.5em;
  padding-bottom: 15px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 4px;
`;

export const Text = styled.h2`
  font-size: 1.5em;
  padding-bottom: 15px;
  -webkit-text-fill-color: white;
  -webkit-text-stroke-width: 1px;
`;

export const ImageContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  width: 40%;
  height: 100%;
  padding: 0px 20px;
  background: white;
  opacity: 0.9;
  border-right: 2px solid black;
`;

export const Image = styled.img`
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 80%;
  background: url("./images/profile.png");
  background-repeat: no-repeat;
  object-fit: contain;
  background-position: center;
  border: 4px solid black;

`;

export const ProfileContainer = styled.div`
  display: flex;
  width: 60%;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;
