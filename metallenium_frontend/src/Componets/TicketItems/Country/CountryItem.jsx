import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {countriesState} from "../../../Recoil/Atoms";
import {CountryService} from "../../../Service/CountryService";


const PickCountry = () => {

    const [Countries, setCountries] = useRecoilState(countriesState)
    const [selectedCountryName, setSelectedCountryName] = useState("");
    const [selectedCountryId, setSelectedCountryId] = useState("");

    useEffect(() => {
        // Fetch Countries data and store them in the state
        const fetchCountries = async () => {
            try {
                const data = await CountryService.getAllCountries();
                setCountries(data);
            } catch (error) {
                console.error("Error fetching Countries:", error);
            }
        };

        fetchCountries();
    }, []);

    const handleCountryChange = (event) => {
        setSelectedCountryName(event.target.value);

        // Find the corresponding CountryId based on the selected CountryName
        const selectedCountry = Countries.find((Country) => Country.CountryName === event.target.value);
        if (selectedCountry) {
            setSelectedCountryId(selectedCountry.CountryId);
        } else {
            setSelectedCountryId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newCountry = await CountryService.PickCountry(selectedCountryId);
            setCountries((prevCountries) => prevCountries.filter((Country) => Country.CountryId !== selectedCountryId));

            // Clear the selected values
            setSelectedCountryName("");
            setSelectedCountryId("");
        } catch (error) {
            console.error("Error deleting Country:", error);
        }
    };

    return (
        <div>
            <p>Pick Country</p>
            <select value={selectedCountryName} onChange={handleCountryChange}>
                <option value="">Select a Country</option>
                {Countries.map((country) => (
                    <option key={country.countryId} value={country.CountryName}>
                        {country.countryName}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">Pick</button>
        </div>
    );
};

export default PickCountry;
