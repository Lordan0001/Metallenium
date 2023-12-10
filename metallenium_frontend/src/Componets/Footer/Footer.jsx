import React from "react";
import styles from "./Footer.module.css";
const Footer = () => {
    return (
        <div className={styles.footerContainer}>
        <footer className={styles.footer}>
            <div className={styles.container}>
                <div className={styles.footerContent}>
                    <div className={styles.footerLinks}>
                        <a href="#">About</a>
                        <a href="#">Blog</a>
                        <a href="#">Contact</a>
                        <a href="#">Privacy</a>
                        <a href="#">Terms</a>
                    </div>

                </div>
            </div>
        </footer>
          </div>
    );
};

export default Footer;
