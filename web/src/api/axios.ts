import axios from 'axios'

const SIGNAL_TIMEOUT = 15_000

export const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL?.trim() || '/api',
  timeout: SIGNAL_TIMEOUT,
})

// Centralize aqui os interceptors de autenticação quando ela for implementada.
