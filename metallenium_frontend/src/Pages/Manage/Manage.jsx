import {useEffect, useState} from "react";
import AddBand from "../../Componets/ManageItem/Add/AddBand";
import AddAlbum from "../../Componets/ManageItem/Add/AddAlbum";
import UpdateBand from "../../Componets/ManageItem/Update/UpdateBand";
import UpdateAlbum from "../../Componets/ManageItem/Update/UpdateAlbum";
import DeleteBand from "../../Componets/ManageItem/Delete/DeleteBand";
import DeleteAlbum from "../../Componets/ManageItem/Delete/DeleteAlbum";
import Header from "../../Componets/Header/Header";
import styles from "./Manage.module.css";
import Footer from "../../Componets/Footer/Footer";


const Manage = () => {
    const [currentMode, setCurrentMode] = useState("Add");

    const modes = [
        {
            label: "Add",
            components: [<AddBand />, <AddAlbum />]
        },
        {
            label: "Update",
            components: [<UpdateBand />, <UpdateAlbum />]
        },
        {
            label: "Delete",
            components: [<DeleteBand />, <DeleteAlbum />]
        }
    ];

    const handleModeChange = (newMode) => {
        setCurrentMode(newMode);
        // Сохраняем текущий режим в локальное хранилище
        localStorage.setItem("currentMode", newMode);
    };

    useEffect(() => {
        // Восстанавливаем текущий режим из локального хранилища при загрузке компонента
        const savedMode = localStorage.getItem("currentMode");
        if (savedMode && modes.some((mode) => mode.label === savedMode)) {
            setCurrentMode(savedMode);
        }
    }, []);

    return (
        <div>
            <Header />
            <div className={styles.mainContainer}>
                <div>
                    {modes.map((mode, index) => (
                        <button
                            key={index}
                            onClick={() => handleModeChange(mode.label)}
                            className={styles.button23}
                        >
                            {mode.label}
                        </button>
                    ))}
                </div>

                <div className={styles.container}>
                    {modes.find((mode) => mode.label === currentMode).components.map((component, index) => (
                        <div key={index} className={styles.formContainer}>
                            {component}
                        </div>
                    ))}
                </div>

            </div>
            <Footer />
        </div>
    );
};

export default Manage;
