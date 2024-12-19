import RegisterForm from "../../../components/RegisterForm/RegisterForm"
import {useState} from "react"
import { useDispatch } from "react-redux"
import { setUser } from "../../../store/slices/userSlice"
import { useNavigate } from "react-router-dom"

function RegisterLessee() {
    const [error, setError] = useState('')
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const handleClick = async(login, email, password, repassword) => {
        if(password != repassword){
            setError("Passwords do not match")
        }
        try{
            const res = await fetch("http://127.0.0.1:29180/api/Lessee", {
                method: "PUT",
                headers:{
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                credentials: 'include',
                body: JSON.stringify({
                    login: login,
                    email: email,
                    hashedPassword: password
                })
            })

            let user = await res.json()
            dispatch(setUser({
                id: user.id,
                name: user.name,
                role: user.role
            }))
            navigate(0)
            navigate("/")
        }
        catch(error)
        {
            console.log(error)
        }

    }

    return (
        <RegisterForm title={"Register"} handleClick={handleClick} error = {error}/>
    )
}
export default RegisterLessee