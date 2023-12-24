import {useEffect, useState} from "react";
import Header from "../../Componets/Header/Header";
import styles from "./ManageTicket.module.css";
import Footer from "../../Componets/Footer/Footer";
import AddCountry from "../../Componets/ManageTicketItem/Add/AddCountry";
import AddCity from "../../Componets/ManageTicketItem/Add/AddCity";
import AddPlace from "../../Componets/ManageTicketItem/Add/AddPlace";
import UpdateCountry from "../../Componets/ManageTicketItem/Update/UpdateCountry";
import UpdateCity from "../../Componets/ManageTicketItem/Update/UpdateCity";
import UpdatePlace from "../../Componets/ManageTicketItem/Update/UpdatePlace";
import DeleteCountry from "../../Componets/ManageTicketItem/Delete/DeleteCountry";
import DeleteCity from "../../Componets/ManageTicketItem/Delete/DeleteCity";
import DeletePlace from "../../Componets/ManageTicketItem/Delete/DeletePlace";
import {useCookies} from "react-cookie";
import {BandService} from "../../Service/BandService";
import {UserService} from "../../Service/UserService";
import {useRecoilState} from "recoil";
import {tokenState, userState} from "../../Recoil/Atoms";


const ManageTicket = () => {
    const [currentMode, setCurrentMode] = useState("Add");
    const [cookies, setCookie, removeCookie] = useCookies(['jwt']);
    const [token, setToken] = useRecoilState(tokenState);
    const [user, setUser] = useRecoilState(userState);

    const modes = [
        {
            label: "Add",
            components: [<AddCountry />, <AddCity />,<AddPlace/>]
        },
        {
            label: "Update",
            components: [<UpdateCountry />, <UpdateCity />, <UpdatePlace/>]
        },
        {
            label: "Delete",
            components: [<DeleteCountry />, <DeleteCity />,<DeletePlace/>]
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

export default ManageTicket;
