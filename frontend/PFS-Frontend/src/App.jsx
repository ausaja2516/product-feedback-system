import { useEffect, useState } from "react";
import FeedbackForm from "./FeedbackForm";
import { API_BASE } from "./api";

function App() {
  const [feedbacks, setFeedbacks] = useState([]);

  const fetchFeedbacks = async () => {
    const res = await fetch(`${API_BASE}/api/feedback`);
    const data = await res.json();
    setFeedbacks(data);
  };

  useEffect(() => {
    fetchFeedbacks();
  }, []);

return (
    <div className="p-4 max-w-2xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">Product Feedback</h1>
      <FeedbackForm onSubmit={fetchFeedbacks} />
      <div className="mt-6">
        {feedbacks.map(f => (
          <div key={f.id} className="p-4 border rounded mb-2">
            <h2 className="font-bold">{f.productName}</h2>
            <p className="text-sm text-gray-600">By {f.userName || "Anonymous"} - {f.rating}⭐</p>
            <p>{f.comment}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App
