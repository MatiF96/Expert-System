import React, {useState} from 'react';
import {Container, Title, StyledButton,GroupInputs, StyledForm} from './styled'
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
      <Title>Decyzja: {result.decision?"Pozytywny":"Negatywny"}</Title>
      <Title>Prawdopodobieństwo: {result.propability}</Title>
    </>:
    null
  
  return (
    <Container>
      {!result?
      <>
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
        </StyledForm>
      </>
      :
      <>
      {showResult}
      <StyledButton onClick={() => setResult(null)} >Powtórz badanie</StyledButton>
      </>}
    </Container>
)};

export default Diagnosis;
