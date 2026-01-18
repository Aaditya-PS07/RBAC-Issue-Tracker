import { useState } from "react";
import api from "./api";

export default function Signup({ onSwitchToLogin }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("User");

  const signup = async () => {
    try {
      await api.post("/auth/register", {
        username,
        password,
        role
      });

      alert("Signup successful. Please login.");
      onSwitchToLogin();
    } catch {
      alert("Signup failed");
    }
  };

  return (
    <div className="auth-card">
      <h2>Sign Up</h2>

      <input
        placeholder="Username"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />

      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <select value={role} onChange={(e) => setRole(e.target.value)}>
        <option value="User">User</option>
        <option value="Admin">Admin</option>
      </select>

      <button onClick={signup}>Create Account</button>

      <p className="switch-text">
        Already have an account?{" "}
        <span onClick={onSwitchToLogin}>Login</span>
      </p>
    </div>
  );
}
