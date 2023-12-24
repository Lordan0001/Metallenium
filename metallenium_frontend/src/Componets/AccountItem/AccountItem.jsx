import React from "react";
import styles from './AccountItem.module.css'
import { useRecoilState } from "recoil";
import {
    fullUserState,
    selectedCitiesState,
    selectedCountriesState,
    selectedPlacesState,
    ticketsState
} from "../../Recoil/Atoms";
import {ConfirmedTicketService} from "../../Service/ConfirmedTicketService";

const AccountItem = () => {
    const [fullUser, setFullUser] = useRecoilState(fullUserState);
    const [ticket, setTicket] = useRecoilState(ticketsState)
    const [country, setCountry] = useRecoilState(selectedCountriesState);
    const [city, setCity] = useRecoilState(selectedCitiesState);
    const [place, setPlace] = useRecoilState(selectedPlacesState);

    const getCountryNameById = (countryId) => {
        const selectedCountry = Array.isArray(country) ? country.find(c => c.countryId === countryId) : null;
        return selectedCountry ? selectedCountry.countryName : 'Unknown';
    };

    const getCityNameById = (cityId) => {
        const selectedCity = Array.isArray(city) ? city.find(c => c.cityId === cityId) : null;
        return selectedCity ? selectedCity.cityName : 'Unknown';
    };

    const getPlaceInfoById = (placeId) => {
        const selectedPlace = Array.isArray(place) ? place.find(p => p.placeId === placeId) : null;
        return selectedPlace ? `${selectedPlace.address} - ${selectedPlace.date}` : 'Unknown';
    };

    const ConfirmTicket = async () => {
        try {
            const ticketData = {
                ticketId: ticket.ticketId,
                userId: fullUser.userId,
                countryId: ticket.countryId,
                cityId: ticket.cityId,
                placeId: ticket.placeId
            };

             const response = await ConfirmedTicketService.sendEmail(ticketData);
            alert("Check your email!");

        } catch (error) {
            console.error("Error handling IDs or adding Account:", error);
            alert("Your ticket is already confirmed!");
        }
    };


    return (
        <div className={styles.AccountItem}>
            <table>
                <tbody>
                <tr>
                    <td>User:</td>
                    <td>{fullUser.userFirstName} {fullUser.userSecondName}</td>
                </tr>
                <tr>
                    <td>Ticket ID:</td>
                    <td>{ticket.ticketId}</td>
                </tr>
                <tr>
                    <td>Ticket Country:</td>
                    <td>{getCountryNameById(ticket.countryId)}</td>
                </tr>
                <tr>
                    <td>Ticket City:</td>
                    <td>{getCityNameById(ticket.cityId)}</td>
                </tr>
                <tr>
                    <td>Ticket Place:</td>
                    <td>{getPlaceInfoById(ticket.placeId)}</td>
                </tr>
                </tbody>
            </table>
            <button onClick={ConfirmTicket}>Confirm Ticket</button>

        </div>
    );
};

export default AccountItem;
