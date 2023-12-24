import React, { useState, useEffect } from "react";
import { CityService } from "../../../Service/CityService";
import { useRecoilState } from "recoil";
import { citiesState, countriesState } from "../../../Recoil/Atoms";
import { CountryService } from "../../../Service/CountryService";

const UpdateCity = () => {
    const [cityData, setCityData] = useState({
        cityId: "",
        cityName: "",
        countryId: "",
    });

    const [countries, setCountries] = useRecoilState(countriesState);
    const [cities, setCities] = useRecoilState(citiesState);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const countryData = await CountryService.getAllCountries();
                const cityData = await CityService.getAllCities();

                setCountries(countryData);
                setCities(cityData);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, [setCountries, setCities]);

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
            const updatedCity = await CityService.updateCity({
                cityId: cityData.cityId,
                cityName: cityData.cityName,
                countryId: cityData.countryId,
            });

            // Update Recoil state
            setCities((prevCities) =>
                prevCities.map((city) =>
                    city.cityId === updatedCity.cityId ? updatedCity : city
                )
            );

            // Clear the form
            setCityData({
                cityId: "",
                cityName: "",
                countryId: "",
            });
        } catch (error) {
            console.error("Error updating city:", error);
        }
    };

    return (
        <div>
            <p>Update City</p>
            <form onSubmit={handleSubmit}>
                <select
                    name="cityId"
                    value={cityData.cityId}
                    onChange={handleInputChange}
                >
                    <option value="" disabled>
                        Select a City
                    </option>
                    {cities.map((city) => (
                        <option key={city.cityId} value={city.cityId}>
                            {city.cityName}
                        </option>
                    ))}
                </select>
                <input
                    type="text"
                    name="cityName"
                    placeholder="Update City Name"
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
                <button type="submit">Update City</button>
            </form>
        </div>
    );
};

export default UpdateCity;
