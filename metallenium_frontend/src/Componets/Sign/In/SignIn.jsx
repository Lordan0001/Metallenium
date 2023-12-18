import React, { useState } from "react";
import styles from "./SignIn.module.css";

import { useNavigate } from "react-router-dom"
import {UserService} from "../../../Service/UserService";

const SignIn = () => {
    const [user, setUser] = useState({
        email: "",
        password: ""
    });
    const navigate = useNavigate();


    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setUser({
            ...user,
            [name]: value,
        });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newUser = await UserService.authenticate(user);
            document.cookie = `jwt=${newUser.token}; path=/`;

            navigate("/");
            setUser({
                email: "",
                password: "",
            });
        } catch (error) {
            console.error("Error during login:", error);
        }
    };

    return (
        <div className={styles.LoginContainer}>
            <form onSubmit={handleSubmit} className={styles.formSignIn}>
                <input
                    className={styles.inputSignIn}
                    type="email"
                    placeholder="Email"
                    name="email"
                    value={user.email}
                    onChange={handleInputChange}
                />
                <input
                    className={styles.inputSignIn}
                    type="password"
                    placeholder="Password"
                    name="password"
                    value={user.password}
                    onChange={handleInputChange}
                />
                <button className={styles.buttonSignIn} type="submit">
                    Sign in
                </button>
            </form>
        </div>
    );
};

export default SignIn;
