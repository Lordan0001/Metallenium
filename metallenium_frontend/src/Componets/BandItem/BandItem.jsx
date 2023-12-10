import React from "react";
import { Link } from "react-router-dom";
import styles from './BandItem.module.css'

const BandItem = ({ band }) => {
    return (
       <Link to={`/albums/${band.bandId}`} className={styles.bandLink}>
            <div className={styles.bandItem}>
                <img
                    src={`https://localhost:7007/${band.bandImageUrl}`}
                    alt={band.bandName}
                    className={styles.bandImage}
                />
                <h2 className={styles.bandName}>{band.bandName}</h2>
                <p className={styles.bandDescription}>{band.bandDescription}</p>
                <p className={styles.bandType}>{band.bandType}</p>
            </div>
        </Link>
    );
};

export default BandItem;
