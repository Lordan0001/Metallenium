import React, { useState, useEffect } from "react";
import { CountryService } from "../../../Service/CountryService";
import {useRecoilState, useSetRecoilState} from "recoil";
import { countriesState } from "../../../Recoil/Atoms";

const UpdateCountry = () => {
    const [countryData, setCountryData] = useState({
        countryId: "",
        countryName: "",
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
        setCountryData({
            ...countryData,
            [name]: value,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Отправляем данные в формате JSON
            const updatedCountry = await CountryService.updateCountry({
                countryId: countryData.countryId,
                countryName: countryData.countryName,
            });

            // Обновляем состояние Recoil
            setCountries((prevCountries) =>
                prevCountries.map((country) =>
                    country.countryId === updatedCountry.countryId
                        ? updatedCountry
                        : country
                )
            );

            // Очищаем форму
            setCountryData({
                countryId: "",
                countryName: "",
            });
        } catch (error) {
            console.error("Error adding country:", error);
        }
    };

    return (
        <div>
            <p>Add Country</p>
            <form onSubmit={handleSubmit}>
                <select
                    name="countryId"
                    value={countryData.countryId}
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
                <input
                    type="text"
                    name="countryName"
                    placeholder="Update Country Name"
                    value={countryData.countryName}
                    onChange={handleInputChange}
                />
                <button type="submit">Update Country</button>
            </form>
        </div>
    );
};

export default UpdateCountry;
