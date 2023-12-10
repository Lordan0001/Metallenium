import React from "react";
import styles from './AlbumItem.module.css'
const AlbumItem = ({ album }) => {

    console.log(album.albumImageUrl);
    return (
        <div className={styles.albumItem}>
            <img
                src={`https://localhost:7007/${album.albumImageUrl}`}
                alt={album.albumName}
                className={styles.albumImage}
            />
            <h2>{album.albumName}</h2>
            <p>{album.albumDescription}</p>
        </div>
    );
};

export default AlbumItem;
