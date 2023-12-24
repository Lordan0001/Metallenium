import React, { useState, useEffect } from "react";
import { CountryService } from "../../../Service/CountryService";
import { useSetRecoilState } from "recoil";
import { countriesState } from "../../../Recoil/Atoms";

const AddCountry = () => {
    const [countryData, setCountryData] = useState({
        countryName: "",
    });

    const setCountries = useSetRecoilState(countriesState);


    useEffect(() => {

    }, []);

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
            const newCountry = await CountryService.addCountry({
                countryName: countryData.countryName,
            });

            // Обновляем состояние Recoil
            setCountries((prevCountries) => [...prevCountries, newCountry]);

            // Очищаем форму
            setCountryData({
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
                <input
                    type="text"
                    name="countryName"
                    placeholder="Country Name"
                    value={countryData.countryName}
                    onChange={handleInputChange}
                />
                <button type="submit">Add Country</button>
            </form>
        </div>
    );
};

export default AddCountry;
