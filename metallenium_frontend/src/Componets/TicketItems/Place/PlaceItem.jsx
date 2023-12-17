import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {placesState} from "../../../Recoil/Atoms";
import {PlaceService} from "../../../Service/PlaceService";


const PickPlace = () => {

    const [Places, setPlaces] = useRecoilState(placesState)
    const [selectedPlaceName, setSelectedPlaceName] = useState("");
    const [selectedPlaceId, setSelectedPlaceId] = useState("");

    useEffect(() => {
        // Fetch Places data and store them in the state
        const fetchPlaces = async () => {
            try {
                const data = await PlaceService.getAllPlaces();
                setPlaces(data);
            } catch (error) {
                console.error("Error fetching Places:", error);
            }
        };

        fetchPlaces();
    }, []);

    const handlePlaceChange = (event) => {
        setSelectedPlaceName(event.target.value);

        // Find the corresponding PlaceId based on the selected PlaceName
        const selectedPlace = Places.find((Place) => Place.PlaceName === event.target.value);
        if (selectedPlace) {
            setSelectedPlaceId(selectedPlace.PlaceId);
        } else {
            setSelectedPlaceId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newPlace = await PlaceService.PickPlace(selectedPlaceId);
            setPlaces((prevPlaces) => prevPlaces.filter((Place) => Place.PlaceId !== selectedPlaceId));

            // Clear the selected values
            setSelectedPlaceName("");
            setSelectedPlaceId("");
        } catch (error) {
            console.error("Error deleting Place:", error);
        }
    };

    return (
        <div>
            <p>Pick Place</p>
            <select value={selectedPlaceName} onChange={handlePlaceChange}>
                <option value="">Select a Place</option>
                {Places.map((place) => (
                    <option key={place.placeId} value={`${place.address} - ${place.date}`}>
                        {`${place.address} - ${place.date}`}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">Pick</button>
        </div>
    );
};

export default PickPlace;
