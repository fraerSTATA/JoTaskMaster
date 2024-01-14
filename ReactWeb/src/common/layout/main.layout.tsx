import {Outlet} from "react-router-dom";
import {MainNav} from "./main.nav.tsx";


export const MainLayout = () => {
    return (
       <>
           <MainNav />
           <div className="container-fluid">
           <Outlet />
           </div>
       </>
    );
};