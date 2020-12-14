import axios from "axios";

const API_URL = "/api/Auth/";

export const login = async (login, password) => {
    const response = await axios
    .post(API_URL + "login", {
      login,
      password
    });
  if (response.data.token) {
    localStorage.setItem('token', response.data.token);
  }
  return response.data.user;
  }

export const logout = () => {
  localStorage.removeItem('token');
}

export const register = async (login, password, fullname, birthdate) => {
  return await axios.post(API_URL + "register", {
    login,
    password,
    fullname,
    birthdate
  });
}

export const whoami = async () => {

  const token = localStorage.getItem('token');

  if(token)
  {
    const BearerToken = `Bearer ${token}`

    axios.interceptors.request.use(
      config => {
        config.headers.authorization = BearerToken;
        return config;
      },
      error => {
        return Promise.reject(error);
      }
    )
  
     const response = await axios.get(API_URL + "whoami")
  
     return response.data
  }
  else
  {
    return null
  }
}


// eslint-disable-next-line
export default {
  login,
  logout,
  register,
  whoami
};
