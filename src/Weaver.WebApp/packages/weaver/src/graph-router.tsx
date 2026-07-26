import { createBrowserRouter } from 'react-router-dom';
import { ContainerGraph, MainGraph, StackGraph } from './components/graphs';
import { Layout, routes } from '@weaver/shared';
import { ErrorPage } from './components/pages/error-page/error-page';
import { ComposeProject, CreateProject } from '@weaver/custom-compose';

export const AppRouter = createBrowserRouter([
  {
    path: routes.home,
    errorElement: <ErrorPage />,
    Component: Layout,
    children: [
      {
        Component: MainGraph,
        children: [
          { index: true, Component: StackGraph },
          { path: routes.stack(':stackId'), Component: ContainerGraph },
        ],
      },
      {
        Component: MainGraph,
        children: [
          { Component: CreateProject, path: routes.newProject },
          { Component: ComposeProject, path: routes.project(':projectId') }
        ]
      }
    ],
  },
]);
