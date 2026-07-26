import { useContext } from "react"
import { ApiContext } from '../contexts';

export const useApi = () => {
    return useContext(ApiContext)
}