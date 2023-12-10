import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {AlbumService} from "../../Service/AlbumService";
import {BandService} from "../../Service/BandService";
import styles from "./Album.module.css";
import {useRecoilState} from "recoil";
import {albumsState, bandsState} from "../../Recoil/Atoms";
import Header from "../../Componets/Header/Header";
import BandItem from "../../Componets/BandItem/BandItem";
import AlbumItem from "../../Componets/AlbumItem/AlbumItem";
import Footer from "../../Componets/Footer/Footer";

const Album = () => {
    const [albums, setAlbums] = useRecoilState(albumsState)
    const [bands,setBands] = useRecoilState(bandsState)

    const { id } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            try {
                if (!id) {
                    const data = await AlbumService.getAllAlbums();
                    setAlbums(data);
                    setBands([]);
                } else {

                    const albumData = await AlbumService.getAlbumsByBand(id);
                    setAlbums(albumData);


                    const bandData = await BandService.getOneBand(id);
                    setBands([bandData]);
                }
            } catch (error) {
                console.error("Error fetching albums:", error);
                setAlbums([]);
                setBands([]);
            }
            finally {

            }
        };
        fetchData();
    }, [id]);



    return (
        <div className={styles.pageContainer}>
            <Header />
{/*            <div className={`${styles.bandsContainerAlbum}`}>
                {bands.length ? (
                    bands.map((band) => <BandItem key={band.bandId} band={band} />)
                ) : (
                    <div>no bands</div>
                )}
            </div>*/}
            <div className={`${styles.albumsContainer} `}>
                {albums.length ? (
                    albums.map((album) => (
                        <AlbumItem
                            key={album.albumId}
                            album={album}
                        />
                    ))
                ) : (
                    <div>no albums</div>
                )}
            </div>
            <Footer className={`${styles.footer}`} />


        </div>
    );
};

export default Album;
