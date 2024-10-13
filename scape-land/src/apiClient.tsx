import axios from 'axios';

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_SCAPELAND_BACKEND_URL,
  headers: {
    'Content-Type': 'application/json',
    'credentials': 'include'
  },
});

export default apiClient;
