import {useRecoilState} from "recoil";
import {useEffect, useState} from "react";
import {placesState, selectedPlacesState} from "../../../Recoil/Atoms";
import {PlaceService} from "../../../Service/PlaceService";
import styles from './PlaceItem.module.css'

const PickPlace = () => {

    const [Places, setPlaces] = useRecoilState(placesState)
    const [selectedPlaceName, setSelectedPlaceName] = useState("");
    const [selectedPlaceId, setSelectedPlaceId] = useRecoilState(selectedPlacesState);

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

        // Получите первые 5 символов из event.target.value
        const inputAddressPrefix = event.target.value.substring(0, 5);

        // Найдите соответствующее место по адресу, сравнивая первые 5 символов
        const selectedPlace = Places.find((place) => {
            const placeAddressPrefix = place.address.substring(0, 5);
            return placeAddressPrefix === inputAddressPrefix;
        });

        if (selectedPlace) {
            setSelectedPlaceId(selectedPlace.placeId);
            console.log(selectedPlace.placeId);
        } else {
            setSelectedPlaceId("");
        }
    };


    return (
        <div className={styles.container}>
            <p className={styles.selectContainer}>Pick Place</p>
            <select className={styles.selectPlace} value={selectedPlaceName} onChange={handlePlaceChange}>
                <option value="">Select a Place</option>
                {Places.map((place) => (
                    <option key={place.placeId} value={`${place.address} - ${place.date}`}>
                        {`${place.address} - ${place.date}`}
                    </option>
                ))}
            </select>
        </div>
    );
};
export default PickPlace;
