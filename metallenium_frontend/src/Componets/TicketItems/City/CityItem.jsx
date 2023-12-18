import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {citiesState, CitiesState, placesState} from "../../../Recoil/Atoms";
import {CityService} from "../../../Service/CityService";
import {PlaceService} from "../../../Service/PlaceService";


const PickCity = () => {

    const [Cities, setCities] = useRecoilState(citiesState)
    const [Places, setPlaces] = useRecoilState(placesState)
    const [selectedCityName, setSelectedCityName] = useState("");
    const [selectedCityId, setSelectedCityId] = useState("");

    useEffect(() => {
        // Fetch Cities data and store them in the state
        const fetchCities = async () => {
            try {
                const data = await CityService.getAllCities();
                setCities(data);
            } catch (error) {
                console.error("Error fetching Cities:", error);
            }
        };

        fetchCities();
    }, []);

    const handleCityChange = async (event) => {
        setSelectedCityName(event.target.value);

        const selectedCity = Cities.find((City) => City.cityName === event.target.value);
        if (selectedCity) {
            setSelectedCityId(selectedCity.cityId);
            const newPlacesState = await PlaceService.getPlacesByCityId(selectedCity.cityId);
            setPlaces(newPlacesState);
        } else {
            setSelectedCityId("");
        }
    };
    return (
        <div>
            <p>Pick City</p>
            <select value={selectedCityName} onChange={handleCityChange}>
                <option value="">Select a City</option>
                {Cities.map((city) => (
                    <option key={city.cityId} value={city.cityName}>
                        {city.cityName}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default PickCity;
