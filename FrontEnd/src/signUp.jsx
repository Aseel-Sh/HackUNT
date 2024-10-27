import { useNavigate } from "react-router-dom"

export default function signUp(){
    let navigate = useNavigate();
    const routeChange = () =>{
        let path = '../signIn';
        navigate(path);
    }
    return(
        <div style={{display: 'flex'}}>
            <h1>SignUp</h1>
            <button onClick={routeChange}>back</button>
        </div>
    )
}