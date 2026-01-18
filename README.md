# IssueTracker Pro — Role-Based Issue Management System

IssueTracker Pro is a full-stack web application that demonstrates **real-world backend engineering concepts** such as **JWT authentication**, **role-based access control (RBAC)**, and **secure API design**, paired with a clean React frontend.


## Key Features

### Authentication & Authorization
- JWT-based authentication
- Stateless secure API access
- Role-Based Access Control (RBAC)

### User Capabilities
- Register & login
- Create issues
- View **only their own submitted issues**

### Admin Capabilities
- View **all issues**
- Close / resolve any issue
- Enforced permissions at backend level

### Backend-First Design
- All access rules enforced server-side
- Frontend does NOT control security logic
- Production-style architecture

---

## Tech Stack

### Backend
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **JWT Authentication**
- **Role-Based Authorization**

### Frontend
- **React (Vite)**
- **Axios**
- **CSS (custom styling)**
- **LocalStorage for session persistence**

---

## Architecture Overview

React Client
   ↓ JWT
ASP.NET Core API
   ↓
Authentication Middleware
   ↓
Role-Based Controllers
   ↓
SQLite Database


## Folder Structure

IssueTracker/
├── backend/
│   └── IssueTracker.API/
│       ├── Controllers/
│       ├── Models/
│       ├── Data/
│       ├── Services/
│       └── Program.cs
│
├── frontend/
│   └── src/
│       ├── App.jsx
│       ├── Login.jsx
│       ├── Signup.jsx
│       ├── Dashboard.jsx
│       ├── Issues.jsx
│       ├── api.js
│       ├── App.css
│       └── index.css
│
└── README.md



## How to Run the Project (Step-by-Step)

1.  Prerequisites

   Download the project as .zip

.NET SDK (8+)

Node.js (18+)

npm

2.  Run Backend

cd .\IssueTracker\backend\IssueTracker.API
dotner build
dotnet run

Backend URL:

http://localhost:5247

(Note : If the localhost Port changes, kindly change it in the files )

Swagger:

http://localhost:5247/swagger


3.  Run Frontend

cd .\IssueTracker\frontend\issue-tracker-ui>
npm install
npm run dev

Frontend URL:

(Note : If the localhost Port changes, kindly change it in the files )

http://localhost:5173

## Application Flow (End-to-End)

1. Signup

User registers with:

username

password

role (User / Admin)


2.  Login

Credentials validated by backend

JWT token returned

Token + role stored in localStorage


3. Issue Creation

Logged-in users can submit issues

Issue is automatically linked to creator

4. Issue Visibility

User → sees only their issues

Admin → sees all issues

5. Issue Resolution

Admin can close issues

User cannot close issues

Backend enforces permission


6. Security Implementation Details

JWT contains:

User ID

Username

Role

Role extracted server-side using claims

[Authorize(Roles = "Admin")] used for admin actions

Ownership filtering applied for user issue visibility

🧪 Example Authorization Logic
IF role == Admin
   → return all issues
ELSE
   → return issues created by current user

   
