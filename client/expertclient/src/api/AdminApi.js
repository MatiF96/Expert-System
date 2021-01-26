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


const getUsers = async () => {
  return await createAuthAxios().get("/Admin/users");
};

const createUser = async data => {
    return await createAuthAxios().post("/Admin/users", data);
};

const getUser = async (id) => {
  return await createAuthAxios().get(`/Admin/users/${id}`);
};

const removeUser = async id => {
  return await createAuthAxios().delete(`/Admin/users/${id}`);
};

const updateRole = async (id, data) => {
  return await createAuthAxios().post(`/Admin/users/${id}/role`, data);
};

// eslint-disable-next-line
export default {
  getUsers,
  createUser,
  getUser,
  removeUser,
  updateRole
};