import { useContext } from 'react';
import { ModalsContext } from '../contexts';

interface UseModals {
  showCreateServiceTemplate: () => void;
}

export function useModals(): UseModals {
  const { openCreateTemplateModal: showCreateServiceTemplate } = useContext(ModalsContext);

  return {
    showCreateServiceTemplate,
  };
}
