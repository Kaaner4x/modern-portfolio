<p align="center">
  <a href="https://github.com/Kaaner4x/modern-portfolio">
    <img src="https://raw.githubusercontent.com/Kaaner4x/modern-portfolio/main/wwwroot/ui/favicon.png" alt="Modern Portfolio Logo" width="80" height="80" onerror="this.style.display='none'"/>
  </a>
</p>

<h1 align="center">ModernPortfolio</h1>

<p align="center">
  <strong>Enterprise-Grade Dynamic Portfolio & Content Management System (CMS)</strong><br>
  <em>Engineered with .NET 10 (C# 14), Dapper Micro-ORM, PostgreSQL 16, and Docker Containerization.</em>
</p>

<p align="center">
  <a href="https://dotnet.microsoft.com/download/dotnet/10.0">
    <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet&logoColor=white" alt=".NET 10" />
  </a>
  <a href="https://www.postgresql.org/">
    <img src="https://img.shields.io/badge/PostgreSQL-16-4169E1?style=flat&logo=postgresql&logoColor=white" alt="PostgreSQL 16" />
  </a>
  <a href="https://github.com/DapperLib/Dapper">
    <img src="https://img.shields.io/badge/Micro--ORM-Dapper_2.1-FF6F00?style=flat&logo=nuget&logoColor=white" alt="Dapper" />
  </a>
  <a href="https://www.docker.com/">
    <img src="https://img.shields.io/badge/Docker-Ready-2496ED?style=flat&logo=docker&logoColor=white" alt="Docker" />
  </a>
  <a href="https://github.com/Kaaner4x/modern-portfolio/blob/main/LICENSE.txt">
    <img src="https://img.shields.io/badge/License-MIT-green.svg?style=flat" alt="License MIT" />
  </a>
</p>

<p align="center">
  <a href="#-project-overview">Overview</a> •
  <a href="#-application-showcase">Showcase</a> •
  <a href="#-key-features">Features</a> •
  <a href="#-system-architecture">Architecture</a> •
  <a href="#-database-design--schema">Database</a> •
  <a href="#-quick-start--installation-guide">Installation</a> •
  <a href="#-configuration--environment-variables">Configuration</a> •
  <a href="#-docker-deployment">Docker</a> •
  <a href="#-security-architecture">Security</a> •
  <a href="#-project-structure">Structure</a> •
  <a href="#-contributing">Contributing</a> •
  <a href="#-license">License</a>
</p>

---

## 📌 Project Overview

**ModernPortfolio** is a high-performance, full-stack enterprise web application and dynamic Content Management System (CMS) built with **ASP.NET Core (.NET 10)**. Architected for speed, resilience, and maintainability, it leverages **Dapper Micro-ORM** and native **PostgreSQL** connection pooling to deliver sub-millisecond query execution without the heavy overhead of traditional ORMs.

The platform provides a responsive, modern public-facing portfolio alongside a secured administrative control console (`/Admin`). Key capabilities include automated database provisioning and seed data initialization, cookie-based authentication with ClaimsPrincipal, BCrypt cryptographic password hashing, defensive file upload pipelines, and multi-stage Docker containerization.

---

## 📸 Application Showcase

Explore the visual tour of the **Public Showcase Portal** and the **Admin Control Console (CMS)**.

### 🌐 1. Public Showcase Portal

<table align="center" width="100%">
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/01_home_hero.png" alt="Home Landing Hero" width="100%"/>
      <br><strong>Landing Page & Hero Section</strong><br>
      <em>Dynamic corporate headline, call-to-action triggers, and responsive navigation bar.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/02_home_testimonials.png" alt="Client Testimonials Slider" width="100%"/>
      <br><strong>Client Endorsements & Reviews Slider</strong><br>
      <em>Interactive touch-enabled carousel displaying verified client reviews and ratings.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/03_about_us.png" alt="About Us Corporate Profile" width="100%"/>
      <br><strong>About Us & Corporate Profile</strong><br>
      <em>Company background, years of industry experience, direct contact channels, and social links.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/04_skills_competencies.png" alt="Technology Stack & Competencies" width="100%"/>
      <br><strong>Technology Stack & Competencies Matrix</strong><br>
      <em>Dynamic proficiency progress bars driven directly by database values.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/05_solutions_gallery.png" alt="Enterprise Solutions Gallery" width="100%"/>
      <br><strong>Enterprise Solutions & Project Portfolio</strong><br>
      <em>Filterable project gallery with image previews, case study links, and GitHub shortcuts.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/06_solution_details.png" alt="Solution Case Study Details" width="100%"/>
      <br><strong>Solution Case Study & Architecture Details</strong><br>
      <em>In-depth project breakdown, system architecture overview, live demo, and source repository.</em>
    </td>
  </tr>
</table>

---

### 🛡️ 2. Administrative Control Console (CMS)

<table align="center" width="100%">
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/07_admin_login.png" alt="Admin Authentication Gateway" width="100%"/>
      <br><strong>Admin Authentication Gateway</strong><br>
      <em>Secure cookie-based authentication with ClaimsPrincipal and Remember-Me persistence.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/08_admin_dashboard.png" alt="Admin Executive Dashboard" width="100%"/>
      <br><strong>Executive Management Dashboard</strong><br>
      <em>Centralized control center with live site shortcut and quick-action module cards.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/09_admin_inquiries.png" alt="Client Inquiries Inbox" width="100%"/>
      <br><strong>Client Inquiries & Message Center</strong><br>
      <em>Lead tracking inbox with status indicators (New / Read), counters, and quick actions.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/10_admin_inquiry_modal.png" alt="Inquiry Detail Modal & Email Action" width="100%"/>
      <br><strong>Inquiry Message Detail & Action Modal</strong><br>
      <em>Instant message inspection, one-click email reply shortcut, and mark-as-read toggle.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/11_admin_company_profile.png" alt="Company Profile Management" width="100%"/>
      <br><strong>Company Profile & Bio Management</strong><br>
      <em>Real-time editor for corporate headline, mission statement, contact details, and branding image.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/12_admin_tech_stack.png" alt="Tech Stack Capabilities Manager" width="100%"/>
      <br><strong>Tech Stack & Competency Console</strong><br>
      <em>Proficiency percentage management, display sequence ordering, and CRUD controls.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/13_admin_edit_skill.png" alt="Edit Technology Competency" width="100%"/>
      <br><strong>Competency & Proficiency Slider Editor</strong><br>
      <em>Interactive slider control to configure proficiency levels from foundation to industry mastery.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/14_admin_solutions_management.png" alt="Solutions Portfolio Management" width="100%"/>
      <br><strong>Solutions Portfolio Management</strong><br>
      <em>Comprehensive project listing, publication status badges, and direct edit/delete tools.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="docs/screenshots/15_admin_edit_solution.png" alt="Edit Solution & Media Upload" width="100%"/>
      <br><strong>Solution Editor & Media Upload Engine</strong><br>
      <em>Manage case studies, GitHub repositories, live demo URLs, and cover image uploads.</em>
    </td>
    <td width="50%" align="center">
      <img src="docs/screenshots/16_admin_client_reviews.png" alt="Client Review Moderation" width="100%"/>
      <br><strong>Client Review Moderation & Live Approval</strong><br>
      <em>One-click endorsement approval/suspension, 1-5 star ratings, and client photo management.</em>
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="docs/screenshots/17_admin_security_settings.png" alt="Portal Security & BCrypt Password Management" width="70%"/>
      <br><strong>Portal Security & BCrypt Password Center</strong><br>
      <em>Admin username updates and cryptographic password changes secured with BCrypt.Net.</em>
    </td>
  </tr>
</table>

---

## ✨ Key Features

### 🌐 1. Public Showcase & Client Portal
- **Modern Responsive Design**: Engineered with Bootstrap 5, AOS scroll animations, Swiper sliders, and GLightbox image modals.
- **Company & Professional Profile**: Dynamic bio, years of industry experience, verified contact channels, and social links.
- **Dynamic Tech Stack Matrix**: Interactive competency bars with real-time percentage indicators and custom display ordering.
- **Solutions & Case Study Portfolio**: Filterable project gallery with dedicated case study detail pages, live demo triggers, and source repository buttons.
- **Client Endorsements Carousel**: Testimonials slider displaying verified client endorsements, star ratings, and company positions.
- **Direct Lead Intake**: Contact form with server-side model validation, user feedback alerts, and persistence to PostgreSQL.

### 🛡️ 2. Administrative Control Console (`/Admin`)
- **Secured Area Architecture**: Protected by ASP.NET Core Cookie Authentication (`[Area("Admin")]`, `[Authorize]`) and anti-forgery tokens (`[AutoValidateAntiforgeryToken]`).
- **Executive Dashboard**: High-level metrics, system statistics, and instant shortcuts to manage each application module.
- **Projects & Solutions Management**: Complete CRUD operations with image file upload validation, GitHub/live demo links, and active/inactive visibility toggles.
- **Technical Skills Management**: Create, update, re-order, and delete technical skills and proficiency percentages.
- **Testimonial Moderation Engine**: Approve, suspend, edit, or remove client reviews and ratings.
- **Inquiry & Lead Center**: Review incoming contact messages, toggle read/unread status, and perform message deletions.
- **Security & Profile Center**: Update administrator username and securely change passwords with salted BCrypt hashing.

### ⚙️ 3. Engineering & Architectural Highlights
- **Self-Healing Database Provisioning**: Automated database table creation (`CREATE TABLE IF NOT EXISTS`) and initial seed data insertion on startup.
- **Dynamic Cloud Connection Resolver**: Built-in parser for cloud-managed 12-factor `DATABASE_URL` strings (e.g., Render, Railway, Supabase, Neon).
- **Defensive File Handling Pipeline**: Secure image upload validation with MIME type whitelist, extension checks, 5MB file size limit, GUID file renaming, and path traversal guards.
- **Micro-ORM Performance**: Lightweight, high-throughput SQL operations via Dapper and Npgsql connection pooling.

---

## 🏛 System Architecture

ModernPortfolio follows an **N-Tier Clean Architecture** emphasizing Separation of Concerns (SoC), Inversion of Control (IoC), and Loose Coupling:

```mermaid
graph TD
    subgraph ClientLayer [Client Layer]
        Browser["Client Web Browser / Mobile Device"]
    end

    subgraph PresentationLayer ["ASP.NET Core MVC .NET 10"]
        Controllers["Public & Admin Controllers"]
        ViewModels["Strongly Typed ViewModels"]
        Views["Razor Views & Partial Templates"]
        Auth["Cookie Authentication & Anti-CSRF"]
    end

    subgraph BusinessLogicLayer [Services]
        ProjService["Project Service"]
        SkillService["Skill Service"]
        AboutService["About Service"]
        TestimonialService["Testimonial Service"]
        ContactService["Contact Service"]
        UserService["User & Security Service"]
        ImageService["Image Storage Service"]
        DbInitService["DB Initializer & Seeder"]
    end

    subgraph DataAccessLayer [Repositories]
        GenericRepo["GenericRepository<T>"]
        SpecializedRepos["Project, Skill, User, Contact Repositories"]
        Dapper["Dapper Micro-ORM Engine"]
    end

    subgraph InfrastructureLayer ["Infrastructure & Persistence Layer"]
        Npgsql["Npgsql ADO.NET Provider"]
        PostgreSQL[("PostgreSQL 16 Database")]
        FileSystem["Local / Container Storage wwwroot"]
    end

    Browser <-->|HTTP / HTTPS| PresentationLayer
    Controllers --> ViewModels
    Controllers --> Views
    Controllers --> BusinessLogicLayer
    BusinessLogicLayer --> DataAccessLayer
    DataAccessLayer --> Dapper
    Dapper --> Npgsql
    Npgsql <-->|TCP / Connection Pool| PostgreSQL
    ImageService <-->|I/O Operations| FileSystem
```

### Architectural Design Patterns

| Pattern / Principle | Implementation Details |
| :--- | :--- |
| **Generic Repository Pattern** | `IGenericRepository<T>` & `GenericRepository<T>` provide generic async CRUD operations (`CreateAsync`, `GetByIdAsync`, `GetAllAsync`, `UpdateAsync`, `DeleteAsync`) via Reflection and Dapper parameterization. |
| **Dependency Injection (IoC)** | All services and repositories are registered with `Scoped` lifetime in `Program.cs`, promoting high testability and clean lifecycle management. |
| **MVVM / ViewModel Separation** | Razor views bind strictly to dedicated ViewModels (e.g., `ProjectCreateViewModel`, `AboutEditViewModel`), preventing over-posting attacks and separating domain entities from presentation. |
| **Cookie-Based Claims Auth** | Uses `CookieAuthenticationDefaults` with secure cookie flags (`HttpOnly`, `SameAsRequest`, `ExpireTimeSpan`) and ClaimsPrincipal identity management. |
| **Defensive File Handling** | `ImageService` enforces white-listed MIME types, extension checking, unique GUID file naming, and directory traversal guard checks (`StartsWith(uploadsFolder)`). |
| **Asynchronous I/O Pipeline** | Non-blocking execution across all controller actions, services, and Dapper queries utilizing `async` / `await` and `Task<T>`. |

---

## 🗄 Database Design & Schema

ModernPortfolio runs on **PostgreSQL 16**. The schema is managed dynamically on startup by `DatabaseInitializerService`, ensuring automatic creation of all tables and seed data without requiring manual SQL script executions.

```mermaid
erDiagram
    USERS {
        int Id PK "SERIAL"
        string UserName "VARCHAR(50) UNIQUE"
        string PasswordHash "VARCHAR(255)"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
        timestamp UpdatedAt "NULLABLE"
    }

    ABOUT {
        int Id PK "SERIAL"
        string Title "VARCHAR(200)"
        text Description "TEXT"
        string ImageUrl "VARCHAR(500)"
        int Age "INTEGER"
        string City "VARCHAR(150)"
        string Email "VARCHAR(255)"
        string PhoneNumber "VARCHAR(50)"
        string GithubUrl "VARCHAR(300)"
        string LinkedInUrl "VARCHAR(300)"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
        timestamp UpdatedAt "NULLABLE"
    }

    SKILLS {
        int Id PK "SERIAL"
        string Name "VARCHAR(100)"
        int Percentage "CHECK 0-100"
        int DisplayOrder "DEFAULT 0"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
    }

    PROJECTS {
        int Id PK "SERIAL"
        string Title "VARCHAR(200)"
        text Description "TEXT"
        string ImageUrl "VARCHAR(500)"
        string ProjectUrl "VARCHAR(500)"
        string GithubUrl "VARCHAR(500)"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
        boolean IsActive "DEFAULT TRUE"
    }

    TESTIMONIALS {
        int Id PK "SERIAL"
        string ClientName "VARCHAR(100)"
        string ClientPosition "VARCHAR(100)"
        text Comment "TEXT"
        string ClientImageUrl "VARCHAR(500)"
        int Rating "CHECK 1-5"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
        boolean IsActive "DEFAULT TRUE"
    }

    CONTACTS {
        int Id PK "SERIAL"
        string Name "VARCHAR(100)"
        string Email "VARCHAR(255)"
        string Subject "VARCHAR(200)"
        text Message "TEXT"
        timestamp CreatedAt "DEFAULT CURRENT_TIMESTAMP"
        boolean IsRead "DEFAULT FALSE"
    }
```

---

## 🚀 Quick Start & Installation Guide

Get **ModernPortfolio** running locally on your machine in just a few minutes.

### Prerequisites
- [Git](https://git-scm.com/) installed
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) *(for local development)*
- [Docker & Docker Compose](https://www.docker.com/products/docker-desktop/) *(recommended for instant setup)*
- [PostgreSQL 16+](https://www.postgresql.org/download/) *(if not using Docker)*

---

### Option A: One-Command Setup with Docker Compose (Recommended)

Docker Compose starts both the PostgreSQL database container and the .NET 10 web application container simultaneously.

```bash
# 1. Clone the repository
git clone https://github.com/Kaaner4x/modern-portfolio.git
cd modern-portfolio

# 2. Build images and start containers in detached mode
docker compose up --build -d

# 3. View live application logs (optional)
docker compose logs -f app
```

Once running, access the application:
- 🌐 **Public Website**: [http://localhost:8080](http://localhost:8080)
- 🔐 **Admin Console**: [http://localhost:8080/Admin](http://localhost:8080/Admin)
- 🗄️ **PostgreSQL Database Port**: `localhost:5430`

To stop the containers:
```bash
docker compose down
```

---

### Option B: Local Setup with .NET 10 CLI & PostgreSQL

If you prefer to run the application directly on your host machine:

#### 1. Clone the Repository
```bash
git clone https://github.com/Kaaner4x/modern-portfolio.git
cd modern-portfolio
```

#### 2. Configure Database Connection
Open `appsettings.json` (or create `appsettings.Development.json`) and configure your local PostgreSQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost; Port=5432; Database=modernportfolio; Username=postgres; Password=your_secure_password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> **Note**: You do **not** need to manually run any migration scripts or execute SQL files. The application's `DatabaseInitializerService` automatically creates all required tables and seeds default portfolio data on first run.

#### 3. Restore Dependencies & Run
```bash
# Restore NuGet packages
dotnet restore

# Build the project
dotnet build

# Launch the application
dotnet run
```

Open your browser and navigate to:
- `http://localhost:5000` or `https://localhost:5001`

---

## 🔑 Default Administrator Credentials

On initial database initialization, a default administrator account is automatically provisioned:

| Property | Default Value | Notes |
| :--- | :--- | :--- |
| **Login Gateway** | `/Admin/Account/Login` | Dedicated admin authentication route |
| **Default Username** | `admin` | Initial admin account identifier |
| **Default Password** | `admin123!` | Stored as a salted BCrypt hash |

> ⚠️ **Important Security Notice**: Immediately after your first login, navigate to **Portal Settings (`/Admin/Settings`)** to update your username and change the administrator password.

---

## ⚙️ Configuration & Environment Variables

ModernPortfolio supports multiple methods for supplying configuration parameters and database connection strings.

### 1. Connection String Formats

#### Standard Connection String (`appsettings.json` or Environment Variable)
```
Host=localhost; Port=5432; Database=modernportfolio; Username=your_username; Password=your_password;
```

#### Cloud Database URI Format (`DATABASE_URL`)
ModernPortfolio includes a built-in URI parser for 12-factor cloud platforms (Render, Railway, Supabase, Neon):
```
DATABASE_URL=postgres://your_username:your_password@your_host:5432/your_database
```

When `DATABASE_URL` is detected in the environment, `Program.cs` automatically parses the URI, extracts credentials, and enables SSL connection mode.

### 2. Environment Variable Reference

| Environment Variable | Description | Example / Default |
| :--- | :--- | :--- |
| `ASPNETCORE_ENVIRONMENT` | Application runtime environment | `Development` or `Production` |
| `ASPNETCORE_URLS` | Binding URLs and listening ports | `http://+:8080` or `http://localhost:5000` |
| `ConnectionStrings__DefaultConnection` | Standard PostgreSQL connection string | `Host=postgres;Port=5432;Database=modernportfolio;...` |
| `DATABASE_URL` | Cloud PostgreSQL URI string | `postgres://user:pass@host:5432/db` |

---

## 🐳 Docker Deployment & Multi-Stage Build

The project includes an optimized multi-stage `Dockerfile` to create lightweight, production-ready container images:

```dockerfile
# Stage 1: Build & Publish with .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["ModernPortfolio.csproj", "./"]
RUN dotnet restore "ModernPortfolio.csproj"
COPY . .
RUN dotnet publish "ModernPortfolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Minimal Runtime Image with ASP.NET 10
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
ENTRYPOINT ["dotnet", "ModernPortfolio.dll"]
```

### Docker Compose Architecture
The `docker-compose.yml` configures two isolated services:
1. **`app`**: The .NET 10 web application container running on port `8080`.
2. **`postgres`**: A `postgres:16-alpine` database container with a persistent named volume (`postgres_data`) mapped to external port `5430`.

---

## 🔒 Security Architecture

- **Cryptographic Password Security**: Passwords are never stored in plaintext. They are salted and hashed using work-factor optimized `BCrypt.Net-Next`.
- **Anti-CSRF Protection**: Global `[AutoValidateAntiforgeryToken]` enforcement on `BaseAdminController` prevents Cross-Site Request Forgery attacks.
- **Defensive File Uploads**: `ImageService` verifies allowed extensions (`.jpg`, `.jpeg`, `.png`, `.webp`, `.gif`), checks content MIME types, enforces a 5MB size limit, generates unique GUID filenames, and validates canonical paths (`Path.GetFullPath`) against directory traversal exploits.
- **Hardened Cookie Policy**: Authentication cookies are marked `HttpOnly` with `SameAsRequest` secure policies and strict expiration lifespans.
- **Reverse Proxy Header Forwarding**: Configured with `ForwardedHeadersOptions` for seamless SSL termination and client IP forwarding behind Cloudflare, NGINX, Render, or Railway reverse proxies.

---

## 💻 Technology Stack

### Backend & Core
- **Framework**: [.NET 10.0 (ASP.NET Core MVC)](https://dotnet.microsoft.com/)
- **Language**: [C# 14 / C# 13](https://learn.microsoft.com/en-us/dotnet/csharp/)
- **Micro-ORM**: [Dapper (v2.1.79)](https://github.com/DapperLib/Dapper)
- **Database Driver**: [Npgsql (v10.0.3)](https://www.npgsql.org/)
- **Cryptography**: [BCrypt.Net-Next (v4.2.0)](https://github.com/BcryptNet/bcrypt.net-next)

### Database & DevOps
- **Database Engine**: [PostgreSQL 16-Alpine](https://hub.docker.com/_/postgres)
- **Containerization**: [Docker](https://www.docker.com/) (Multi-stage build)
- **Container Orchestration**: [Docker Compose](https://docs.docker.com/compose/) (v3.8)

### Frontend & UI
- **Styling**: [Bootstrap 5](https://getbootstrap.com/), Modern CSS3
- **Icons**: [Font Awesome 5](https://fontawesome.com/), [Bootstrap Icons](https://icons.getbootstrap.com/)
- **UI Libraries**:
  - [AOS (Animate On Scroll)](https://michalsnik.github.io/aos/) - Scroll animations
  - [Swiper](https://swiperjs.com/) - Testimonials slider
  - [GLightbox](https://biati-digital.github.io/glightbox/) - Lightbox preview modal
  - [Isotope](https://isotope.metafizzy.co/) - Portfolio layout and filtering
  - [PureCounter](https://github.com/srexi/purecounterjs) - Dynamic counter animations
  - [Chart.js](https://www.chartjs.org/) - Dashboard metrics visualization

---

## 📂 Project Structure

```plaintext
modern-portfolio/
│
├── Areas/
│   └── Admin/                         # Admin Control Console (CMS)
│       ├── Controllers/
│       │   ├── AboutController.cs       # Company bio & profile management
│       │   ├── AccountController.cs     # Authentication & login/logout
│       │   ├── BaseAdminController.cs   # Base controller [Area, Authorize, AntiForgery]
│       │   ├── ContactsController.cs    # Inquiry & message center
│       │   ├── DashboardController.cs   # Admin overview dashboard
│       │   ├── ProjectsController.cs    # Solutions & portfolio CRUD
│       │   ├── SettingsController.cs    # Admin credential & security updates
│       │   ├── SkillsController.cs      # Technical competencies CRUD
│       │   └── TestimonialsController.cs# Client review moderation
│       └── Views/                     # Razor views for Admin panel
│
├── Controllers/
│   ├── HomeController.cs              # Public home, about, contact actions
│   └── ProjectController.cs           # Public portfolio & case study details
│
├── docs/                              # Project documentation & visual assets
│   └── screenshots/                   # High-resolution application screenshots
│       ├── 01_home_hero.png
│       ├── 02_home_testimonials.png
│       ├── 03_about_us.png
│       ├── 04_skills_competencies.png
│       ├── 05_solutions_gallery.png
│       ├── 06_solution_details.png
│       ├── 07_admin_login.png
│       ├── 08_admin_dashboard.png
│       ├── 09_admin_inquiries.png
│       ├── 10_admin_inquiry_modal.png
│       ├── 11_admin_company_profile.png
│       ├── 12_admin_tech_stack.png
│       ├── 13_admin_edit_skill.png
│       ├── 14_admin_solutions_management.png
│       ├── 15_admin_edit_solution.png
│       ├── 16_admin_client_reviews.png
│       └── 17_admin_security_settings.png
│
├── Extensions/
│   └── HtmlHelper.cs                  # Custom navigation & active-route helpers
│
├── Models/                            # Domain entity models
│   ├── About.cs
│   ├── Contact.cs
│   ├── Project.cs
│   ├── Skill.cs
│   ├── Testimonial.cs
│   ├── User.cs
│   └── ErrorViewModel.cs
│
├── Repositories/
│   ├── abstract/                      # Data access abstractions
│   │   ├── IGenericRepository.cs
│   │   ├── IProjectRepository.cs
│   │   ├── ISkillRepository.cs
│   │   ├── IAboutRepository.cs
│   │   ├── ITestimonialRepository.cs
│   │   ├── IContactRepository.cs
│   │   └── IUserRepository.cs
│   └── concrete/                      # Dapper implementations
│       ├── GenericRepository.cs
│       ├── ProjectRepository.cs
│       ├── SkillRepository.cs
│       ├── AboutRepository.cs
│       ├── TestimonialRepository.cs
│       ├── ContactRepository.cs
│       └── UserRepository.cs
│
├── Services/
│   ├── abstract/                      # Business logic contracts
│   │   ├── IProjectService.cs
│   │   ├── ISkillService.cs
│   │   ├── IAboutService.cs
│   │   ├── ITestimonialService.cs
│   │   ├── IContactService.cs
│   │   ├── IUserService.cs
│   │   ├── IUserSeedService.cs
│   │   ├── IImageService.cs
│   │   └── IDatabaseInitializerService.cs
│   └── concrete/                      # Service implementations
│       ├── ProjectService.cs
│       ├── SkillService.cs
│       ├── AboutService.cs
│       ├── TestimonialService.cs
│       ├── ContactService.cs
│       ├── UserService.cs
│       ├── UserSeedService.cs
│       ├── ImageService.cs
│       └── DatabaseInitializerService.cs
│
├── ViewModels/                        # Strongly-typed presentation view models
│   ├── AboutViewModel.cs / AboutCreateViewModel.cs / AboutEditViewModel.cs
│   ├── ContactViewModel.cs / ContactListViewModel.cs
│   ├── ProjectViewModel.cs / ProjectCreateViewModel.cs / ProjectEditViewModel.cs
│   ├── SkillViewModel.cs / SkillCreateViewModel.cs / SkillEditViewModel.cs
│   ├── TestimonialViewModel.cs / TestimonialCreateViewModel.cs
│   ├── LoginViewModel.cs
│   └── SettingsViewModel.cs
│
├── Views/                             # Public UI Razor templates
│   ├── Home/                          # Index, About, Contact, Privacy
│   ├── Project/                       # Index (Gallery), Details (Case Study)
│   └── Shared/                        # Public _Layout, partials, imports
│
├── Scripts/                           # SQL utility & manual migration scripts
│   ├── CreateTables.sql
│   ├── CreateUsersTable.sql
│   ├── DropTables.sql
│   ├── MigrateEditedAboutAndAddedFacts.sql
│   └── SeedData.sql
│
├── wwwroot/                           # Static web assets
│   ├── admin/                         # Admin panel CSS, JS, vendor libs
│   └── ui/                            # Public portal styles, JS, images, uploads
│
├── appsettings.json                   # Application configuration & connection string
├── docker-compose.yml                 # Multi-container service definitions
├── Dockerfile                         # Multi-stage production container build
├── ModernPortfolio.csproj             # .NET 10 project definition
├── ModernPortfolio.sln                # Visual Studio solution file
└── Program.cs                         # Application entrypoint & IoC configuration
```

---

## 🗺️ Roadmap & Future Enhancements

- [x] Multi-stage Docker containerization & Docker Compose orchestration
- [x] Auto-provisioning database schema initializer with seed data
- [x] BCrypt secure authentication & portal settings management
- [x] Cloud-native `DATABASE_URL` connection string auto-parser
- [x] Comprehensive visual showcase and screenshot documentation in `docs/`
- [ ] Multi-language support & internationalization (i18n / Localization)
- [ ] Redis Distributed Caching for ultra-high traffic portfolio views
- [ ] Headless RESTful & GraphQL API endpoints for external mobile integration
- [ ] Dark Mode / Light Mode theme toggle switch for the public portal
- [ ] Webhook notifications (Slack / Discord / Email) for new contact inquiries

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository (`https://github.com/Kaaner4x/modern-portfolio/fork`)
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'feat: Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE.txt](LICENSE.txt) file for details.

```
MIT License
Copyright (c) 2026 Kaaner4x
```

<p align="center">
  <sub>Built with modern software engineering practices using <strong>.NET 10</strong>, <strong>Dapper</strong>, and <strong>PostgreSQL</strong>.</sub>
</p>
