import React, { useState, useEffect } from "react";
import { Container, Wrapper, Title } from "./styled";
import DoctorApi from "../../api/DoctorApi"

const PatientTerms = () => {
  const [appointments, setAppointments] = useState([]);

  const getAppointments = () => {
    DoctorApi.getAppointments()
      .then((response) => {
        setAppointments(
          response.data.sort(
            ({ id: previousID }, { id: currentID }) => previousID - currentID
          )
        );
      })
      .catch((error) => {
        console.log(
          error,
          "Nie udało się pobrać pacjentów, spróbuj ponownie"
        );
      });
  };

  useEffect(() => {
    getAppointments();
  }, []);

  return (
    <Container>
      <Wrapper>
        <Title>Zaplanowane wizyty:</Title>
        {appointments.map( (appointment, index) => (
            <span key={index}> Lekarz: {appointment.doctor.fullname}, dnia: {appointment.date}</span>
          ))}
      </Wrapper>
    </Container>
  );
};

export default PatientTerms;
