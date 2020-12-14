import React, {useState} from 'react';
import {Container, CenterContainer, Wrapper, Title, StyledButton,GroupInputs, Text, StyledForm, Label} from './styled'
import MedicalDataApi from "../../api/MedicalDataApi"
import Input from "../../components/Input"

const Diagnosis = () => {

  const [data,setData] = useState({
    "pregnancies": "",
    "glucose": "",
    "bloodPressure": "",
    "skinThickness": "",
    "insulin": "",
    "bmi": "",
    "diabetesPedigreeFunction": "",
    "age": ""
  })
  const [result,setResult] = useState(null)

  const handleSubmit = (e) => {
  e.preventDefault()

  const payload = {
    "pregnancies": parseInt(data.pregnancies),
    "glucose": parseInt(data.glucose),
    "bloodPressure": parseInt(data.bloodPressure),
    "skinThickness": parseInt(data.skinThickness),
    "insulin": parseInt(data.insulin),
    "bmi": parseInt(data.bmi),
    "diabetesPedigreeFunction": parseInt(data.diabetesPedigreeFunction),
    "age": parseInt(data.age)
  }

  console.log(payload)
  MedicalDataApi.result(payload)
  .then(response =>
    setResult(response.data)
  )
  .catch(error => {
    console.log(error)
  })
  }

  const handleChange = (e) => {
    const { target } = e;
    const { name, value } = target;

    setData(prevState => ({...prevState,[name]:value}))
  };

  const showResult =
    result?
    <>
      <Title>Decision: {result.decision?"True":"False"} | Propability: {result.propability}</Title>
    </>:
    null
  
  return (
    <Container>
      <CenterContainer>
        <Wrapper>
        <Title>Wpisz informacje:</Title>
        <StyledForm onSubmit={handleSubmit}>
          <GroupInputs>
          <Input text="pregnancies" value={data.pregnancies} handleChange={handleChange} />
          <Input text="glucose" value={data.glucose} handleChange={handleChange}/>
          <Input text="bloodPressure" value={data.bloodPressure} handleChange={handleChange}/>
          <Input text="skinThickness" value={data.skinThickness} handleChange={handleChange}/>
          <Input text="insulin" value={data.insulin} handleChange={handleChange}/>
          <Input text="bmi" value={data.bmi} handleChange={handleChange}/>
          <Input text="diabetesPedigreeFunction" value={data.diabetesPedigreeFunction} handleChange={handleChange}/>
          <Input text="age" value={data.age} handleChange={handleChange}/>
          </GroupInputs>
          <StyledButton type="submit" >Zatwierdź</StyledButton>
          {showResult}
        </StyledForm>
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Diagnosis;
