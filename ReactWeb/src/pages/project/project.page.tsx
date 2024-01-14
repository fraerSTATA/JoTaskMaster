import {useQuery} from "react-query";
import {GetAllProjects} from "../../common/services/api/project/project.api.ts";


export const ProjectPage = () => {
    
    const {data}= useQuery(["projects"],GetAllProjects);
    return <div>project.page</div>
       
};