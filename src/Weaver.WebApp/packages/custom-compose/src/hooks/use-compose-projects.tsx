import { ComposeProjectListItemModel, RequestConfig, Tag, useGetComposeProject, usePutComposeProject } from '@weaver/shared';
import { useApi } from './use-api';

interface UseComposeProjects {
    projects: ComposeProjectListItemModel[];
    isLoading: boolean;
    create: (name: string, description?: string, tags?: Tag[]) => Promise<string | undefined>;
}

export const useComposeProjects = (): UseComposeProjects => {
    const { apiAddress } = useApi();
    
    const { data, isLoading } = useGetComposeProject(RequestConfig(apiAddress, 'get'));
    const {mutateAsync} = usePutComposeProject(RequestConfig(apiAddress, 'put'));

    async function create(name: string, description?: string, tags?: Tag[]): Promise<string | undefined> {
        const response = await mutateAsync({ data: {
            name,
            description,
            tags
        }});

        return response.data.id
    }

    return {
        create,
        projects: data?.data ?? [],
        isLoading
    }
}