import React, { useState, useEffect } from "react";
import { AlbumService } from "../../../Service/AlbumService";
import { BandService } from "../../../Service/BandService";
import { useRecoilState, useSetRecoilState } from "recoil";
import { albumsState, bandsState } from "../../../Recoil/Atoms";

const AddAlbum = () => {
    const [albumData, setAlbumData] = useState({
        albumName: "",
        albumDescription: "",
        albumImageUrl: null,
        bandId: "",
    });

    const [bands, setBands] = useRecoilState(bandsState);
    const setAlbums = useSetRecoilState(albumsState);

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

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setAlbumData({
            ...albumData,
            [name]: value,
        });
    };

    const handleImageChange = (event) => {
        const file = event.target.files[0];
        setAlbumData({
            ...albumData,
            albumImageUrl: file,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Prepare form data to send to the server
            const formData = new FormData();
            formData.append("albumName", albumData.albumName);
            formData.append("albumDescription", albumData.albumDescription);
            formData.append("bandId", albumData.bandId);
            formData.append("image", albumData.albumImageUrl);

            console.log( albumData.bandId)
            const newAlbum = await AlbumService.addAlbum(formData);

            setAlbums((prevAlbums) => [...prevAlbums, newAlbum]);
            setAlbumData({
                albumName: "",
                bandId: "",
                albumDescription: "",
                albumImageUrl: null,
            });
        } catch (error) {
            console.error("Error adding album:", error);
        }
    };

    return (
        <div>
            <p>Add Album</p>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="albumName"
                    placeholder="Album Name"
                    value={albumData.albumName}
                    onChange={handleInputChange}
                />
                <input
                    type="text"
                    name="albumDescription"
                    placeholder="Album Description"
                    value={albumData.albumDescription}
                    onChange={handleInputChange}
                />
                <select name="bandId" value={albumData.bandId} onChange={handleInputChange}>
                    <option value="">Select a Band</option>
                    {bands.map((band) => (
                        <option key={band.bandId} value={band.bandId}>
                            {band.bandName}
                        </option>
                    ))}
                </select>
                {/* Input for image upload */}
                <input type="file" name="image" onChange={handleImageChange} />
                <button type="submit">Send</button>
            </form>
        </div>
    );
};

export default AddAlbum;
