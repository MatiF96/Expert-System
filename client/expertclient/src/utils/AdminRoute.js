import React, { useState, useEffect } from "react";

import AuthApi from "../api/AuthApi";

import { Route, Redirect } from "react-router-dom";
import { ADMIN } from "./Roles";

export const AdminRoute = ({ component: Component, ...rest }) => {
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
        setIsLoading(false);
      });
  }, []);

  if (!isLoading) {
    return (
      <Route
        {...rest}
        render={(props) =>
          token && role === ADMIN ? (
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
