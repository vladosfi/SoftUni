import { createReducer, on } from '@ngrx/store';
import { stat } from 'fs';
import { IUser } from '../shared/interfaces';
import { login, logout, register, authenticate } from './actions';

export interface IAuthState {
    currentUser: IUser | null | undefined;
}

export const initialState: IAuthState = {
    currentUser: undefined
};


const setCurrentUser = (
    state: IAuthState,
    action: ReturnType<typeof login> |
        ReturnType<typeof authenticate> |
        ReturnType<typeof register>
) => {
    return { ...state, currentUser: action.user };
};

export const authReducer = createReducer(
    initialState,
    on(login, setCurrentUser),
    on(register, setCurrentUser),
    on(authenticate, setCurrentUser),
    on(logout, (state) => {
        return { ...state, currentUser: null };
    })
);
