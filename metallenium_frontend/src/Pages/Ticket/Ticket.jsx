import Footer from "../../Componets/Footer/Footer";
import Header from "../../Componets/Header/Header";
import PickCountry from "../../Componets/TicketItems/Country/CountryItem";
import PickCity from "../../Componets/TicketItems/City/CityItem";
import PickPlace from "../../Componets/TicketItems/Place/PlaceItem";


const Ticket = () =>{
    return(
        <div>
            <div>
                <Header/>
              <PickCountry/>
                <PickCity/>
                <PickPlace/>
                <Footer/>
            </div>

        </div>
    )
}

export default Ticket;