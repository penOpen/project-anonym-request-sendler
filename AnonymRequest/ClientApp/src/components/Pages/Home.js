import HomeBtn from "../Components/Btn/HomeBtn";
import "./Home.css"

function Home() {
  return (
    <div 
      className="content index__content center-items column-items"
    >
      <HomeBtn href='/create' text="Создать жалобу"/>
      <HomeBtn href='/find' text='Найти жалобу'/> 
    </div>
  );
}

export default Home;
