import { apiClient } from '@/api/axios'
import { useQuery } from '@tanstack/react-query'

export interface Product {
  id: number
  nome: string
}

const isProduct = (value: unknown): value is Product => {
  return typeof value === 'object' && value !== null
    && 'id' in value && typeof value.id === 'number'
    && 'nome' in value && typeof value.nome === 'string'
}

export const getProducts = async (signal: AbortSignal): Promise<Product[]> => {
  const { data } = await apiClient.get<unknown>('/products', { signal })
  if (!Array.isArray(data) || !data.every(isProduct)) {
    throw new Error('Resposta de produtos inválida')
  }

  return data
}

export const useProducts = () => useQuery({
  queryKey: ['products'],
  queryFn: ({ signal }) => getProducts(signal),
  retry: 1,
})
