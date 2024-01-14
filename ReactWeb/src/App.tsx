
import './App.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min.js';
import {QueryClient} from "@tanstack/react-query";
import {QueryClientProvider} from "react-query";
import {Route, Routes} from "react-router-dom";
import {MainLayout} from "./common/layout/main.layout.tsx";
import {ProjectPage} from "./pages/project/project.page.tsx";

const queryClient = new QueryClient()
function App() {
  return <>
    <QueryClientProvider client={queryClient}>
      <Routes>
        <Route path="/" element={<MainLayout/>}>
               <Route path="/projects" element={<ProjectPage/>}/>
          
              
        </Route>
      </Routes>
    </QueryClientProvider>
  </>
}

export default App
