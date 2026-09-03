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
  <a href="https://github.com/Kaaner4x/modern-portfolio/actions/workflows/ci.yml">
    <img src="https://github.com/Kaaner4x/modern-portfolio/actions/workflows/ci.yml/badge.svg" alt=".NET CI Build Status" />
  </a>
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
  <a href="#-application-showcase">Showcase</a> •
  <a href="#-key-features">Key Features</a> •
  <a href="#-system-architecture">Architecture</a> •
  <a href="#-technology-stack">Tech Stack</a> •
  <a href="#-database-design--schema">Database Schema</a> •
  <a href="#-getting-started">Getting Started</a> •
  <a href="#-docker-deployment">Docker</a> •
  <a href="#-security--best-practices">Security</a> •
  <a href="#-project-structure">Structure</a> •
  <a href="#-license">License</a>
</p>

---

## 📌 Overview / Genel Bakış

**ModernPortfolio** is a high-performance, full-stack, enterprise-grade web application and Content Management Portal developed using **ASP.NET Core (.NET 10)**. Built upon clean architectural principles and optimized for maximum throughput and sub-millisecond query execution, it replaces heavy ORM abstractions with **Dapper Micro-ORM** and native **PostgreSQL** integration.

The solution features a **public-facing corporate showcase** alongside a **secure administrative control console (CMS)** equipped with cookie-based claims authentication, password hashing with BCrypt, automated database schema provisioning, secure file upload pipelines, and multi-stage containerization.

> **Türkçe Özet**: ModernPortfolio; en güncel **.NET 10**, **Dapper Micro-ORM** ve **PostgreSQL 16** teknolojileri kullanılarak geliştirilmiş, kurumsal düzeyde dinamik bir portföy ve içerik yönetim (CMS) sistemidir. Proje; Generic Repository Deseni, Asenkron Programlama (async/await), Katmanlı Mimari (N-Tier Architecture), BCrypt tabanlı kimlik doğrulama, otomatik veritabanı tabloları oluşturma/tohumlama (Database Initializer & Seed) ve Docker Compose orkestrasyonunu tam uyumlu olarak sunar.

---

## 📸 Application Showcase

Explore the live user experience of both the **Public Showcase Portal** and the **Admin Control Console (CMS)**.

### 🌐 1. Public Showcase Portal

<table align="center" width="100%">
  <tr>
    <td width="50%" align="center">
      <img src="showcase/01_home_hero.png" alt="Home Landing Hero" width="100%"/>
      <br><strong>Landing Page & Hero Section</strong><br>
      <em>Dynamic corporate headline, call-to-action triggers, and responsive navbar.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/02_home_testimonials.png" alt="Client Testimonials Slider" width="100%"/>
      <br><strong>Client Endorsements & Reviews Slider</strong><br>
      <em>Interactive touch-enabled carousel displaying verified partner endorsements.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/03_about_us.png" alt="About Us Corporate Profile" width="100%"/>
      <br><strong>About Us & Corporate Profile</strong><br>
      <em>Comprehensive company vision, years in industry, contact hotlines, and social links.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/04_skills_competencies.png" alt="Technology Stack & Competencies" width="100%"/>
      <br><strong>Technology Stack & Competencies Matrix</strong><br>
      <em>Animated proficiency bars reflecting dynamic backend mastery ratings.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/05_solutions_gallery.png" alt="Enterprise Solutions Gallery" width="100%"/>
      <br><strong>Enterprise Solutions & Project Portfolio</strong><br>
      <em>Filterable solution cards, lightbox previews, and external repository links.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/06_solution_details.png" alt="Solution Case Study Details" width="100%"/>
      <br><strong>Solution Case Study & Architecture Details</strong><br>
      <em>Deep dive into architecture overview, live demo buttons, and source repositories.</em>
    </td>
  </tr>
</table>

---

### 🛡️ 2. Administrative Control Console (CMS)

