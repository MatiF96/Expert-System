import React, { useContext } from 'react';
import {UserContext} from '../contexts/UserContext';
import { Route, Redirect } from "react-router-dom"
import { ADMIN } from './Roles'

export const AdminRoute = ({ component: Component, ...rest }) => {
  const { user } = useContext(UserContext);

  return (
    <Route {...rest} render={(props) => (
      (user && user.accountType === ADMIN)
        ? <Component {...props} />
        : <Redirect to='/login' />
    )} />
  )
}