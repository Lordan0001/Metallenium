import React, {useEffect, useState} from "react";
import { useRecoilState, useRecoilValue } from "recoil";
import {
    countriesState,
    fullUserState,
    selectedCitiesState,
    selectedCountriesState,
    selectedPlacesState,
    tokenState,
    userState
} from "../../Recoil/Atoms";
import { useCookies } from "react-cookie";
import { UserService } from "../../Service/UserService";
import { TicketService } from "../../Service/TicketService";
import Header from "../../Componets/Header/Header";
import PickCountry from "../../Componets/TicketItems/Country/CountryItem";
import PickCity from "../../Componets/TicketItems/City/CityItem";
import PickPlace from "../../Componets/TicketItems/Place/PlaceItem";
import Footer from "../../Componets/Footer/Footer";
import styles from "./Ticket.module.css";
import {CountryService} from "../../Service/CountryService";
import {IoSearchCircleSharp} from "react-icons/io5";
import {RxCross2} from "react-icons/rx";
import {BandService} from "../../Service/BandService";
const Ticket = () => {
    const [fullUser, setFullUser] = useRecoilState(fullUserState);
    const [selectedCountry, setSelectedCountry] = useRecoilState(selectedCountriesState);
    const [city, setCity] = useRecoilState(selectedCitiesState);
    const [place, setPlace] = useRecoilState(selectedPlacesState);
    const [token, setToken] = useRecoilState(tokenState);
    const [user, setUser] = useRecoilState(userState);
    const [cookies] = useCookies(['jwt']);
    const [country, setCountry] = useRecoilState(countriesState);



    const [searchCountryValue, setSearchCountryValue] = useState("");
    const [searchedCountries, setSearchedCountries] = useState([]);

    const handleCountrySearch = async () => {
        try {

            const searchData = {
                countryName: searchCountryValue,

            };
            const searchedCountries = await CountryService.searchCountry(searchData);
            setSearchedCountries(searchedCountries);
            setCountry(searchedCountries);
        } catch (error) {
            console.error("Error searching countries:", error);
        }
    };

    const handleTicket = async () => {
        try {
            const data = {
                userId: fullUser.userId,
                countryId: selectedCountry,
                cityId: city,
                placeId: place,
            };
            const response = await TicketService.addTicket(data);
            alert("Check account page to confirm");
        } catch (error) {
            console.error("Error handling IDs or adding ticket:", error);
            alert("You can book only one ticket");
        }
    };
    const handleCross = async () => {
        try {
            const allCountries = await  CountryService.getAllCountries();
            setSearchedCountries(allCountries);
            setCountry(allCountries);
        } catch (e) {
            console.error(e);
        }
    };
    useEffect(() => {
        const fetchData = async () => {
            try {
                const userData = await UserService.getMe(cookies);

                const userDataEmail = {
                    Email: userData.email,
                };

                const data = await UserService.getUserByEmail(userDataEmail);

                setFullUser(data);
                if (cookies.jwt) {
                    setToken(cookies.jwt);
                    if (token !== "") {
                        const userData = await UserService.getMe(token);
                        setUser(userData);
                    }
                }
            } catch (error) {
                console.error("Error fetching bands:", error);
            }
        };

        fetchData();
    }, [cookies, token,selectedCountry]);

    return (
        <div className={styles.container}>
            <Header />
            <div className={styles.pickItems}>
                <PickCountry />
                <PickCity />
                <PickPlace />
            </div>
            <div className={styles.buttonContainer}>
                {cookies.jwt ? (
                    <button className={styles.bookButton} onClick={handleTicket}>
                        Book a ticket
                    </button>
                ) : (
                    <p className={styles.loginMessage}>Login to book a ticket</p>
                )}
            </div>
            <div className={styles.buttonContainer}>
                {/* Добавляем кнопку для выполнения поиска страны */}
                <div className={styles.countrySearchContainer}>
                    <input
                        type="text"
                        className={styles.countrySearchInput}
                        placeholder="Search country..."
                        value={searchCountryValue}
                        onChange={(e) => setSearchCountryValue(e.target.value)}
                        onKeyDown={(e) => {
                            if (e.key === "Enter") {
                                handleCountrySearch();
                            }
                        }}
                    />
                    <IoSearchCircleSharp
                        className={styles.searchIcon}
                        onClick={handleCountrySearch}
                    />
                    {searchCountryValue && (
                        <RxCross2
                            className={styles.crossIcon}
                            onClick={handleCross}/>
                    )}
                </div>
            </div>

            <Footer className={styles.footer} />
        </div>
    );
};


export default Ticket;
