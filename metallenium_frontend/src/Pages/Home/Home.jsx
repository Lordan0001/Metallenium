import {useRecoilState} from "recoil";
import {bandsState} from "../../Recoil/Atoms";
import {useEffect} from "react";
import {BandService} from "../../Service/BandService";
import Header from "../../Componets/Header/Header";
import Footer from "../../Componets/Footer/Footer";
import BandItem from "../../Componets/BandItem/BandItem";
import styles from './Home.module.css';
const Home = () =>{
    const [bands, setBands] = useRecoilState(bandsState);

    useEffect(() => {

        const fetchData = async () => {
            try {
                const data = await BandService.getAllBands();
                setBands(data);
            }
            catch (error){
                console.error('Error fetching bands:', error);
            }
        }
        fetchData();
    }, []);


return(
    <div className={styles.pageContainer}>
        <Header />
        <div className={`${styles.bandsContainer}`}>
            {bands.length ? (
                bands.map((band) => <BandItem key={band.bandId} band={band} />)
            ) : (
                <div>No bands</div>
            )}
        </div>
        <Footer className={`${styles.footer}`} />
    </div>

)}
export default Home;