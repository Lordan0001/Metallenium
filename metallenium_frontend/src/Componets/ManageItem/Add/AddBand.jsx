import React, { useState } from "react";
import { BandService } from "../../../Service/BandService";
import {useSetRecoilState} from "recoil";
import {bandsState} from "../../../Recoil/Atoms";

const AddBand = () => {
    const [bandData, setBandData] = useState({
        bandName: "",
        bandDescription: "",
        bandType: "",
        bandImageUrl: null,
    });
    const setBands = useSetRecoilState(bandsState);
    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setBandData({
            ...bandData,
            [name]: value,
        });
    };

    const handleImageChange = (event) => {
        const file = event.target.files[0];
        setBandData({
            ...bandData,
            bandImageUrl: file,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Prepare form data to send to the server
            const formData = new FormData();
            formData.append("bandName", bandData.bandName);
            formData.append("bandDescription", bandData.bandDescription);
            formData.append("bandType", bandData.bandType);
            formData.append("image", bandData.bandImageUrl);


            const newBand = await BandService.addBand(formData);
            //window.location.reload();//Temp
            setBands((prevBands) => [...prevBands, newBand]);

            setBandData({
                bandName: "",
                bandDescription: "",
                bandType: "",
                bandImageUrl: null,
            });
        } catch (error) {
            console.error("Error adding band:", error);
        }
    };

    return (
        <div>
            <p>Add Band</p>
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                name="bandName"
                placeholder="Band Name"
                value={bandData.bandName}
                onChange={handleInputChange}
            />
            <input
                type="text"
                name="bandDescription"
                placeholder="Band Description"
                value={bandData.bandDescription}
                onChange={handleInputChange}
            />
            <input
                type="text"
                name="bandType"
                placeholder="Band Type"
                value={bandData.bandType}
                onChange={handleInputChange}
            />
            {/* Input for image upload */}
            <input type="file" name="image" onChange={handleImageChange} />
            <button  type="submit">Send</button>
        </form></div>
    );
};

export default AddBand;
