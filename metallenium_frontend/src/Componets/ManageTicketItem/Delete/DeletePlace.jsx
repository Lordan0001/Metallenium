import React, { useState, useEffect } from "react";
import { PlaceService } from "../../../Service/PlaceService";
import { useRecoilState } from "recoil";
import { placesState } from "../../../Recoil/Atoms";

const DeletePlace = () => {
    const [places, setPlaces] = useRecoilState(placesState);
    const [selectedPlaceAddress, setSelectedPlaceAddress] = useState("");
    const [selectedPlaceId, setSelectedPlaceId] = useState("");

    useEffect(() => {
        // Fetch places data and store them in the state
        const fetchPlaces = async () => {
            try {
                const data = await PlaceService.getAllPlaces();
                setPlaces(data);
            } catch (error) {
                console.error("Error fetching places:", error);
            }
        };

        fetchPlaces();
    }, []);

    const handlePlaceChange = (event) => {
        setSelectedPlaceAddress(event.target.value);

        // Find the corresponding placeId based on the selected placeAddress
        const selectedPlace = places.find((place) => place.address === event.target.value);
        if (selectedPlace) {
            setSelectedPlaceId(selectedPlace.placeId);
        } else {
            setSelectedPlaceId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Delete the place and update Recoil state
            await PlaceService.deletePlace(selectedPlaceId);

            setPlaces((prevPlaces) =>
                prevPlaces.filter((place) => place.placeId !== selectedPlaceId)
            );

            setSelectedPlaceAddress("");
            setSelectedPlaceId("");
        } catch (error) {
            console.error("Error deleting place:", error);
        }
    };

    return (
        <div>
            <p>Delete Place</p>
            <select value={selectedPlaceAddress} onChange={handlePlaceChange}>
                <option value="">Select a Place</option>
                {places.map((place) => (
                    <option key={place.placeId} value={place.address}>
                        {place.address}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">
                Delete
            </button>
        </div>
    );
};

export default DeletePlace;
