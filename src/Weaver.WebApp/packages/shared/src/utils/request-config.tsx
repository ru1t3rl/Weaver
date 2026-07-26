import { AxiosRequestConfig } from "axios";
import { UseQueryOptions } from "react-query";

export function RequestConfig(address: string, method: string, axios?: AxiosRequestConfig, query?: UseQueryOptions) {
    return {
        axios: {
            ...axios,
            baseURL: address,
            method: method,
        },
        defaultOptions: {
            ...query,
            queries: {
                refetchOnWindowFocus: false
            }
        }
    }
}