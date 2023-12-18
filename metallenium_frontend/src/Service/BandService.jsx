import axios from '../Network/axios'

export const BandService = {

    async getAllBands () {
        const response = await axios.get('/band')
        return response.data;
    },
    async getOneBand (id) {
        const response = await axios.get(`/band/${id}`)
        return response.data;
    },
    async searchBand (data) {
        const response = await axios.post(`/band/search`,data);
        return response.data;
    },
    async addBand (data) {
        const response = await axios.post('/band',data)
        return response.data;
    },
    async updateBand (data) {
        const response = await axios.put('/band',data)
        return response.data;
    },
    async deleteBand (id){
        const response = await axios.delete(`/band/${id}`);
        return response.data;
    }
}