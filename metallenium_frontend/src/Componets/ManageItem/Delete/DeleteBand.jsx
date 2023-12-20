import React, {useState, useEffect} from "react";
import {BandService} from "../../../Service/BandService";
import {useRecoilState} from "recoil";
import {bandsState} from "../../../Recoil/Atoms";

const DeleteBand = () => {

    const [bands, setBands] = useRecoilState(bandsState)
    const [selectedBandName, setSelectedBandName] = useState("");
    const [selectedBandId, setSelectedBandId] = useState("");

    useEffect(() => {
        // Fetch bands data and store them in the state
        const fetchBands = async () => {
            try {
                const data = await BandService.getAllBands();
                setBands(data);
            } catch (error) {
                console.error("Error fetching bands:", error);
            }
        };

        fetchBands();
    }, []);

    const handleBandChange = (event) => {
        setSelectedBandName(event.target.value);

        // Find the corresponding bandId based on the selected bandName
        const selectedBand = bands.find((band) => band.bandName === event.target.value);
        if (selectedBand) {
            setSelectedBandId(selectedBand.bandId);
        } else {
            setSelectedBandId("");
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newBand = await BandService.deleteBand(selectedBandId);
            setBands((prevBands) => prevBands.filter((band) => band.bandId !== selectedBandId));

            // Clear the selected values
            setSelectedBandName("");
            setSelectedBandId("");
        } catch (error) {
            console.error("Error deleting band:", error);
        }
    };

    return (
        <div>
            <p>Delete Band</p>
            <select value={selectedBandName} onChange={handleBandChange}>
                <option value="">Select a Band</option>
                {bands.map((band) => (
                    <option key={band.bandId} value={band.bandName}>
                        {band.bandName}
                    </option>
                ))}
            </select>
            <button onClick={handleSubmit} type="button">Delete</button>
        </div>
    );
};

export default DeleteBand;
