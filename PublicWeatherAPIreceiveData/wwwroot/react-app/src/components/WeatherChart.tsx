import { useEffect, useState } from "react";
import axios from "axios";
import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const chartJSoptions = {
  responsive: true,
  plugins: {
    legend: {
      position: "top" as const,
    },
    title: {
      display: true,
      text: "Weather Data",
    },
  },
};

interface WeatherData {
  id: number;
  country: string;
  city: string;
  temperature: number;
  lastUpdateTime: string;
}

const WeatherChart = () => {
  const [data, setData] = useState<WeatherData[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios("/weather");
      setData(result.data);
    };
    fetchData();
  }, []);

  const groupedData = data.reduce(
    (acc: { [key: string]: WeatherData[] }, curr) => {
      if (!acc[curr.city]) {
        acc[curr.city] = [];
      }
      acc[curr.city].push(curr);
      return acc;
    },
    {}
  );

  const chartData = {
    labels: Array.from(
      new Set(data.map((d) => new Date(d.lastUpdateTime).toLocaleTimeString()))
    ),
    datasets: Object.keys(groupedData).map((city, index) => {
      const colors = ["blue", "red", "green"]; // Add more colors if needed
      return {
        label: `${groupedData[city][index].country}-${city}`,
        data: groupedData[city].map((d) => d.temperature),
        fill: false,
        backgroundColor: colors[index],
        borderColor: colors[index],
      };
    }),
  };

  return <Line data={chartData} options={chartJSoptions} />;
};

export default WeatherChart;
