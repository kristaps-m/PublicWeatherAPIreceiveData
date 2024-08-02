import "./App.css";
import MinMaxTemperature from "./components/MinMaxTemperature";
import WeatherChart from "./components/WeatherChart";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Weather Data</h1>
        <MinMaxTemperature />
        <WeatherChart />
      </header>
    </div>
  );
}

export default App;
