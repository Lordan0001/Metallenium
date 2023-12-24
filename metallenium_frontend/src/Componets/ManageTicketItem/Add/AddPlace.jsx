import React, { useState, useEffect } from "react";
import { PlaceService } from "../../../Service/PlaceService";
import { useRecoilState, useSetRecoilState } from "recoil";
import { citiesState } from "../../../Recoil/Atoms";
import { CityService } from "../../../Service/CityService";

const AddPlace = () => {
    const [placeData, setPlaceData] = useState({
        address: "",
        date: "", // Assuming date is a string, adjust accordingly
        cityId: "",
        capacity: ""
    });

    const [cities, setCities] = useRecoilState(citiesState);

    useEffect(() => {
        const fetchCities = async () => {
            try {
                const data = await CityService.getAllCities();
                setCities(data);
            } catch (error) {
                console.error("Error fetching cities:", error);
            }
        };

        fetchCities();
    }, [setCities]);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setPlaceData({
            ...placeData,
            [name]: value,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Send data as JSON
            const newPlace = await PlaceService.addPlace(placeData);

            // Update Recoil state
            setCities((prevCities) => [...prevCities, newPlace]);

            // Clear the form
            setPlaceData({
                address: "",
                date: "",
                cityId: "",
                capacity: ""
            });
        } catch (error) {
            console.error("Error adding place:", error);
        }
    };

    return (
        <div>
            <p>Add Place</p>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="address"
                    placeholder="Place Address"
                    value={placeData.address}
                    onChange={handleInputChange}
                />
                <input
                    type="text"
                    name="date"
                    placeholder="YYYY-MM-DDTHH:MM"
                    value={placeData.date}
                    onChange={handleInputChange}
                />
                <input
                    type="text"
                    name="capacity"
                    placeholder="Capacity"
                    value={placeData.capacity}
                    onChange={handleInputChange}
                />
                <select
                    name="cityId"
                    value={placeData.cityId}
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
                <button type="submit">Add Place</button>
            </form>
        </div>
    );
};

export default AddPlace;
