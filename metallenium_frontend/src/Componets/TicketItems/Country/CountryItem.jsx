import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {citiesState, countriesState, selectedCountriesState} from "../../../Recoil/Atoms";
import {CountryService as cityService, CountryService} from "../../../Service/CountryService";
import {CityService} from "../../../Service/CityService";


const PickCountry = () => {

    const [Countries, setCountries] = useRecoilState(countriesState)
    const [Cities, setCities] = useRecoilState(citiesState)
    const [selectedCountryName, setSelectedCountryName] = useState("");
    const [selectedCountryId, setSelectedCountryId] = useRecoilState(selectedCountriesState);

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
    }, [selectedCountryName]);

    const  handleCountryChange = async (event) => {
        setSelectedCountryName(event.target.value);

        // Find the corresponding CountryId based on the selected CountryName
        const selectedCountry = Countries.find((Country) => Country.countryName === event.target.value);
        if (selectedCountry) {
            setSelectedCountryId(selectedCountry.countryId);
            console.log(selectedCountry.countryId)
            const newData = await CityService.getCitiesByCountryId(selectedCountry.countryId);
            setCities(newData);

        } else {
            setSelectedCountryId("");
        }
    };


    return (
        <div>
            <p>Pick Country</p>
            <select value={selectedCountryName} onChange={handleCountryChange}>
                <option value="">Select a Country</option>
                {Countries.map((country) => (
                    <option key={country.countryId} value={country.countryName}>
                        {country.countryName}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default PickCountry;
