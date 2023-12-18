import React, { useState } from "react";
import styles from "./Header.module.css";
import { Link, useLocation } from "react-router-dom";
import {useRecoilState, useRecoilValue} from "recoil";
import {bandsState, userState} from "../../Recoil/Atoms";
import { useCookies } from "react-cookie";
import { BandService } from "../../Service/BandService";
import { RxCross2 } from "react-icons/rx";
import { IoSearchCircleSharp } from "react-icons/io5";

const Header = () => {

    const user = useRecoilValue(userState);

    const [cookies, , removeCookie] = useCookies(["jwt"]);
    const [searchValue, setSearchValue] = useState("");
    const [bands, setBands] = useRecoilState(bandsState);
    const location = useLocation();
    const isHomePage = location.pathname === "/";

    const handleLogout = () => {
        removeCookie("jwt");
        window.location.reload();
    };

    const handleSearch = async () => {
        try {
            const searchData = {
                bandName: searchValue,
                bandType: "fake",
                bandDescription: "fake",
            };
            const searchedBands = await BandService.searchBand(searchData);
            setBands(searchedBands);
        } catch (e) {
            console.error(e);
        }
    };

    const handleCross = async () => {
        try {
            const allBands = await BandService.getAllBands();
            setBands(allBands);
            setSearchValue("");
        } catch (e) {
            console.error(e);
        }
    };


    return (
        <header className={styles.header}>
            <nav className={styles.nav}>
                <Link className={styles.logo} to="/">
                    Metallenium
                </Link>

                {isHomePage && (
                    <div className={styles.searchContainer}>
                        <input
                            type="text"
                            className={styles.searchInput}
                            placeholder="Search..."
                            value={searchValue}
                            onChange={(e) => setSearchValue(e.target.value)}
                            onKeyDown={(e) => {
                                if (e.key === "Enter") {
                                    handleSearch();
                                }
                            }}
                        />
                        <IoSearchCircleSharp
                            className={styles.searchIcon}
                            onClick={handleSearch}
                        />
                        {searchValue && (
                            <RxCross2
                                className={styles.crossIcon}
                                onClick={handleCross}
                            />
                        )}
                    </div>
                )}
                <ul className={styles.menu}>
                    <li><Link className={styles.linkHeader} to="/">Home</Link></li>
                    <li><Link className={styles.linkHeader} to="/ticket">Tickets</Link></li>

                    {user.role === "admin" && (
                        <li>
                            <Link className={styles.linkHeader} to="/manage">Manage</Link>
                        </li>
                    )}

                    {cookies.jwt ? (
                        <><li><button className={styles.logoutButton}
                                    onClick={handleLogout}>Logout</button>
                            </li>
                        </>
                    ) : (
                        <>
                            <li>
                                <Link className={styles.linkHeader} to="/register">Sign up</Link>
                            </li>
                            <li>
                                <Link className={styles.linkHeader} to="/login">Sign in</Link>
                            </li>
                        </>
                    )}
                </ul>
            </nav>
        </header>
    );
};

export default Header;
