import React from "react";
import styles from "./Footer.module.css";
import {Link} from "react-router-dom";
const Footer = () => {
    return (
        <div className={styles.footerContainer}>
        <footer className={styles.footer}>
            <div className={styles.container}>
                <div className={styles.footerContent}>
                    <div className={styles.footerLinks}>
                        <Link className={styles.linkHeader} to="/footerinfo">About</Link>
                        <Link className={styles.linkHeader} to="/footerinfo">Contact</Link>
                        <Link className={styles.linkHeader} to="/footerinfo">Privacy</Link>
                        <Link className={styles.linkHeader} to="/footerinfo">Terms</Link>
                    </div>

                </div>
            </div>
        </footer>
          </div>
    );
};

export default Footer;
