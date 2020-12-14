import React, { useContext } from 'react';
import {UserContext} from '../../src/contexts/UserContext';
import { Route, Redirect } from "react-router-dom"
import { PATIENT } from './Roles'

export const PatientRoute = ({ component: Component, ...rest }) => {
  const { user } = useContext(UserContext);

  return (
    <Route {...rest} render={(props) => (
      (user && user.accountType === PATIENT)
        ? <Component {...props} />
        : <Redirect to='/login' />
    )} />
  )
}