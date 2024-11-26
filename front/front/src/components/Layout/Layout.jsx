import { Suspense } from "react"
import { Outlet } from "react-router-dom"
import Header from "../Header/Header"
import Footer from "../Footer/Footer"
import styles from "./Layout.module.css"

function Layout(){
    return (
        <div className={styles["all-content"]}>
            <Header />
            <main className={styles["main-content"]}>
                <Suspense fallback = {<p>Loading.....</p>}>
                    <Outlet />
                </Suspense>
            </main>
            <Footer />
        </div>
    )
}

export default Layout