<table align="center" width="100%">
  <tr>
    <td width="50%" align="center">
      <img src="showcase/07_admin_login.png" alt="Admin Authentication Gateway" width="100%"/>
      <br><strong>Admin Authentication Gateway</strong><br>
      <em>Secure Cookie authentication with ClaimsPrincipal and Remember-Me persistence.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/08_admin_dashboard.png" alt="Admin Executive Dashboard" width="100%"/>
      <br><strong>Executive Management Dashboard</strong><br>
      <em>Centralized hub providing quick metrics and direct actions for all portal modules.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/09_admin_inquiries.png" alt="Client Inquiries Inbox" width="100%"/>
      <br><strong>Client Inquiries & Message Center</strong><br>
      <em>Lead tracking inbox with status badges (New / Read), counters, and quick actions.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/10_admin_inquiry_modal.png" alt="Inquiry Detail Modal & Email Action" width="100%"/>
      <br><strong>Inquiry Message Detail & Action Modal</strong><br>
      <em>Instant message inspection, email reply shortcut, and mark-as-read toggle.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/11_admin_company_profile.png" alt="Company Profile Management" width="100%"/>
      <br><strong>Company Profile & Bio Management</strong><br>
      <em>Update corporate mission, contact info, social accounts, and profile picture upload.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/12_admin_tech_stack.png" alt="Tech Stack Capabilities Manager" width="100%"/>
      <br><strong>Tech Stack & Competency Console</strong><br>
      <em>Real-time proficiency percentages, display sequence ordering, and CRUD controls.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/13_admin_edit_skill.png" alt="Edit Technology Competency" width="100%"/>
      <br><strong>Competency & Proficiency Slider Editor</strong><br>
      <em>Interactive slider control to configure proficiency levels from foundation to mastery.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/14_admin_solutions_management.png" alt="Solutions Portfolio Management" width="100%"/>
      <br><strong>Solutions Portfolio Management</strong><br>
      <em>Comprehensive project list, publication status badges, and direct edit/delete tools.</em>
    </td>
  </tr>
  <tr>
    <td width="50%" align="center">
      <img src="showcase/15_admin_edit_solution.png" alt="Edit Solution & Media Upload" width="100%"/>
      <br><strong>Solution Editor & Media Upload Engine</strong><br>
      <em>Manage case studies, GitHub repositories, live demo URLs, and cover image uploads.</em>
    </td>
    <td width="50%" align="center">
      <img src="showcase/16_admin_client_reviews.png" alt="Client Review Moderation" width="100%"/>
      <br><strong>Client Review Moderation & Live Approval</strong><br>
      <em>One-click endorsement approval/suspension, 1-5 star ratings, and client photo management.</em>
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="showcase/17_admin_security_settings.png" alt="Portal Security & BCrypt Password Management" width="70%"/>
      <br><strong>Portal Security & BCrypt Password Center</strong><br>
      <em>Admin username updates and cryptographic password changes secured with BCrypt.Net.</em>
    </td>
  </tr>
</table>

---

## ✨ Key Features

### 🌐 1. Public Showcase & Client Portal
- **Modern Responsive Landing Experience**: Designed with modern UI/UX principles, animated transitions (AOS), dynamic hero sections, and clean typography.
- **Company & Executive Profile**: Dynamic "About" section featuring company vision, statistics, team insights, contact details, and social links.
- **Tech Stack & Capabilities Matrix**: Interactive skill bars with real-time percentage indicators and custom display ordering.
- **Interactive Solutions / Project Portfolio**: Filterable project gallery with modal previews, detailed case study pages, live demo links, and GitHub repository shortcuts.
- **Client Endorsement Carousel**: Dynamic testimonials slider showcasing verified client reviews, star ratings, and corporate titles.
- **Direct Lead Intake (Contact Form)**: Clean contact form with input validation, flash message feedback, and direct persistence into PostgreSQL.

### 🛡️ 2. Administrative Control Console (`/Admin`)
- **Secured Area Architecture**: Protected via `[Area("Admin")]`, `[Authorize]`, and automated Anti-Forgery Token validation.
- **Dashboard Overview**: Quick access to live site, management metrics, and portal statistics.
- **Solutions & Case Studies Management**: Full CRUD operations for portfolio projects, including image uploads, external demo links, GitHub links, and live visibility toggles.
- **Skill & Competency Management**: Add, update, re-order, and delete technical competencies and mastery percentages.
- **Testimonial Moderation Engine**: Approve, suspend, edit, or remove enterprise client endorsements and star ratings.
- **Inquiry & Lead Center**: Review incoming contact messages, toggle read/unread status, and perform message housekeeping.
- **Company Profile Configuration**: Real-time management of corporate bio, contact emails, social channels, and branded media.
- **Security & Account Center**: Update admin usernames and securely change administrative passwords with BCrypt hash verification.

