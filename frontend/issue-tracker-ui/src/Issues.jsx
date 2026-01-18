import { useEffect, useState } from "react";
import api from "./api";

export default function Issues() {
  const [issues, setIssues] = useState([]);
  const [title, setTitle] = useState("");
  const role = localStorage.getItem("role");

  const loadIssues = async () => {
    const res = await api.get("/issues");
    setIssues(res.data);
  };

  const createIssue = async () => {
    if (!title.trim()) return;

    await api.post("/issues", { title });
    setTitle("");
    loadIssues();
  };

  const closeIssue = async (id) => {
    await api.put(`/issues/${id}/close`);
    loadIssues();
  };

  useEffect(() => {
    loadIssues();
  }, []);

  return (
    <div className="issues">
      <h2>Issues</h2>

      {/* CREATE ISSUE (ALL USERS) */}
      <div className="issue-create">
        <input
          placeholder="Describe your issue"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
        <button onClick={createIssue}>Submit</button>
      </div>

      {/* ISSUE LIST */}
      {issues.map((i) => (
        <div className="issue-card" key={i.id}>
          <strong>{i.title}</strong>
          <span>{i.isClosed ? "Closed" : "Open"}</span>

          {role === "Admin" && !i.isClosed && (
            <button onClick={() => closeIssue(i.id)}>
              Close Issue
            </button>
          )}
        </div>
      ))}
    </div>
  );
}
