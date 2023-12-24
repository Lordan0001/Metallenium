import React, { useState, useEffect } from "react";
import { CityService } from "../../../Service/CityService";
import { useRecoilState, useSetRecoilState } from "recoil";
import { countriesState } from "../../../Recoil/Atoms";
import { CountryService } from "../../../Service/CountryService";

const AddCity = () => {
    const [cityData, setCityData] = useState({
        cityName: "",
        countryId: "", // Adding countryId to cityData
    });

    const [countries, setCountries] = useRecoilState(countriesState);

    useEffect(() => {
        const fetchCountries = async () => {
            try {
                const data = await CountryService.getAllCountries();
                setCountries(data);
            } catch (error) {
                console.error("Error fetching countries:", error);
            }
        };

        fetchCountries();
    }, [setCountries]);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setCityData({
            ...cityData,
            [name]: value,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Send data as JSON
            const newCity = await CityService.addCity(cityData);

            // Update Recoil state
            setCountries((prevCountries) => [...prevCountries, newCity]);

            // Clear the form
            setCityData({
                cityName: "",
                countryId: "",
            });
        } catch (error) {
            console.error("Error adding city:", error);
        }
    };

    return (
        <div>
            <p>Add City</p>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="cityName"
                    placeholder="City Name"
                    value={cityData.cityName}
                    onChange={handleInputChange}
                />
                <select
                    name="countryId"
                    value={cityData.countryId}
                    onChange={handleInputChange}
                >
                    <option value="" disabled>
                        Select a Country
                    </option>
                    {countries.map((country) => (
                        <option key={country.countryId} value={country.countryId}>
                            {country.countryName}
                        </option>
                    ))}
                </select>
                <button type="submit">Add City</button>
            </form>
        </div>
    );
};

export default AddCity;
