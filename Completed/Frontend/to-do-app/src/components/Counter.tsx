import { useState } from "react";
import "./Counter.css";

interface CounterProps {
  counterHeader?: string;
}

export const Counter: React.FC<CounterProps> = ({ counterHeader }) => {
  const [count, setCount] = useState<number>(0);

  return (
    <div className="counter-card">
      <h1>{counterHeader}</h1>
      <button
        className="counter-button"
        onClick={() => setCount((prevState) => prevState - 1)}
      >
        DOWN
      </button>
      <p className="counter-text">Count: {count}</p>
      <button
        className="counter-button"
        onClick={() => setCount((prevState) => prevState + 1)}
      >
        UP
      </button>
    </div>
  );
};
