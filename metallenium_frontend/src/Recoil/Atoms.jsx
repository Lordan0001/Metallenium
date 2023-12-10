import {atom} from "recoil";

export const bandsState = atom({
    key: 'bandsState',
    default: [],
});

export const albumsState = atom({
    key: 'albumState',
    default: [],
});