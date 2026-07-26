import { PropsWithChildren } from 'react';
import { ApiContext, IApiContext } from '../contexts';

interface ApiProviderProps {
  apiAddress: string
}

export const ApiProvider = (props: ApiProviderProps & PropsWithChildren) => {
  const { apiAddress, children } = props;

  const value: IApiContext = {
    apiAddress
  };

  return <ApiContext.Provider value={value}>{children}</ApiContext.Provider>;
};
