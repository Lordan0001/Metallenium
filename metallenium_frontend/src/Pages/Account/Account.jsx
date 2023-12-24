import Footer from "../../Componets/Footer/Footer";
import Header from "../../Componets/Header/Header";
import {useRecoilState} from "recoil";
import {
    citiesState,
    countriesState,
    fullUserState,
    placesState, selectedCitiesState,
    selectedCountriesState, selectedPlacesState, ticketsState, tokenState,
    userState
} from "../../Recoil/Atoms";
import {useEffect} from "react";
import {UserService} from "../../Service/UserService";
import {useCookies} from "react-cookie";
import AccountItem from "../../Componets/AccountItem/AccountItem";
import {TicketService} from "../../Service/TicketService";
import {CountryService} from "../../Service/CountryService";
import {CityService} from "../../Service/CityService";
import {PlaceService} from "../../Service/PlaceService";
import styles from "./Account.module.css"


const Account = () =>{
    //   const [user, setUser] = useRecoilState(userState);
    const [fullUser, setFullUser] = useRecoilState(fullUserState);
    const [country, setCountry] = useRecoilState(selectedCountriesState);
    const [city, setCity] = useRecoilState(selectedCitiesState);
    const [place, setPlace] = useRecoilState(selectedPlacesState);
    const [ticket, setTicket] = useRecoilState(ticketsState)
    const [token, setToken] = useRecoilState(tokenState);
    const [user, setUser] = useRecoilState(userState);
    const [cookies, setCookie, removeCookie] = useCookies(['jwt']);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const userData = await UserService.getMe(cookies);

                const userDataEmail ={
                    Email: userData.email
                }

                const userFullData = await UserService.getUserByEmail(userDataEmail);
                setFullUser(userFullData);


                const ticketData = await TicketService.getTicketByUserId(userFullData.userId);
                console.log(fullUser.userId)
                setTicket(ticketData);

                const countryData =  await CountryService.getAllCountries()
                setCountry(countryData);

                const cityData =  await CityService.getAllCities()
                setCity(cityData);

                const placeData =  await PlaceService.getAllPlaces()
                setPlace(placeData);


                if(cookies.jwt){
                    setToken(cookies.jwt);
                    if (token !='') {
                        const userData = await UserService.getMe(token);
                        setUser(userData);
                    }
                }
            }

            catch (error) {
                console.error('Error fetching users:', error);
            }
        };


        fetchData();
    }, [cookies, token]);

    return (
        <div className={styles.pageContainer}>
            <Header />
            <div className={styles.contentContainer}>
                <AccountItem />
            </div>
            <Footer className={styles.footer} />
        </div>
    );
}

export default Account;