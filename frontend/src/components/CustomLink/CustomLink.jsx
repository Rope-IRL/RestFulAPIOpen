import { Link, useMatch } from "react-router-dom"

function CustomLink({children, to, ...props}){
    const match = useMatch({
      path: to,
      end: to.length === 1,
    })
  return (
    // Make styles especially for this custom links in css modules
    <Link to = {to} {...props} className = { 
      match ? styles["header-information-links-link-active"] : styles["header-information-links-link"]
      }>
        {children}
    </Link>
  )
}
 
export default CustomLink