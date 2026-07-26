import { PropsWithChildren, useState } from 'react';
import { IModalsContext, ModalsContext } from '../contexts';

export function ModalsProvider(props: PropsWithChildren) {
  const [createTemplateOpen, setCreateTemplateOpen] = useState<boolean>(false);

  function openCreateTemplateModal() {
    setCreateTemplateOpen(true);
  }

  const value: IModalsContext = {
    openCreateTemplateModal,
  };

  return (
    <ModalsContext.Provider value={value}>
    </ModalsContext.Provider>
  );
}
