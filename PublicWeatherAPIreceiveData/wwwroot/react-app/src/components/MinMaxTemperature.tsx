import { useEffect, useState } from "react";
import axios from "axios";

interface IMinMaxTemperature {
  country: string;
  city: string;
  min: number;
  max: number;
}

const MinMaxTemperature = () => {
  const [data, setData] = useState<IMinMaxTemperature[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios("/weather/min-max-temperatures");
      setData(result.data);
    };
    fetchData();
  }, []);

  return (
    <>
      <table>
        <thead>
          <tr>
            <th>Country</th>
            <th>City</th>
            <th>
              <b>Min</b> Temperature
            </th>
            <th>
              <b>Max</b> Temperature
            </th>
          </tr>
        </thead>
        <tbody>
          {data.map((dataLocation, i) => {
            return (
              <tr key={i}>
                <td>{dataLocation?.country}</td>
                <td>{dataLocation?.city}</td>
                <td>{dataLocation?.min}</td>
                <td>{dataLocation?.max}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </>
  );
};

export default MinMaxTemperature;
