import Header from "../../Componets/Header/Header";
import Footer from "../../Componets/Footer/Footer";
import styles from './Register.module.css'
import React from "react";
import SignUp from "../../Componets/Sign/Up/SignUp";
const Register = () =>{


    return(
        <div >
            <Header />
            <div className={styles.RegisterContainer}>
                <SignUp/>
            </div>
            <Footer/>
        </div>
    )
}
export default Register;