import {useState} from "react"
import {useNavigate} from "react-router-dom"
import {useDispatch} from "react-redux"
import AuthForm from "../../../components/AuthForm/AuthForm"
import { setUser } from "../../../store/slices/userSlice"


function LandlordLogin() {
    const navigate = useNavigate()
    const dispatch = useDispatch()
    const [error, setError] = useState("")

    const handleLogin = (email, password) => {
        Login(email, password)
    }

    const Login = async (email, password) => {     
        try{
            const res = await fetch("http://127.0.0.1:29180/api/Landlord/login", {
                method: "POST",
                body: JSON.stringify({
                    login: email,
                    password: password
                }),
                headers:{
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                credentials: 'include'
            })
            let user = await res.json()
            dispatch(setUser({
                id: user.id,
                name: user.name,
                role: user.role
            }))
            navigate("/")
            navigate(0)
        }
        catch(error){
            setError("Wrong email or password")
        }
    }

    return  <AuthForm 
        title="Login"
        error = {error}
        userRole = "landlord"
        handleClick={handleLogin}
    />

    
}
export default LandlordLogin