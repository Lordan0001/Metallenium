import Footer from "../../Componets/Footer/Footer";
import Header from "../../Componets/Header/Header";
import PickCountry from "../../Componets/TicketItems/Country/CountryItem";
import PickCity from "../../Componets/TicketItems/City/CityItem";
import PickPlace from "../../Componets/TicketItems/Place/PlaceItem";
import {useRecoilState} from "recoil";
import {
    citiesState,
    countriesState,
    fullUserState,
    placesState, selectedCitiesState,
    selectedCountriesState, selectedPlacesState, ticketsState,
    userState
} from "../../Recoil/Atoms";
import {useEffect} from "react";
import {UserService} from "../../Service/UserService";
import {useCookies} from "react-cookie";
import {TicketService} from "../../Service/TicketService";


const Ticket = () =>{
 //   const [user, setUser] = useRecoilState(userState);
    const [fullUser, setFullUser] = useRecoilState(fullUserState);
    const [country, setcountry] = useRecoilState(selectedCountriesState);
    const [city, setcity] = useRecoilState(selectedCitiesState);
    const [place, setplace] = useRecoilState(selectedPlacesState);

    const [cookies, setCookie, removeCookie] = useCookies(['jwt']);

    const handleShowIds = async () => {
        try {
            console.log("Full User ID:", fullUser.userId);
            console.log("Country ID:", country);
            console.log("City ID:", city);
            console.log("Place ID:", place);

            const data = {
                userId: fullUser.userId,
                countryId: country,
                cityId: city,
                placeId: place,
            };

            const response = await TicketService.addTicket(data);
            //console.log(response);
        } catch (error) {
            console.error("Error handling IDs or adding ticket:", error);
        }
    };
    useEffect(() => {
        const fetchData = async () => {
            try {
                const userData = await UserService.getMe(cookies);

                const userDataEmail ={
                    Email: userData.email
                }
                console.log(userData.email);
                const data = await UserService.getUserByEmail(userDataEmail);

                setFullUser(data);
                console.log(data);


                }

            catch (error) {
                console.error('Error fetching users:', error);
            }
        };


        fetchData();
    }, []);

    return(
        <div>
            <div>
                <Header/>
              <PickCountry/>
                <PickCity/>
                <PickPlace/>
                <button onClick={handleShowIds}>Book a ticket</button>
                <Footer/>
            </div>

        </div>
    )
}

export default Ticket;