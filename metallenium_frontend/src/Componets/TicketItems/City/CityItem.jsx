import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {citiesState} from "../../../Recoil/Atoms";
import {CityService} from "../../../Service/CityService";


const PickCity = () => {

    const [Cities, setCities] = useRecoilState(citiesState)
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

    const handleCityChange = (event) => {
        setSelectedCityName(event.target.value);

        // Find the corresponding CityId based on the selected CityName
        const selectedCity = Cities.find((City) => City.CityName === event.target.value);
        if (selectedCity) {
            setSelectedCityId(selectedCity.CityId);
        } else {
            setSelectedCityId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newCity = await CityService.PickCity(selectedCityId);
            setCities((prevCities) => prevCities.filter((City) => City.CityId !== selectedCityId));

            // Clear the selected values
            setSelectedCityName("");
            setSelectedCityId("");
        } catch (error) {
            console.error("Error deleting City:", error);
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
            <button onClick={handleSubmit} type="button">Pick</button>
        </div>
    );
};

export default PickCity;
