import React from "react";
import {Switch, Route} from "react-router-dom";

import Home from '../../containers/Home';
import Appointments from '../../containers/Appointments';
import Users from '../../containers/Users';
import Training from '../../containers/Training';
import Diagnosis from '../../containers/Diagnosis';

import LoginForm from "../../containers/LoginForm";
import RegisterForm from "../../containers/RegisterForm";

import { PatientRoute } from '../../utils/PatientRoute';
import { DoctorRoute } from '../../utils/DoctorRoute';
import { AdminRoute } from '../../utils/AdminRoute';


const AppRouter = () => {
  return (
    <Switch>
        <DoctorRoute exact path='/diagnosis' component={Diagnosis} />

        <DoctorRoute exact path='/appointments' component={Appointments} />
        <DoctorRoute exact path='/training' component={Training} />

        <AdminRoute exact path='/users' component={Users} />

        <Route exact path='/login' component={LoginForm} />
        <Route exact path='/register' component={RegisterForm} />

        <Route path="*" component={Home} />
    </Switch>
)};

export default AppRouter;