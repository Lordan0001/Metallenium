import axios from "../Network/axios";

export const CityService = {

    async getAllCities () {
        const response = await axios.get('/City')
        return response.data;
    },
    async getCitiesByCountryId (id) {
        const response = await axios.get(`/City/GetCitiesByCountryId/${id}`)
        return response.data;
    },
    async addCity (data) {
        const response = await axios.post('/City',data)
        return response.data;
    },
    async updateCity (data) {
        const response = await axios.put('/City',data)
        return response.data;
    },
    async deleteCity (id){
        const response = await axios.delete(`/City/${id}`);
        return response.data;
    }

}