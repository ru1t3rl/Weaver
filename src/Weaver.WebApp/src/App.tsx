import { AppRouter } from '@weaver/app';
import { ApiProvider } from '@weaver/custom-compose'
import { DockerProvider } from '@weaver/docker';
import { environment } from '@weaver/shared';
import { ThemeProvider } from '@weaver/styling';
import { QueryClient, QueryClientProvider } from 'react-query';
import { RouterProvider } from 'react-router-dom';

function App() {
  const queryClient = new QueryClient({
    defaultOptions: {
      queries: {
        refetchOnWindowFocus: false, // default: true
      },
    },
  });

  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider>
        <ApiProvider apiAddress={environment.apiAddress}>
          <DockerProvider dockerApiAddress={environment.dockerApiAddress}>
            <RouterProvider router={AppRouter} />
          </DockerProvider>
        </ApiProvider>
      </ThemeProvider>
    </QueryClientProvider>
  );
}

export default App;
