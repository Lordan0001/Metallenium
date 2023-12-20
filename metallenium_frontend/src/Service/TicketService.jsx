import axios from "../Network/axios";

export const TicketService = {

    async getAllTickets () {
        const response = await axios.get('/Ticket')
        return response.data;
    },
    async getTicketByUserId (id) {
        const response = await axios.get(`/Ticket/GetTicketByUserId/${id}`)
        return response.data;
    },
    async addTicket (data) {
        const response = await axios.post('/Ticket',data)
        return response.data;
    },
    async updateTicket (data) {
        const response = await axios.put('/Ticket',data)
        return response.data;
    },
    async deleteTicket (id){
        const response = await axios.delete(`/Ticket/${id}`);
        return response.data;
    }

}