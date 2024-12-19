import styles from "./Main.module.css"
import BigMain from "../../assets/pictures/MainPage1.jpg"
import Main2 from "../../assets/pictures/Main2.jpg"
import Main3 from "../../assets/pictures/Main3.jpg"
import Main4 from "../../assets/pictures/Main4.jpg"
import Main5 from "../../assets/pictures/Hotel1.jpg"

function MainPage() {
    return (
        <div className = {styles["main-page"]}>
            <div className= {styles["main-page-main-picture"]}>
                <div className = {styles["words-container"]}>
                    <div className={styles["words-container-first"]}>
                        Place Everywhere
                    </div>
                    <div className={styles["words-container-last"]} >
                        Rent Everywhere
                    </div>
                </div>
            </div>
            <div className = {styles["main-content"]}>
                <div className = {styles["main-content-best-places"]}>
                    <div className = {styles["main-content-best-places-header"]}>
                        Find the best place, that is right for you
                    </div>
                    <div className = {styles["best-places-wrapper"]}>
                        <div>
                            <img 
                                className = {styles["best-places-container-picture"]}
                                src={Main2} 
                                alt="best place that fits you 1" />
                            <div className={styles["best-place-container-words"]}>
                                <div className={styles["best-place-container-words-header"]}>
                                    The Headlam Apartment
                                </div>
                                <div className = {styles["house-description"]}>
                                    The Headlam Apartment offers accommodations in London, 
                                    1.6 miles from Sky Garden and 1.6 miles from Liverpool Street Tube Station. 
                                    The property is around 1.7 miles from Tower of London, 1.8 miles from Tower Bridge, 
                                    and 1.8 miles from Victoria Park. Free Wifi is available throughout the property and Brick Lane is a 16-minute walk away. 
                                    The apartment consists of 2 bedrooms, a living room, a fully equipped kitchen with an oven and a coffee machine, 
                                    and 1 bathroom with a bath and a hair dryer. Towels and bed linen are provided in the apartment. 
                                    The accommodation is non-smoking. London Bridge is 2.3 miles from the apartment, while St Paul's Cathedral is 2.3 miles away.
                                    The nearest airport is London City Airport, 5.6 miles from The Headlam Apartment.
                                </div>
                            </div>
                        </div>
                        <div>
                            <img 
                                src={Main3} 
                                alt="best place that fits you 1" 
                                className = {styles["best-places-container-picture"]}/>
                            <div className={styles["best-place-container-words"]}>
                                <div className={styles["best-place-container-words-header"]}>
                                    master St. Paul's
                                </div>
                                <div className = {styles["house-description"]}>
                                    Master St. Paul's provides accommodations within 1.5 miles of the center of London, 
                                    with free Wifi and a kitchen with a microwave, a toaster, and a fridge. 
                                    The air-conditioned accommodations are a 3-minute walk from St Paul's Cathedral. 
                                    Guests can access the apartment via private entrance. At the apartment complex, all units have a desk, 
                                    a flat-screen TV, a private bathroom, bed linen, and towels. 
                                    A stovetop and kettle are also featured. 
                                    The rooms are equipped with heating facilities. Guests can stay active with the fitness classes held on site. 
                                    Popular points of interest near the apartment include Sky Garden, Somerset House, and Savoy Theatre. 
                                    London City Airport is 7.5 miles away.
                                </div>
                            </div>
                        </div>
                        <div>
                            <img 
                                src={Main4} 
                                alt="best place that fits you 1" 
                                className = {styles["best-places-container-picture"]}/>
                            <div className={styles["best-place-container-words"]}>
                                <div className={styles["best-place-container-words-header"]}>
                                    Garden Tower House
                                </div>
                                <div className = {styles["house-description"]}>
                                    Garden Tower house offers accommodations in London, a 18-minute walk from Sky Garden and 1.2 miles from Liverpool Street 
                                    Tube Station. 
                                    This apartment offers accommodations with a balcony. Outdoor seating is also available at the apartment.
                                    With free Wifi, this 1-bedroom apartment provides a flat-screen TV, a washing machine, 
                                    and a fully equipped kitchen with a dishwasher and microwave. 
                                    The accommodation is non-smoking. Popular points of interest near Garden Tower flat 
                                    include Tower of London, Tower Bridge, and Brick Lane. 
                                    The nearest airport is London City Airport, 6.2 miles from the accommodation.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MainPage