import { useState } from "react";
import api from "./api";

export default function Login({ onLogin, onSwitchToSignup }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const login = async () => {
    try {
      const res = await api.post("/auth/login", {
        username,
        password
      });

      localStorage.setItem("token", res.data.token);
      localStorage.setItem("role", res.data.role);

      onLogin();
    } catch {
      alert("Invalid credentials");
    }
  };

  return (
    <div className="auth-card">
      <h2>Login</h2>

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

      <button onClick={login}>Login</button>

      <p className="switch-text">
        New here? <span onClick={onSwitchToSignup}>Sign up</span>
      </p>
    </div>
  );
}
