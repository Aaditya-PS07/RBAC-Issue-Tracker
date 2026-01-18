import api from "./api";

export default function AdminPanel() {
  const closeIssue = () => {
    api.put("/issues/1", { status: "Closed" });
  };

  return <button onClick={closeIssue}>Close Issue #1</button>;
}
