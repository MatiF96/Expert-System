import React, { useEffect, useState } from 'react';
import {Container, CenterContainer, Wrapper} from './styled'
import AdminApi from "../../api/AdminApi";
import EditUser from "../../components/EditUser"

const Users = () => {
  const [users, setUsers] = useState([])

  const getUsers = () => {
    AdminApi.getUsers()
    .then(response => {
      setUsers(response.data.sort(({ id: previousID }, { id: currentID }) => previousID - currentID));
    })
    .catch(error => {
      console.log("przypal");
    });
  }

  useEffect(() => {
    getUsers();
  }, [])

  return (
    <Container>
      <CenterContainer>
        <Wrapper>
          {users.map(user => (
            <EditUser key={user.id} user={user} refreshData={getUsers}/>
          ))}
        </Wrapper>
      </CenterContainer>
    </Container>
)};

export default Users;