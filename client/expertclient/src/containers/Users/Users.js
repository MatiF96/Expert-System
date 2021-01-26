import React, { useEffect, useState } from 'react';
import {Container, Wrapper} from './styled'
import AdminApi from "../../api/AdminApi";
import EditUser from "../../components/EditUser"

const Users = (props) => {
  const [users, setUsers] = useState([])

  const getUsers = () => {
    AdminApi.getUsers()
    .then(response => {
      setUsers(response.data.sort(({ id: previousID }, { id: currentID }) => previousID - currentID));
    })
    .catch(error => {
      console.log(error,"Nie udało się pobrać użytkowników, spróbuj ponownie");
    });
  }

  useEffect(() => {
    getUsers();
  }, [])

  return (
    <Container>
        <Wrapper>
          {users.map(user => (
            <EditUser key={user.id} user={user} refreshData={getUsers}/>
          ))}
        </Wrapper>
    </Container>
)};

export default Users;