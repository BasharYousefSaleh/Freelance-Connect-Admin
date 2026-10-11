 تفضل، هذا الكود الكامل جاهز للنسخ واللصق مباشرة في README على GitHub:

---

```markdown
# 🚀 Freelance Connect Platform

A secure full-stack web platform that connects freelancers with project owners — enabling service listing, order management, and secure payments.

![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=flat&logo=dotnet&logoColor=white)

---

## 📌 Overview

**Freelance Connect Platform** is a graduation project that provides a digital ecosystem where freelancers and clients can interact securely. It enables users to create accounts, publish services, submit and receive orders, and complete payments through integrated local and international payment gateways.

The platform is built with a focus on **security**, **scalability**, and **user experience**, following modern software engineering practices such as the MVC pattern, Repository pattern, and Entity Framework ORM.

---

## ✨ Key Features

- 🔐 Secure user authentication and authorization
- 👤 Multi-tier user and admin dashboards
- 📋 Service listing and order management
- 💳 Integration with local and international payment gateways
- 📊 Admin control panel for managing users, services, and orders
- 📱 Fully responsive UI/UX across devices
- 🛡️ Protection against common web vulnerabilities
- 📦 Clean and organized code architecture

---

## 🛠️ Technologies Used

| Layer | Technology |
|-------|------------|
| **Backend** | ASP.NET, C# |
| **ORM** | Entity Framework |
| **Database** | SQL Server |
| **Frontend** | HTML5, CSS3, SCSS, JavaScript |
| **Architecture** | MVC, Repository Pattern |
| **Security** | Authentication, Authorization, Secure Payment Integration |

---

## 🔐 Security Implementation

Security was a core focus throughout the development of this platform. The following measures were implemented to ensure data integrity, user privacy, and protection against common web vulnerabilities:

### 🛡️ Authentication & Authorization
- **Secure Registration:** Passwords are hashed using strong cryptographic algorithms before storage.
- **Role-Based Access Control (RBAC):** Separate roles for Users, Freelancers, and Admins with restricted permissions.
- **Session Management:** Secure session tokens with proper expiration and renewal.
- **Account Verification:** Email and identity verification before account activation.
- **Brute Force Protection:** Account lockout after multiple failed login attempts.

### 🔒 Data Protection
- **SQL Injection Prevention:** All database queries use **Entity Framework ORM** with parameterized queries.
- **XSS Protection:** Input sanitization and output encoding to prevent Cross-Site Scripting attacks.
- **CSRF Protection:** Anti-forgery tokens on all forms and state-changing requests.
- **Encrypted Sensitive Data:** Personal and payment-related data encrypted at rest.
- **Secure Connection Strings:** Connection strings stored securely, never hard-coded.

### 💳 Payment Security
- **PCI-Compliant Gateways:** Integration with trusted local and international payment providers.
- **No Card Data Storage:** Sensitive payment details are never stored on the platform.
- **Secure Payment Flow:** Encrypted communication between the platform and payment gateways.
- **Transaction Logging:** Full audit trail for every payment transaction.
- **Refund & Dispute Handling:** Built-in mechanisms for secure refunds and disputes.

### 🌐 Network & Infrastructure
- **HTTPS Enforcement:** All traffic encrypted using SSL/TLS.
- **Secure Headers:** HTTP security headers (HSTS, X-Frame-Options, CSP).
- **Rate Limiting:** Protection against DDoS and abuse.
- **Logging & Monitoring:** Detailed logs for security events and suspicious activities.

### 🧪 Security Testing
- **Penetration Testing:** Manual testing of authentication, authorization, and payment flows.
- **Vulnerability Scanning:** Regular scans for OWASP Top 10 vulnerabilities.
- **Code Review:** Security-focused review of all critical components.

### 📋 Security Compliance
- Follows **OWASP Top 10** best practices.
- Adheres to **secure coding standards** for ASP.NET applications.
- Implements **least privilege principle** across all system components.
- Ensures **GDPR-inspired** data handling for user privacy.

---

## 🏗️ Architecture

The project follows a **layered architecture**:

```
┌─────────────────────────────────────┐
│      Presentation Layer             │
│      (ASP.NET MVC Views)            │
├─────────────────────────────────────┤
│      Business Logic Layer           │
│      (Services Layer)               │
├─────────────────────────────────────┤
│      Data Access Layer              │
│      (Entity Framework + Repos)     │
├─────────────────────────────────────┤
│      Database Layer                 │
│      (SQL Server)                   │
└─────────────────────────────────────┘
```

---

## 📂 Project Structure

```
Freelance-Connect-Platform/
│
├── src/
│   ├── Data/              # Database context and migrations
│   ├── Hoor.Common/       # Shared utilities and helpers
│   ├── Services/          # Business logic layer
│   ├── Tests/             # Unit tests
│   ├── Web/               # ASP.NET MVC web application
│   ├── Hoor.sln           # Main solution file
│   ├── src.sln            # Source solution file
│   └── Rules.ruleset      # Code analysis rules
│
└── .gitignore
```

---

## 🚀 How to Run

### Prerequisites
- Visual Studio 2022 or later
- .NET Framework / .NET SDK
- SQL Server (LocalDB or full instance)

### Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/BasharYousefSaleh/Freelance-Connect-Platform.git
   ```

2. **Open the solution**
   - Open `src/Hoor.sln` in Visual Studio.

3. **Configure the database**
   - Update the connection string in `Web.config` or `appsettings.json`.
   - Run Entity Framework migrations:
     ```
     Update-Database
     ```

4. **Build and run**
   - Press `F5` in Visual Studio.

---

## 🎓 Academic Context

This project was developed as a **graduation project** for the Bachelor of Science in Information Technology at **Al-Hikma University, Dhamar, Yemen**.

- **Project Grade:** 95% (Excellent)
- **Final Semester GPA:** 93% (Excellent)
- **Duration:** November 2024 – February 2025

---

## 👤 Author

**Bashar Yousef Saleh Al-Kharbi**
- 🎓 B.Sc. in Information Technology — Al-Hikma University (2025)
- 📧 bsharalkhrby92@gmail.com
- 🔗 GitHub: [@BasharYousefSaleh](https://github.com/BasharYousefSaleh)

---

## 📄 License

This project is intended for **academic and personal use**. For commercial use, please contact the author.

---

⭐ If you find this project useful, please consider giving it a star!
