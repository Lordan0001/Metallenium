import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "../Pages/Home/Home";
import Album from "../Pages/Album/Album";
// import Album from "../Pages/Album/Album";
// import Manage from "../Pages/Manage/Manage";
// import Register from "../Pages/Register/Register";
// import Login from "../Pages/Login/Login";
// import Ticket from "../Pages/Ticket/Ticket";

const Router = () =>{
    return <BrowserRouter>
        <Routes>
            <Route element={<Home/>} path='/' />
            <Route element={<Album/>} path='/albums/:id' />
            {/*<Route element={<Ticket/>} path='/ticket' />*/}
            {/*<Route element={<Manage/>} path='/manage' />*/}
            {/*<Route element={<Register/>} path='/register' />*/}
            {/*<Route element={<Login/>} path='/login' />*/}
            <Route path='*' element={<div>Not found</div>} />
        </Routes>
    </BrowserRouter>
}
export default Router;