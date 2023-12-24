// FooterInfo.jsx

import React from "react";
import styles from "./FooterInfo.module.css";
import Header from "../../Componets/Header/Header";
import Footer from "../../Componets/Footer/Footer";

const FooterInfo = () => {
    return (
        <div className={styles.pageContainer}>
            <Header />
            <div className={styles.contentContainer}>
                <div className={styles.footerInfo}>
                    <section className={styles.aboutSection}>
                        <h2 className={styles.sectionTitle}>About Us</h2>
                        <p className={styles.sectionContent}>
                            This coursework is the last one in the course of study. I hope the work went well.
                        </p>
                    </section>
                    <section className={styles.contactSection}>
                        <h2 className={styles.sectionTitle}>Contact Us</h2>
                        <p className={styles.sectionContent}>
                            Email: metalleniumoffical@gmail.com
                        </p>
                        <p className={styles.sectionContent}>
                            Phone: (123) 456-7890
                        </p>
                    </section>
                    <section className={styles.privacySection}>
                        <h2 className={styles.sectionTitle}>Privacy Policy</h2>
                        <p className={styles.sectionContent}>
                            We do not share your data with third parties.
                        </p>
                    </section>
                    <section className={styles.termsSection}>
                        <h2 className={styles.sectionTitle}>Terms of Service</h2>
                        <p className={styles.sectionContent}>
                            Please don't try to break this site.
                        </p>
                    </section>
                </div>
            </div>
            <Footer className={styles.footer} />
        </div>
    );
};

export default FooterInfo;
