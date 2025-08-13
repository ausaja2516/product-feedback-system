import { useEffect,useState } from 'react'
import { getTest } from './api';
import './App.css'

function App() {
  const [data, setData] = useState([]);

  useEffect(() => {
    getTest().then(setData);
  }, []);

  return (
  
      <div className="p-4">
      <h1 className="text-2xl font-bold">Product Feedback System</h1>
       <ul>
        
          {data.map((d) => (
            <li className='flex justify-between items-center p-2 border border-sm rounded-2xl m-2' key={d.date}> 
              <p>{d.date}</p>
              <p>temperatureC: {d.temperatureC}</p>
              <p>temperatureF: {d.temperatureF}</p>
              <p>Summary: {d.summary}</p>
            </li>
          )) && "loading"}
        </ul>
      </div>
  )
}

export default App
