import axios from "../Network/axios";

export const ConfirmedTicketService = {

    async getAllConfirmedTickets () {
        const response = await axios.get('/ConfirmedTicket')
        return response.data;
    },
    async addConfirmedTicket (data) {
        const response = await axios.post('/ConfirmedTicket',data)
        return response.data;
    },
    async updateConfirmedTicket (data) {
        const response = await axios.put('/ConfirmedTicket',data)
        return response.data;
    },
    async sendEmail (data) {
        const response = await axios.post('/EmailSender',data)
        return response.data;
    },
    async deleteConfirmedTicket (id){
        const response = await axios.delete(`/ConfirmedTicket/${id}`);
        return response.data;
    }

}