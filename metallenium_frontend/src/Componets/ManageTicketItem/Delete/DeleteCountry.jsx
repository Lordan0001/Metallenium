import React, { useState, useEffect } from "react";
import { CountryService } from "../../../Service/CountryService";
import { useRecoilState } from "recoil";
import { countriesState } from "../../../Recoil/Atoms";

const DeleteCountry = () => {
    const [countries, setCountries] = useRecoilState(countriesState);
    const [selectedCountryName, setSelectedCountryName] = useState("");
    const [selectedCountryId, setSelectedCountryId] = useState("");

    useEffect(() => {
        // Fetch countries data and store them in the state
        const fetchCountries = async () => {
            try {
                const data = await CountryService.getAllCountries();
                setCountries(data);
            } catch (error) {
                console.error("Error fetching countries:", error);
            }
        };

        fetchCountries();
    }, []);

    const handleCountryChange = (event) => {
        setSelectedCountryName(event.target.value);

        // Find the corresponding countryId based on the selected countryName
        const selectedCountry = countries.find((country) => country.countryName === event.target.value);
        if (selectedCountry) {
            setSelectedCountryId(selectedCountry.countryId);
        } else {
            setSelectedCountryId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Delete the country and update Recoil state
            await CountryService.deleteCountry(selectedCountryId);

            setCountries((prevCountries) =>
                prevCountries.filter((country) => country.countryId !== selectedCountryId)
            );

            setSelectedCountryName("");
            setSelectedCountryId("");
        } catch (error) {
            console.error("Error deleting country:", error);
        }
    };

    return (
        <div>
            <p>Delete Country</p>
            <select value={selectedCountryName} onChange={handleCountryChange}>
                <option value="">Select a Country</option>
                {countries.map((country) => (
                    <option key={country.countryId} value={country.countryName}>
                        {country.countryName}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">
                Delete
            </button>
        </div>
    );
};

export default DeleteCountry;
