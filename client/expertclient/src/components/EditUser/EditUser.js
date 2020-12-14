import React from 'react';
import { Container, Wrapper, Title, StyledButton, CurrentButton, DeleteIcon } from './styled';
import AdminApi from "../../api/AdminApi";
import { ADMIN, DOCTOR, PATIENT} from "../../utils/Roles"


const EditUser = ({ user, refreshData }) => {

  const ChangeRole = (role) => {

    let data = {
      role: role
    };

    AdminApi.updateRole(user.id,data)
    .then((res) => {
      refreshData()
    })
    .catch(e => {
      console.log(e);
    });
  }

  const DeleteUser = (id) => {

    AdminApi.removeUser(id)
    .then((res) => {
      refreshData()
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleClick = (role) => {
    ChangeRole(role)
    refreshData();
  };



    return (
      <Container>
        <Wrapper>
          <Title>{user.login} :</Title>
          {user.accountType===ADMIN?
            <CurrentButton>ADMIN</CurrentButton>:
            <StyledButton onClick={() => handleClick(ADMIN)}>ADMIN</StyledButton>}
          {user.accountType===DOCTOR?
            <CurrentButton>DOCTOR</CurrentButton>:
            <StyledButton onClick={() => handleClick(DOCTOR)}>DOCTOR</StyledButton>}
          {user.accountType===PATIENT?
            <CurrentButton>PATIENT</CurrentButton>:
            <StyledButton  onClick={() => handleClick(PATIENT)}>PATIENT</StyledButton>}
            <DeleteIcon onClick={() => DeleteUser(user.id)}/>
        </Wrapper>
      </Container>
  )};
  
  export default EditUser;