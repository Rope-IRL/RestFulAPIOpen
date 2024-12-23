import {createSlice} from "@reduxjs/toolkit"

const initialState = {
    name: null,
    token: null,
    id: null,
    role: null
};

const userSlice = createSlice({
    name:"user",
    initialState,
    reducers: {
        setUser(state, action) {
            state.name = action.payload.name;
            state.token = action.payload.token;
            state.id = action.payload.id;
            state.role = action.payload.role;
        },
        removeUser(state) {
            state.name = null;
            state.token = null;
            state.id = null;
            state.role = null;
        },
    }
});

export const {setUser, removeUser} = userSlice.actions;

export default userSlice.reducer;