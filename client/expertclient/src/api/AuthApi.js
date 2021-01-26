import axios from "axios";

const API_URL = "/api/Auth/";

export const login = async (login, password) => {
  return await axios.post(API_URL + "login", {
    login,
    password,
  });
};

export const logout = () => {
  localStorage.removeItem("token");
};

export const register = async (login, password, fullname, birthdate) => {
  return await axios.post(API_URL + "register", {
    login,
    password,
    fullname,
    birthdate,
  });
};

export const whoami = async () => {
  const token = localStorage.getItem("token");

  if (token) {
    const authAxios = axios.create({
      headers: {
        "Content-type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    return await authAxios.get(API_URL + "whoami")
  } else {
    return null;
  }
};

// eslint-disable-next-line
export default {
  login,
  logout,
  register,
  whoami
};
