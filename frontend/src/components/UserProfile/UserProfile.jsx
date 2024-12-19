import styles from "./UserProfile.module.css";

function UserProfile({ user }) {
  return (
    <div className={styles["user-container-wrapper"]}>
      <div className={styles["section-header"]}>Your main information</div>
      <div className={`${styles["user-container-wrapper-cred"]}`}>
        <div className={styles["user-container-wrapper-bio-info"]}>
          <div className={styles["section-name"]}>Name</div>
          <div>{user.name}</div>
        </div>
        <div className={styles["user-container-wrapper-bio-info"]}>
          <div className={styles["section-name"]}>Surname</div>
          <div>{user.surname}</div>
        </div>
      </div>
      <div className={styles["user-container-wrapper-bio"]}>
        <div className={styles["user-container-wrapper-bio-info"]}>
          <div className={styles["section-name"]}>Telephone</div>
          <div>{user.telephone}</div>
        </div>
        <div className={styles["user-container-wrapper-bio-info"]}>
          <div className={styles["section-name"]}>Passport</div>
          <div>{user.passportId}</div>
        </div>
        <div className={styles["user-container-wrapper-bio-info"]}>
          <div className={styles["section-name"]}>Birthday</div>
          <div>{user.birthDate}</div>
        </div>
      </div>
    </div>
  );
}

export default UserProfile;
