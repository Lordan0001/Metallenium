import React, { useState, useEffect } from "react";
import { AlbumService } from "../../../Service/AlbumService";
import { BandService } from "../../../Service/BandService";
import { useRecoilState, useSetRecoilState } from "recoil";
import { albumsState, bandsState } from "../../../Recoil/Atoms";

const UpdateAlbum = () => {
    const [albumData, setAlbumData] = useState({
        albumId: "",
        albumName: "",
        albumDescription: "",
        albumImageUrl: null,
        bandId: "",
    });

    const [bands, setBands] = useRecoilState(bandsState);
    const [albums, setAlbums] = useRecoilState(albumsState);


    useEffect(() => {
        // Fetch bands data and store them in the state
        const fetchBands = async () => {
            try {
                const data = await BandService.getAllBands();
                setBands(data);

                const dataAlbums = await AlbumService.getAllAlbums();
                setAlbums(dataAlbums);
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

    const handleAlbumSelect = (event) => {
        const selectedAlbum = albums.find((album) => album.albumId === event.target.value);
        setAlbumData({
            ...selectedAlbum,
            albumId: event.target.value,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            // Prepare form data to send to the server
            const formData = new FormData();
            formData.append("albumId", albumData.albumId);
            formData.append("albumName", albumData.albumName);
            formData.append("albumDescription", albumData.albumDescription);
            formData.append("bandId", albumData.bandId);
            formData.append("image", albumData.albumImageUrl);

            const updatedAlbum = await AlbumService.updateAlbum(formData);

            setAlbums((prevAlbums) =>
                prevAlbums.map((album) =>
                    album.albumId === updatedAlbum.albumId ? updatedAlbum : album
                )
            );

            setAlbumData({
                albumId: "",
                albumName: "",
                albumDescription: "",
                bandId: "",
                albumImageUrl: null,
            });
        } catch (error) {
            console.error("Error updating album:", error);
        }
    };

    return (
        <div>
            <p>Update Album</p>
            <form onSubmit={handleSubmit}>
                <select name="albumId" value={albumData.albumId} onChange={handleAlbumSelect}>
                    <option value="" disabled>Select an Album</option>
                    {albums.map((album) => (
                        <option key={album.albumId} value={album.albumId}>
                            {album.albumName}
                        </option>
                    ))}
                </select>
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
                <button type="submit">Update Album</button>
            </form>
        </div>
    );
};

export default UpdateAlbum;
