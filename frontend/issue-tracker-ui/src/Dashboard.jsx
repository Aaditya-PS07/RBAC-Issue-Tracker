import Issues from "./Issues";

export default function Dashboard({ onLogout }) {
  const role = localStorage.getItem("role");

  return (
    <div className="dashboard">
      <header>
        <h1>Dashboard</h1>
        <div>
          <span>{role}</span>
          <button onClick={onLogout}>Logout</button>
        </div>
      </header>

      <Issues />
    </div>
  );
}