### ⚙️ 3. Engineering & Architectural Highlights
- **Self-Healing Database Provisioning**: Automatic PostgreSQL table creation (`CREATE TABLE IF NOT EXISTS`) and default seed data initialization on startup.
- **Zero-Downtime Cloud Support**: Dynamic database connection resolution supporting standard connection strings and cloud 12-factor `DATABASE_URL` strings (Render, Railway, Supabase, Neon).
- **Secure File Storage Engine**: Robust file upload handler validating extensions, MIME types, file size boundaries (max 5MB), unique GUID naming, and path traversal security guards.
- **Microsecond Database Execution**: High-throughput raw SQL queries via Dapper and Npgsql connection pooling.

---

## 🏛 System Architecture

The application adopts an **N-Tier Clean Architecture** with strict Separation of Concerns (SoC), Inversion of Control (IoC), and Loose Coupling.

```mermaid
graph TD
    subgraph Client Layer
        Browser[Client Browser / Mobile / Desktop]
    end

    subgraph Presentation Layer [ASP.NET Core MVC .NET 10]
        Controllers[Public & Admin Controllers]
        ViewModels[Strongly Typed ViewModels]
        Views[Razor Views & Partial Views]
        Auth[Cookie Authentication & Anti-CSRF]
    end

    subgraph Business Logic Layer [Services]
        ProjService[Project Service]
        SkillService[Skill Service]
        AboutService[About Service]
        TestimonialService[Testimonial Service]
        ContactService[Contact Service]
        UserService[User & Security Service]
        ImageService[Image Storage Service]
        DbInitService[DB Initializer & Seeder]
    end

    subgraph Data Access Layer [Repositories]
        GenericRepo[GenericRepository&lt;T&gt;]
        SpecializedRepos[Project, Skill, User, Contact Repositories]
        Dapper[Dapper Micro-ORM Engine]
    end

    subgraph Infrastructure & Persistence Layer
        Npgsql[Npgsql ADO.NET Provider]
        PostgreSQL[(PostgreSQL 16 Database)]
        FileSystem[Local / Container Storage wwwroot]
    end

    Browser <-->|HTTP / HTTPS| Presentation Layer
    Controllers --> ViewModels
    Controllers --> Views
    Controllers --> Business Logic Layer
    Business Logic Layer --> Data Access Layer
    Data Access Layer --> Dapper
    Dapper --> Npgsql
    Npgsql <-->|TCP / Connection Pool| PostgreSQL
    ImageService <-->|I/O Operations| FileSystem
```

### Design Patterns & Principles

| Design Pattern / Principle | Implementation Details |
| :--- | :--- |
| **Generic Repository Pattern** | `IGenericRepository<T>` & `GenericRepository<T>` provide generic async CRUD operations (`CreateAsync`, `GetByIdAsync`, `GetAllAsync`, `UpdateAsync`, `DeleteAsync`) via Reflection and Dapper parameterization. |
| **Dependency Injection (IoC)** | All services and repositories are registered with `Scoped` lifetime in `Program.cs`, promoting high testability and clean lifecycle management. |
| **MVVM / ViewModel Separation** | Razor views bind strictly to dedicated ViewModels (e.g., `ProjectCreateViewModel`, `AboutEditViewModel`), preventing over-posting attacks and separating domain entities from presentation. |
| **Cookie-Based Claims Auth** | Uses `CookieAuthenticationDefaults` with secure cookie flags (`HttpOnly`, `SameAsRequest`, `ExpireTimeSpan`) and ClaimsPrincipal identity management. |
| **Defensive File Handling** | `ImageService` enforces white-listed MIME types, extension checking, unique GUID file naming, and directory traversal guard checks (`StartsWith(uploadsFolder)`). |
| **Asynchronous I/O Pipeline** | Non-blocking execution across all controller actions, services, and Dapper queries utilizing `async` / `await` and `Task<T>`. |

---

## 🗄 Database Design & Schema

ModernPortfolio runs on **PostgreSQL 16**. The schema is managed dynamically by the `DatabaseInitializerService` on startup, ensuring the database is always in a ready-to-serve state without manual migration friction.

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

## 💻 Technology Stack

