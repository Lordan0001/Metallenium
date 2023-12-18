import {atom, selector} from "recoil";

export const bandsState = atom({
    key: 'bandsState',
    default: [],
});

export const albumsState = atom({
    key: 'albumsState',
    default: [],
});

export const citiesState = atom({
    key: 'citiesState',
    default: [],
});

export const confirmedTicketsState = atom({
    key: 'confirmedTicketsState',
    default: [],
});
export const countriesState = atom({
    key: 'countriesState',
    default: [],
});
export const placesState = atom({
    key: 'placesState',
    default: [],
});
export const ticketsState = atom({
    key: 'ticketsState',
    default: [],
});
export const tokenState = atom({
    key: 'tokenState',
    default: [],
});

export const userState = atom({
    key: 'userState',
    default: '',
});

export const isAuthorizedState = selector({
    key: 'isAuthorizedState',
    get: ({ get }) => {
        const user = get(userState);
        if(user != ''){
            return true}
        else{
            return false}
    },
});