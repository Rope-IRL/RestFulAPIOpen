import styles from "./Footer.module.css"

function Footer() {
    return (
        <footer>
            <div className = {styles["footer-text"]}>
                &copy; Rent project foundation
            </div>
        </footer>
    )
}
export default Footer