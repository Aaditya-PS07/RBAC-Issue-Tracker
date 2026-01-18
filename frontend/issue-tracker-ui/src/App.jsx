import { useState } from "react";
import Login from "./login";
import Signup from "./Signup";
import Dashboard from "./Dashboard";
import "./App.css";

export default function App() {
  const [loggedIn, setLoggedIn] = useState(
    !!localStorage.getItem("token")
  );
  const [showSignup, setShowSignup] = useState(false);

  if (loggedIn) {
    return <Dashboard onLogout={() => {
      localStorage.clear();
      setLoggedIn(false);
    }} />;
  }

  return (
    <div className="auth-page">
      {/* LEFT PANEL */}
      <div className="auth-left">
        <h1>Issue Tracker</h1>
        <p>
          A role-based issue tracking system demonstrating
          real-world authentication & authorization.
        </p>

        <ul>
          <li>ASP.NET Core Web API</li>
          <br></br>
          <li>JWT Authentication</li>
          <br></br>
          <li>Role Based Access Control</li>
          <br></br>
          <li>React + Vite</li>
          <br></br>
          <li>SQLite + EF Core</li>
        </ul>
      </div>

      {/* RIGHT PANEL */}
      <div className="auth-right">
        {showSignup ? (
          <Signup onSwitchToLogin={() => setShowSignup(false)} />
        ) : (
          <Login
            onLogin={() => setLoggedIn(true)}
            onSwitchToSignup={() => setShowSignup(true)}
          />
        )}
      </div>
    </div>
  );
}
