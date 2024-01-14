import axios from "axios";


export async function GetAllProjects (){
    return await axios.get("https://localhost:7184/api/Project/Get_All_Projects")
}