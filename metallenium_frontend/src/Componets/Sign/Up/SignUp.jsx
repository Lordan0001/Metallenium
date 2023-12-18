import React, { useState } from "react";
import styles from "./SignUp.module.css";

import {useNavigate} from "react-router-dom";
import {UserService} from "../../../Service/UserService";

const SignUp = () => {
    const [userData, setUserData] = useState({
        userName: "",
        email: "",
        password: "",
    });
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const newUser = await UserService.register(userData);

            navigate('/login');
            setUserData({
                username: "",
                email: "",
                password: "",
            });
        } catch (error) {
            console.error("Error during registration:", error);
        }
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setUserData({
            ...userData,
            [name]: value,
        });
    };

    return (
        <div className={styles.RegisterContainer}>
            <form onSubmit={handleSubmit} className={styles.formSignUp}>
                <input className={styles.inputSignUp}
                       type="text"
                       placeholder="Username"
                       name="userName"
                       value={userData.userName}
                       onChange={handleInputChange}
                />
                <input className={styles.inputSignUp}
                       type="email"
                       placeholder="Email"
                       name="email"
                       value={userData.email}
                       onChange={handleInputChange}
                />
                <input className={styles.inputSignUp}
                       type="password"
                       placeholder="Password"
                       name="password"
                       value={userData.password}
                       onChange={handleInputChange}
                />
                <button className={styles.buttonSignUp}type="submit">Sign up</button>
            </form>
        </div>
    );
};

export default SignUp;
