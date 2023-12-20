import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "../Pages/Home/Home";
import Album from "../Pages/Album/Album";
import Ticket from "../Pages/Ticket/Ticket";
import Register from "../Pages/Register/Register";
import Login from "../Pages/Login/Login";
import Account from "../Pages/Account/Account";


const Router = () =>{
    return <BrowserRouter>
        <Routes>
            <Route element={<Home/>} path='/' />
            <Route element={<Album/>} path='/albums/:id' />
            <Route element={<Ticket/>} path='/ticket' />
            {/*<Route element={<Manage/>} path='/manage' />*/}
            <Route element={<Register/>} path='/register' />
            <Route element={<Login/>} path='/login' />
            <Route element={<Account/>} path='/account' />
            <Route path='*' element={<div>Not found</div>} />
        </Routes>
    </BrowserRouter>
}
export default Router;