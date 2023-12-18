import Header from "../../Componets/Header/Header";
import Footer from "../../Componets/Footer/Footer";
import React from "react";
import styles from './Login.module.css'
import SignIn from "../../Componets/Sign/In/SignIn";
const Login = () =>{


    return(
        <div >
            <Header />
            <div className={styles.LoginContainer}>
                <SignIn/>
            </div>
            <Footer/>
        </div>
    )
}
export default Login;