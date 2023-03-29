import axios from "axios";

export function obterUrlBase(): string{
return window.location.protocol + "//" + window.location.hostname + (window.location.port ? ":" + window.location.port : "");
}

const instaciarAxios = () => {
    const api = axios.create({
      // baseURL: "http://172.20.96.1:90/Api",
      baseURL: "https://localhost:1010/Api",
    });
  
    api.interceptors.request.use((config) => {
      const token = localStorage.getItem("token");
      config.headers.Authorization = `Bearer ${token}`;
      return config;
    });
  
    api.interceptors.response.use(
      (response) => response,
      (err) => {
        if (err.code === "ERR_NETWORK" || err.response.status === 401) {
          localStorage.clear()
          window.location.href = obterUrlBase() + "/auth/login";
          return;
        }
        return Promise.reject(err);
      }
    );
  
    return api;
  };
  
  export default instaciarAxios;
  