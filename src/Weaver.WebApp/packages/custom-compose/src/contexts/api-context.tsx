import { createContext } from 'react';

export interface IApiContext {
  apiAddress: string;
}

export const ApiContext = createContext<IApiContext >({
  apiAddress: 'N/A',
});

export default ApiContext ;
