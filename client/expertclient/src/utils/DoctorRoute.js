import React, { useState, useEffect } from "react";

import AuthApi from "../api/AuthApi";

import { Route, Redirect } from "react-router-dom";
import { DOCTOR } from './Roles'

export const DoctorRoute = ({ component: Component, ...rest }) => {
  const token = localStorage.getItem("token");
  const [role, setRole] = useState("");
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    AuthApi.whoami()
      .then((response) => {
        setRole(response.data.accountType);
        setIsLoading(false);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  if (!isLoading) {
    return (
      <Route
        {...rest}
        render={(props) =>
          token && role === DOCTOR ? (
            <Component {...props} />
          ) : (
            <Redirect to="/login" />
          )
        }
      />
    );
  } else {
    return null;
  }
};
