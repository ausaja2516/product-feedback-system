import { useState } from "react";
import { API_BASE } from "./api";

export default function FeedbackForm({ onSubmit }) {
  const [form, setForm] = useState({
    productName: "",
    userName: "",
    rating: 5,
    comment: ""
  });

  function handleChange(e) {
    setForm({ ...form, [e.target.name]: e.target.value });
  }

  async function handleSubmit(e) {
    e.preventDefault();
    const res = await fetch(`${API_BASE}/api/feedback`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form)
    });
    if (res.ok) {
      setForm({ productName: "", userName: "", rating: 5, comment: "" });
      onSubmit();
    }
  }

  return (
    <form onSubmit={handleSubmit} className="space-y-4 p-4 border rounded-lg">
      <input name="productName" value={form.productName} onChange={handleChange} placeholder="Product Name" required className="border p-2 w-full" />
      <input name="userName" value={form.userName} onChange={handleChange} placeholder="Your Name (optional)" className="border p-2 w-full" />
      <input type="number" name="rating" value={form.rating} onChange={handleChange} min="1" max="5" className="border p-2 w-full" />
      <textarea name="comment" value={form.comment} onChange={handleChange} placeholder="Your feedback..." required className="border p-2 w-full h-28 resize-none scroll-auto"></textarea>
      <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded cursor-pointer">Submit</button>
    </form>
  );
}