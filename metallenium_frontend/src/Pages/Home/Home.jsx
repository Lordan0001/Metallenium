import {useRecoilState} from "recoil";
import {bandsState, tokenState, userState} from "../../Recoil/Atoms";
import {useEffect, useState} from "react";
import {BandService} from "../../Service/BandService";
import Header from "../../Componets/Header/Header";
import Footer from "../../Componets/Footer/Footer";
import BandItem from "../../Componets/BandItem/BandItem";
import styles from './Home.module.css';
import {useCookies} from "react-cookie";
import {UserService} from "../../Service/UserService";

const Home = () => {//add get user by email to use in ticket
    const [bands, setBands] = useRecoilState(bandsState);
    const [loading, setLoading] = useState(true);
    const [token, setToken] = useRecoilState(tokenState);
    const [user, setUser] = useRecoilState(userState);
    const [cookies, setCookie, removeCookie] = useCookies(['jwt']);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await BandService.getAllBands();
                setBands(data);
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
                setLoading(false);
            }
        };


        fetchData();
    }, [cookies, token]);

    return (
        <div className={styles.pageContainer}>
            <Header />
            <div className={`${styles.bandsContainer} ${!loading ? styles.loaded : ''}`}>
                {bands.length ? (
                    bands.map((band) => <BandItem key={band.bandId} band={band} />)
                ) : (
                    <div>No bands</div>
                )}
            </div>
            <Footer className={`${styles.footer}`} />
        </div>
    );
};
export default Home;