import React, { useState } from "react";
import { BandService } from "../../../Service/BandService";
import {useRecoilState, useSetRecoilState} from "recoil";
import {bandsState} from "../../../Recoil/Atoms";

const UpdateBand = () => {
    const [bandData, setBandData] = useState({
        bandId : "",
        bandName: "",
        bandDescription: "",
        bandType: "",
        bandImageUrl: null,
    });

    const [bands,setBands] = useRecoilState(bandsState)


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
            formData.append("bandId", bandData.bandId);
            formData.append("bandName", bandData.bandName);
            formData.append("bandDescription", bandData.bandDescription);
            formData.append("bandType", bandData.bandType);
            formData.append("image", bandData.bandImageUrl);


            const newBand = await BandService.updateBand(formData);
            setBands((prevBands) =>[...prevBands,newBand])

            setBandData({
                bandId: "",
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
            <p>Update Band</p>
        <form onSubmit={handleSubmit}>
            <input
                type="number"
                name="bandId"
                placeholder="Band Id"
                value={bandData.bandId}
                onChange={handleInputChange}
            />
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

export default UpdateBand;
