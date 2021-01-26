import axios from "axios";

const createAuthAxios = () => {

  const token = localStorage.getItem('token');

  return axios.create({
    baseURL: "/api",
    headers: {
      "Content-type": "application/json",
      "Authorization": `Bearer ${token}`
    }})
  }

const getPatients = async () => {
  return await createAuthAxios().get("/Users/patients");
};

const getAppointments = async () => {
  return await createAuthAxios().get("/Appointments/currentUser");
};

// eslint-disable-next-line
export default {
  getPatients,
  getAppointments
};