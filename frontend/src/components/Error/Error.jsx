import styles from "./Error.module.css";

function Error({ error }) {
  return <div className={styles["error"]}>{error}</div>;
}

export default Error;
