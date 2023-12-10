import axios from '../Network/axios'

export const AlbumService = {

    async getAllAlbums () {
        const response = await axios.get('/album')
        return response.data;
    },
    async getAlbumsByBand (id) {
        const response = await axios.get(`/album/GetAlbumsByBandId/${id}`)
        return response.data;
    },
    async addAlbum (data) {
        const response = await axios.post('/album',data)
        return response.data;
    },
    async updateAlbum (data) {
        const response = await axios.put('/album',data)
        return response.data;
    },
    async deleteAlbum (id){
        const response = await axios.delete(`/album/${id}`);
        return response.data;
    }

}