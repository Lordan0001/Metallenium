import axios from "../Network/axios";

export const PlaceService = {

    async getAllPlaces () {
        const response = await axios.get('/Place')
        return response.data;
    },
    async addPlace (data) {
        const response = await axios.post('/Place',data)
        return response.data;
    },
    async updatePlace (data) {
        const response = await axios.put('/Place',data)
        return response.data;
    },
    async deletePlace (id){
        const response = await axios.delete(`/Place/${id}`);
        return response.data;
    }

}