### Backend & Frameworks
- **Framework**: [.NET 10.0 (ASP.NET Core MVC)](https://dotnet.microsoft.com/)
- **Programming Language**: [C# 14 / C# 13](https://learn.microsoft.com/en-us/dotnet/csharp/)
- **Micro-ORM**: [Dapper (v2.1.79)](https://github.com/DapperLib/Dapper)
- **Database Driver**: [Npgsql (v10.0.3)](https://www.npgsql.org/)
- **Security & Cryptography**: [BCrypt.Net-Next (v4.2.0)](https://github.com/BcryptNet/bcrypt.net-next)

### Database & DevOps
- **Database Engine**: [PostgreSQL 16-Alpine](https://hub.docker.com/_/postgres)
- **Containerization**: [Docker](https://www.docker.com/) (Multi-stage build)
- **Container Orchestration**: [Docker Compose](https://docs.docker.com/compose/) (v3.8)
- **Continuous Integration (CI)**: [GitHub Actions](https://github.com/features/actions)

### Frontend & UI
- **Styling & Components**: [Bootstrap 5](https://getbootstrap.com/), Custom Modern CSS3
- **Iconography**: [Font Awesome 5](https://fontawesome.com/), [Bootstrap Icons](https://icons.getbootstrap.com/)
- **Interactive UI Libraries**:
  - [AOS (Animate On Scroll)](https://michalsnik.github.io/aos/) - Fluid scroll animations
  - [Swiper](https://swiperjs.com/) - Touch-enabled testimonial sliders
  - [GLightbox](https://biati-digital.github.io/glightbox/) - Lightbox image preview modal
  - [Isotope](https://isotope.metafizzy.co/) - Portfolio grid layout & filtering
  - [PureCounter](https://github.com/srexi/purecounterjs) - Dynamic counter animations
  - [Chart.js](https://www.chartjs.org/) - Dashboard metrics visualization

---

## 🚀 Getting Started

Follow these instructions to get a local copy of **ModernPortfolio** up and running on your development machine.

### Prerequisites
Ensure you have the following installed:
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL 16+](https://www.postgresql.org/download/) *(or Docker)*
- [Git](https://git-scm.com/)

---

### Option 1: Quick Run with Docker Compose (Recommended)

The easiest way to run ModernPortfolio along with PostgreSQL is using Docker Compose:

```bash
# 1. Clone the repository
git clone https://github.com/Kaaner4x/modern-portfolio.git
cd modern-portfolio

# 2. Build and launch all services in detached mode
docker compose up --build -d

# 3. View running container logs
docker compose logs -f
```

The application will be accessible at:
- 🌐 **Public Website**: [http://localhost:8080](http://localhost:8080)
- 🔐 **Admin Console**: [http://localhost:8080/Admin](http://localhost:8080/Admin)
- 🗄️ **PostgreSQL Port**: `localhost:5430`

---

### Option 2: Local Development Setup

If you wish to develop and run the application natively with the .NET SDK:

#### 1. Clone the Repository
```bash
git clone https://github.com/Kaaner4x/modern-portfolio.git
cd modern-portfolio
```

#### 2. Configure Database Connection
Open `appsettings.json` (or `appsettings.Development.json`) and configure your local PostgreSQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost; Port=5432; Database=modernportfolio; Username=postgres; Password=your_password"
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

> **Note**: You do **not** need to manually run any SQL migration scripts! The built-in `DatabaseInitializerService` automatically creates all tables and seeds initial data upon first launch.

#### 3. Restore & Run Application
```bash
# Restore NuGet dependencies
dotnet restore

# Build the solution
dotnet build

# Launch the development server
dotnet run
```

Navigate to [http://localhost:5000](http://localhost:5000) or [https://localhost:5001](https://localhost:5001) in your browser.

---

## 🔑 Default Administrator Credentials

When the database is initialized for the first time, a default administrator account is seeded automatically:

| Attribute | Default Value | Description |
| :--- | :--- | :--- |
| **Admin Portal URL** | `/Admin/Account/Login` | Dedicated login gateway |
| **Default Username** | `admin` | Initial admin identifier |
| **Default Password** | `admin123!` | Hashed with BCrypt in PostgreSQL |

> ⚠️ **Security Notice**: Immediately log in and change your administrator username and password from the **Portal Settings (`/Admin/Settings`)** menu before deploying to a public server!

---

## 🐳 Docker Deployment & Multi-Stage Build

The project includes an optimized multi-stage `Dockerfile` and a production-ready `docker-compose.yml`:

### Multi-Stage Build Highlights
```dockerfile
# 1. Build Stage with .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["ModernPortfolio.csproj", "./"]
RUN dotnet restore "ModernPortfolio.csproj"
COPY . .
RUN dotnet publish "ModernPortfolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Lightweight Runtime Stage with ASP.NET 10 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
ENTRYPOINT ["dotnet", "ModernPortfolioApp.dll"]
```

### Cloud Database Support (`DATABASE_URL`)
ModernPortfolio natively parses cloud-managed database URI formats (e.g., Render, Railway, Neon, Supabase):
```csharp
// Program.cs automatically parses postgres://user:pass@host:port/dbname
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
```
Simply set the `DATABASE_URL` environment variable on your hosting provider, and the app will configure SSL connections automatically!

---

## 🔒 Security & Best Practices

- **BCrypt Password Hashing**: Passwords are never stored in plaintext. They are salted and hashed using work-factor optimized BCrypt algorithms.
- **CSRF Defense**: Global `[AutoValidateAntiforgeryToken]` attribute configured on `BaseAdminController` blocks Cross-Site Request Forgery attacks.
- **Path Traversal Protection**: `ImageService` verifies canonical paths (`Path.GetFullPath`) against target root directories to prevent file manipulation exploits.
- **Strict File Upload Validation**: Enforces whitelist checks against file extensions (`.jpg`, `.jpeg`, `.png`, `.webp`, `.gif`) and MIME types.
- **Cookie Hardening**: Authentication cookies are marked `HttpOnly` with strict lifetime policies to prevent XSS session theft.
- **Reverse Proxy Header Forwarding**: Includes `ForwardedHeadersOptions` for seamless SSL offloading and client IP tracking behind Cloudflare, NGINX, Render, or Railway reverse proxies.

---

## 📂 Project Structure

```plaintext
modern-portfolio/
│
├── .github/
│   └── workflows/
│       └── ci.yml                     # GitHub Actions CI pipeline
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
├── showcase/                          # High-resolution application screenshots
│   ├── 01_home_hero.png
│   ├── 02_home_testimonials.png
│   ├── 03_about_us.png
│   ├── 04_skills_competencies.png
│   ├── 05_solutions_gallery.png
│   ├── 06_solution_details.png
│   ├── 07_admin_login.png
│   ├── 08_admin_dashboard.png
│   ├── 09_admin_inquiries.png
│   ├── 10_admin_inquiry_modal.png
│   ├── 11_admin_company_profile.png
│   ├── 12_admin_tech_stack.png
│   ├── 13_admin_edit_skill.png
│   ├── 14_admin_solutions_management.png
│   ├── 15_admin_edit_solution.png
│   ├── 16_admin_client_reviews.png
│   └── 17_admin_security_settings.png
│
├── wwwroot/                           # Static web assets
│   ├── admin/                         # Admin panel CSS, JS, vendor libs
│   └── ui/                            # Public portal styles, JS, images, uploads
│
├── appsettings.json                   # Application configuration & connection string
├── docker-compose.yml                 # Multi-container service definitions
├── dockerFile                         # Multi-stage production container build
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
- [x] Comprehensive visual showcase and screenshot documentation
- [ ] Multi-language support & internationalization (i18n / Localization)
- [ ] Redis Distributed Caching for ultra-high traffic portfolio views
- [ ] Headless RESTful & GraphQL API endpoints for external mobile integration
- [ ] Dark Mode / Light Mode theme toggle switch for the public portal
- [ ] Webhook notifications (Slack / Discord / Email) for new contact inquiries

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the Project (`https://github.com/Kaaner4x/modern-portfolio/fork`)
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'feat: Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE.txt](LICENSE.txt) file for details.

```
MIT License
Copyright (c) 2026 Kaaner4x
```

---

## 👨‍💻 Author & Contact

**Kaaner4x**

- 🐙 **GitHub**: [@Kaaner4x](https://github.com/Kaaner4x)
- 💼 **Project Repository**: [modern-portfolio](https://github.com/Kaaner4x/modern-portfolio)

<p align="center">
  <sub>Built with ❤️ using <strong>.NET 10</strong>, <strong>Dapper</strong>, and <strong>PostgreSQL</strong>.</sub>
</p>
