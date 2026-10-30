import { useProducts } from '@/hooks/api/products'
import { Button } from '@/components/ui/button'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card'
import { Skeleton } from '@/components/ui/skeleton'

export const ProductsPage = () => {
  const { data: products, isPending, isError, isFetching, refetch } = useProducts()

  return (
    <main className="mx-auto min-h-svh max-w-5xl px-4 py-10 sm:px-8 sm:py-16">
      <header className="mb-8 flex flex-col gap-6 sm:flex-row sm:items-end sm:justify-between">
        <div className="space-y-3">
          <p className="text-xs font-semibold tracking-widest text-primary uppercase">Catálogo</p>
          <h1 className="text-3xl font-semibold tracking-tight sm:text-4xl">Produtos</h1>
          <p className="text-sm text-muted-foreground sm:text-base">Explore os produtos disponíveis no catálogo.</p>
        </div>
        <Button
          type="button"
          className="w-full sm:w-auto"
          disabled={isFetching}
          onClick={() => void refetch()}
        >
          {isFetching ? 'Atualizando…' : 'Atualizar produtos'}
        </Button>
      </header>

      <p className="sr-only" role="status" aria-live="polite">
        {isFetching ? 'Carregando produtos.' : products ? `${products.length} produtos encontrados.` : ''}
      </p>

      {isError && (
        <div role="alert" className="mb-6 flex flex-col gap-4 rounded-xl border border-destructive/30 bg-card p-5 sm:flex-row sm:items-center sm:justify-between">
          <p className="text-sm text-destructive">
            {products
              ? 'Não foi possível atualizar os produtos. Exibindo os últimos dados disponíveis.'
              : 'Não foi possível carregar os produtos. Tente novamente.'}
          </p>
          <Button type="button" variant="outline" disabled={isFetching} onClick={() => void refetch()}>
            Tentar novamente
          </Button>
        </div>
      )}

      <section aria-label="Lista de produtos" aria-busy={isFetching}>
        {isPending && (
          <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3" aria-hidden="true">
            {[1, 2, 3].map((item) => (
              <Card key={item}>
                <CardHeader>
                  <Skeleton className="mb-3 size-11" />
                  <Skeleton className="h-5 w-3/4" />
                </CardHeader>
                <CardContent><Skeleton className="h-4 w-1/3" /></CardContent>
              </Card>
            ))}
          </div>
        )}

        {products && products.length === 0 && (
          <Card className="border-dashed text-center">
            <CardHeader className="py-12">
              <CardTitle>Nenhum produto disponível</CardTitle>
              <CardDescription>Os produtos aparecerão aqui quando estiverem disponíveis.</CardDescription>
            </CardHeader>
          </Card>
        )}

        {products && products.length > 0 && (
          <>
            <p className="mb-4 text-sm text-muted-foreground">
              {products.length} {products.length === 1 ? 'produto encontrado' : 'produtos encontrados'}
            </p>
            <ul className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3">
              {products.map((product) => (
                <li key={product.id} className="min-w-0">
                  <Card className="h-full">
                    <CardHeader>
                      <span aria-hidden="true" className="mb-3 flex size-11 items-center justify-center rounded-lg bg-accent text-sm font-semibold text-accent-foreground">
                        {product.nome.slice(0, 1).toUpperCase()}
                      </span>
                      <CardTitle className="text-lg leading-snug wrap-anywhere">{product.nome}</CardTitle>
                    </CardHeader>
                    <CardContent>
                      <CardDescription>ID do produto: {product.id}</CardDescription>
                    </CardContent>
                  </Card>
                </li>
              ))}
            </ul>
          </>
        )}
      </section>
    </main>
  )
}
