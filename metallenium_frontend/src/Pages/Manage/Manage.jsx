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
import {UserService} from "../../Service/UserService";
import {useCookies} from "react-cookie";
import {useRecoilState} from "recoil";
import {tokenState, userState} from "../../Recoil/Atoms";


const Manage = () => {
    const [currentMode, setCurrentMode] = useState("Add");
    const [cookies, setCookie, removeCookie] = useCookies(['jwt']);
    const [token, setToken] = useRecoilState(tokenState);
    const [user, setUser] = useRecoilState(userState);

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
        const fetchData = async () => {
            try {
                const savedMode = localStorage.getItem("currentMode");
                if (savedMode && modes.some((mode) => mode.label === savedMode)) {
                    setCurrentMode(savedMode);
                }
                if(cookies.jwt){
                    setToken(cookies.jwt);
                    if (token !='') {
                        const userData = await UserService.getMe(token);
                        setUser(userData);
                    }
                }

            } catch (error) {
                console.error('Error fetching bands:', error);
            } finally {

            }
        };


        fetchData();
    }, [cookies, token]);

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
