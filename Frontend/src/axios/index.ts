import axios from 'axios'

const baseURL = import.meta.env.VITE_API_URL

const config = { baseURL }

const instance = axios.create(config)

instance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token')
    config.headers.Authorization = `Bearer ${token}`
    return config
  },
  (err) => {
    return Promise.reject(err)
  }
)

instance.interceptors.response.use(
  (response) => {
    return response
  }
)

export default instance