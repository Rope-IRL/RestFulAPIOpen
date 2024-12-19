import { useSelector, useDispatch } from "react-redux";
import { useEffect, useState } from "react";
import { setUser } from "../store/slices/userSlice";

export function useAuthUser() {
    const { name, token, id, role } = useSelector((state) => state.user);
    const [localState, setLocalState] = useState({ name, token, id, role });
    const [loading, setLoading] = useState(true)
    const dispatch = useDispatch();

    useEffect(() => {
        if (token === null && document.cookie.includes(".AspNetCore.Application.Id")) {
            (async () => {
                const userRole = sessionStorage.getItem("userRole")
                const newUserData = await refreshCredentials(dispatch, userRole);
                if (newUserData) {
                    setLocalState(newUserData);
                }
                setLoading(false)
            })();
        } else {
            setLocalState({ name, token, id, role });
            if (role) {
                sessionStorage.setItem("userRole", role);
            }
            setLoading(false)
        }
    }, [name, token, id, role]);
    return {
        isAuth: !!localState.name,
        loading,
        ...localState,
    };
}

async function refreshCredentials(dispatch, userRole) {
    if (userRole != null) {
        const res = await fetch(`http://127.0.0.1:29180/api/${userRole}/refreshToken`, {
            method: "GET",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            credentials: "include",
        });
        try {
            const user = await res.json();
            const userData = {
                id: user.id,
                name: user.name,
                role: user.role,
            };
            dispatch(setUser(userData));
            sessionStorage.setItem("userRole", user.role);
            return userData; // Return new user data for local state
        } catch (error) {
            console.error(error);
            return null; // Handle errors gracefully
        }

    }
    return null;
}
