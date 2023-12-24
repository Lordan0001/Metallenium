import React, { useState, useEffect } from "react";
import { PlaceService } from "../../../Service/PlaceService";
import { useRecoilState, useSetRecoilState } from "recoil";
import { citiesState, placesState } from "../../../Recoil/Atoms";
import { CityService } from "../../../Service/CityService";

const UpdatePlace = () => {
    const [placeData, setPlaceData] = useState({
        placeId: "",
        address: "",
        date: "",
        cityId: "",
        capacity: ""
    });

    const [cities, setCities] = useRecoilState(citiesState);
    const [places, setPlaces] = useRecoilState(placesState);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const cityData = await CityService.getAllCities();
                const placeData = await PlaceService.getAllPlaces();

                setCities(cityData);
                setPlaces(placeData);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchData();
    }, [setCities, setPlaces]);

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
            const updatedPlace = await PlaceService.updatePlace({
                placeId: placeData.placeId,
                address: placeData.address,
                date: placeData.date,
                cityId: placeData.cityId,
                capacity: placeData.capacity
            });

            // Update Recoil state
            setPlaces((prevPlaces) =>
                prevPlaces.map((place) =>
                    place.placeId === updatedPlace.placeId
                        ? updatedPlace
                        : place
                )
            );

            // Clear the form
            setPlaceData({
                placeId: "",
                address: "",
                date: "",
                cityId: "",
                capacity: ""
            });
        } catch (error) {
            console.error("Error updating place:", error);
        }
    };

    return (
        <div>
            <p>Update Place</p>
            <form onSubmit={handleSubmit}>
                <select
                    name="placeId"
                    value={placeData.placeId}
                    onChange={handleInputChange}
                >
                    <option value="" disabled>
                        Select a Place
                    </option>
                    {places.map((place) => (
                        <option key={place.placeId} value={place.placeId}>
                            {place.address}
                        </option>
                    ))}
                </select>
                <input
                    type="text"
                    name="address"
                    placeholder="Update Place Address"
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
                    placeholder="Update Capacity"
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
                <button type="submit">Update Place</button>
            </form>
        </div>
    );
};

export default UpdatePlace;
