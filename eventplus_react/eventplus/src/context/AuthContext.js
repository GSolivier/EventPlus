import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

export const UserContext = createContext({})

export const userDecodeToken = (token) => {
    const decoded = jwtDecode(token)

    return {id: decoded.jti, role: decoded.role, name: decoded.name, token: token}
}