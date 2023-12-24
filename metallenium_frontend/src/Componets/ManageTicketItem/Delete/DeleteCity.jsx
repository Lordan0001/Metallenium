import React, { useState, useEffect } from "react";
import { CityService } from "../../../Service/CityService";
import { useRecoilState } from "recoil";
import { citiesState } from "../../../Recoil/Atoms";

const DeleteCity = () => {
    const [cities, setCities] = useRecoilState(citiesState);
    const [selectedCityName, setSelectedCityName] = useState("");
    const [selectedCityId, setSelectedCityId] = useState("");

    useEffect(() => {
        // Fetch cities data and store them in the state
        const fetchCities = async () => {
            try {
                const data = await CityService.getAllCities();
                setCities(data);
            } catch (error) {
                console.error("Error fetching cities:", error);
            }
        };

        fetchCities();
    }, []);

    const handleCityChange = (event) => {
        setSelectedCityName(event.target.value);

        // Find the corresponding cityId based on the selected cityName
        const selectedCity = cities.find((city) => city.cityName === event.target.value);
        if (selectedCity) {
            setSelectedCityId(selectedCity.cityId);
        } else {
            setSelectedCityId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Delete the city and update Recoil state
            await CityService.deleteCity(selectedCityId);

            setCities((prevCities) =>
                prevCities.filter((city) => city.cityId !== selectedCityId)
            );

            setSelectedCityName("");
            setSelectedCityId("");
        } catch (error) {
            console.error("Error deleting city:", error);
        }
    };

    return (
        <div>
            <p>Delete City</p>
            <select value={selectedCityName} onChange={handleCityChange}>
                <option value="">Select a City</option>
                {cities.map((city) => (
                    <option key={city.cityId} value={city.cityName}>
                        {city.cityName}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">
                Delete
            </button>
        </div>
    );
};

export default DeleteCity;
