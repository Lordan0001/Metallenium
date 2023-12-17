import axios from '../Network/axios'
export const CountryService = {

    async getAllCountries () {
        const response = await axios.get('/Country')
        return response.data;
    },
    async addCountry (data) {
        const response = await axios.post('/Country',data)
        return response.data;
    },
    async updateCountry (data) {
        const response = await axios.put('/Country',data)
        return response.data;
    },
    async deleteCountry (id){
        const response = await axios.delete(`/Country/${id}`);
        return response.data;
    }

}