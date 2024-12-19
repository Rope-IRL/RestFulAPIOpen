import { useState } from "react"
import styles from "./RegisterForm.module.css"
import Error from "../Error/Error"

function RegisterForm({title, handleClick, error = ""}){

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [repassword, setRepassword] = useState('')
    const [login, setLogin] = useState('')

    return <div className = {styles["form-container"]}>
        <div className = {styles["form-container--header"]}>Register</div>
        <Error error={error}/>
        <form className = {styles["auth-form"]}>
            <input
                className = {styles["auth-form__input"]}
                type="text"
                value = {login}
                onChange={(e) => {
                    setLogin(e.target.value)
                }} 
                placeholder="Login"
            />
            <input
                className = {styles["auth-form__input"]}
                type="email"
                value = {email}
                onChange={(e) => {
                    setEmail(e.target.value)
                }} 
                placeholder="Email"
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
            <input
                className = {styles["auth-form__input"]} 
                type="password" 
                value = {repassword}
                onChange={(e) => {
                    setRepassword(e.target.value)
                }}
                placeholder="Repeat password"
            />
            <button 
                onClick={ (e) => {
                    e.preventDefault()
                    handleClick(login, email, password, repassword)}}
                className = {styles["auth-form__login__button"]}
            >
                {title}
            </button>
        </form>
    </div>
}

export default RegisterForm