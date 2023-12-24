import React, { useState } from "react";
import styles from "./SignUp.module.css";
import { useNavigate } from "react-router-dom";
import { UserService } from "../../../Service/UserService";

const SignUp = () => {
    const [userData, setUserData] = useState({
        userFirstName: "",
        userSecondName: "",
        userEmail: "",
        userPassword: "",
    });
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const newUser = await UserService.register(userData);

            navigate("/login");
            setUserData({
                userFirstName: "",
                userSecondName: "",
                userEmail: "",
                userPassword: "",
            });
        } catch (error) {
            alert("User with this email already exists!");
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
                <input
                    className={styles.inputSignUp}
                    type="text"
                    placeholder="First Name"
                    name="userFirstName"
                    value={userData.userFirstName}
                    onChange={handleInputChange}
                />
                <input
                    className={styles.inputSignUp}
                    type="text"
                    placeholder="Second Name"
                    name="userSecondName"
                    value={userData.userSecondName}
                    onChange={handleInputChange}
                />
                <input
                    className={styles.inputSignUp}
                    type="email"
                    placeholder="Email"
                    name="userEmail"
                    value={userData.userEmail}
                    onChange={handleInputChange}
                />
                <input
                    className={styles.inputSignUp}
                    type="password"
                    placeholder="Password"
                    name="userPassword"
                    value={userData.userPassword}
                    onChange={handleInputChange}
                />
                <button className={styles.buttonSignUp} type="submit">
                    Sign up
                </button>
            </form>
        </div>
    );
};

export default SignUp;
