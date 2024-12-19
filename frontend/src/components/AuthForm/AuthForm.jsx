import {useState} from "react"
import styles from "./AuthForm.module.css"
import {Link} from "react-router-dom"
import Error from "../Error/Error"

function AuthForm({title, handleClick, userRole, error = ""}) {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    return (
        <div className = {styles["form-container"]}>
            <div className = {styles["form-container--header"]}>Login</div>
            <Error error = {error}/>
            <form className = {styles["auth-form"]}>
                <input
                    className = {styles["auth-form__input"]}
                    type="email"
                    value = {email}
                    onChange={(e) => {
                        setEmail(e.target.value)
                    }} 
                    placeholder="Login"
                />
                <input
                    className = {styles["auth-form__input"]} 
                    type="password" 
                    value = {password}
                    onChange={(e) => {
                        setPassword(e.target.value)
                    }}
                    placeholder="Password"
                />
                <button 
                    onClick={ (e) => {
                        e.preventDefault()
                        handleClick(email, password)
                    }}
                    className = {styles["auth-form__login__button"]}
                >
                    {title}
                </button>
            </form>
            <div className={styles["register-container"]}> 
                <Link 
                    to = {`/register/${userRole}`}
                    className={styles["form-container-register"]}
                >
                    Register?
                </Link>
            </div>
        </div>
    )
}
export default AuthForm