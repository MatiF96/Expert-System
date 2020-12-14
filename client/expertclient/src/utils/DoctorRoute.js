import React, { useContext } from 'react';
import {UserContext} from '../contexts/UserContext';
import { Route, Redirect } from "react-router-dom"
import { DOCTOR } from './Roles'

export const DoctorRoute = ({ component: Component, ...rest }) => {
  const { user } = useContext(UserContext);

  return (
    <Route {...rest} render={(props) => (
      (user && user.accountType === DOCTOR)
        ? <Component {...props} />
        : <Redirect to='/login' />
    )} />
  )
}