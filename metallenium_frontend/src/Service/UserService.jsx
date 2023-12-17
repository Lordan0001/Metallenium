import axios from "../Network/axios";

export const UserService = {

    async getAllUsers () {
        const response = await axios.get('/User')
        return response.data;
    },
    async addUser (data) {
        const response = await axios.post('/User',data)
        return response.data;
    },
    async updateUser (data) {
        const response = await axios.put('/User',data)
        return response.data;
    },
    async deleteUser (id){
        const response = await axios.delete(`/User/${id}`);
        return response.data;
    }

}