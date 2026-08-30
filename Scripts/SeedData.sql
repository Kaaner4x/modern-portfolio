-- Clear existing table records
TRUNCATE TABLE Contacts, Testimonials, Projects, Skills, About RESTART IDENTITY;

-- 1) About Profile (Fictional Mock Data)
INSERT INTO About(Title, Description, ImageUrl, Age, LinkedInUrl, GithubUrl, Email, PhoneNumber, City, CreatedAt)
VALUES (
    'Senior Full Stack .NET Developer',
    'Passionate about designing and building scalable backend systems, high-performance APIs, and modern web applications.',
    'ui/img/profile-img.jpg',
    28,
    'https://linkedin.com/in/example-developer',
    'https://github.com/example-developer',
    'developer@example.com',
    '+1 555 019 2834',
    'San Francisco, CA',
    CURRENT_TIMESTAMP
);

-- 2) Skills
INSERT INTO Skills(Name, Percentage, DisplayOrder, CreatedAt)
VALUES
    ('C# & .NET Core / .NET 10', 95, 1, CURRENT_TIMESTAMP),
    ('ASP.NET Core MVC & Web API', 90, 2, CURRENT_TIMESTAMP),
    ('PostgreSQL & Dapper / EF Core', 85, 3, CURRENT_TIMESTAMP),
    ('Clean Architecture & Design Patterns', 85, 4, CURRENT_TIMESTAMP),
    ('Docker & Containerization', 80, 5, CURRENT_TIMESTAMP),
    ('React.js & TypeScript', 75, 6, CURRENT_TIMESTAMP),
    ('HTML5, CSS3 & Bootstrap 5', 90, 7, CURRENT_TIMESTAMP),
    ('Git & CI/CD Pipelines', 85, 8, CURRENT_TIMESTAMP);

-- 3) Projects (Fictional Mock Projects)
INSERT INTO Projects(Title, Description, ImageUrl, ProjectUrl, GithubUrl, IsActive, CreatedAt)
VALUES
    (
        'Apex E-Commerce Platform',
        'A high-throughput e-commerce engine built with ASP.NET Core and PostgreSQL, featuring product catalog, shopping cart, and Stripe payment processing.',
        'ui/img/masonry-portfolio/masonry-portfolio-1.jpg',
        'https://ecommerce.example.com',
        'https://github.com/example/ecommerce-core',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Nova Portfolio & CV Platform',
        'A responsive developer portfolio management platform built with ASP.NET Core MVC, Dapper ORM, and modern UI components.',
        'ui/img/masonry-portfolio/masonry-portfolio-2.jpg',
        'https://portfolio.example.com',
        'https://github.com/example/modern-portfolio',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'TaskFlow - Agile Project Management',
        'Real-time team collaboration platform with interactive Kanban boards, role-based access control, and automated task notifications.',
        'ui/img/masonry-portfolio/masonry-portfolio-3.jpg',
        'https://taskflow.example.com',
        'https://github.com/example/taskflow-api',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'FinPulse - Financial Analytics Dashboard',
        'Comprehensive wealth and expense tracking application with interactive data visualizations and predictive budgeting algorithms.',
        'ui/img/masonry-portfolio/masonry-portfolio-4.jpg',
        'https://finpulse.example.com',
        'https://github.com/example/finance-tracker',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'DocuCraft - Headless CMS & Blog Engine',
        'Lightweight, SEO-optimized content delivery platform powered by Markdown parsing and high-performance RESTful endpoints.',
        'ui/img/masonry-portfolio/masonry-portfolio-5.jpg',
        'https://docucraft.example.com',
        'https://github.com/example/dev-cms',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'DineFlow - Restaurant & Reservation System',
        'End-to-end table management system with instant online booking, guest analytics, and dynamic digital QR menu integration.',
        'ui/img/masonry-portfolio/masonry-portfolio-6.jpg',
        'https://dineflow.example.com',
        'https://github.com/example/dineflow-app',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'SkyCast - Global Weather Intelligence',
        'Live meteorological tracker integrating OpenWeather API to deliver real-time radar mapping and 7-day hyper-local forecasts.',
        'ui/img/masonry-portfolio/masonry-portfolio-7.jpg',
        'https://skycast.example.com',
        'https://github.com/example/weather-radar',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'AuthGate - Centralized Identity Service',
        'Microservice-ready authentication and authorization server featuring JWT bearer tokens, refresh rotation, and multi-tenant RBAC.',
        'ui/img/masonry-portfolio/masonry-portfolio-8.jpg',
        'https://authgate.example.com',
        'https://github.com/example/identity-microservice',
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Legacy Prototype (Archived)',
        'An early architectural proof-of-concept retained for experimental benchmarking and historical reference.',
        'ui/img/masonry-portfolio/masonry-portfolio-9.jpg',
        'https://archive.example.com',
        'https://github.com/example/archive-demo',
        FALSE,
        CURRENT_TIMESTAMP
    );

-- 4) Testimonials (Fictional Personas)
INSERT INTO Testimonials(ClientName, ClientPosition, Comment, ClientImageUrl, Rating, IsActive, CreatedAt)
VALUES
    (
        'Ethan Jenkins',
        'Product Lead @ Nexus Cloud',
        'Exceptional engineering quality and attention to detail. The backend architecture delivered exceeded our scalability benchmarks.',
        'ui/img/testimonials/testimonials-1.jpg',
        5,
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Sophia Chen',
        'VP of Engineering @ Apex Solutions',
        'The RESTful API services built performed flawlessly under heavy traffic. Outstanding PostgreSQL optimization and clean architecture.',
        'ui/img/testimonials/testimonials-2.jpg',
        5,
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Emily Watson',
        'Scrum Master @ SoftCraft',
        'A dependable engineer with remarkable problem-solving abilities and seamless communication. Delivered every sprint goal ahead of schedule.',
        'ui/img/testimonials/testimonials-3.jpg',
        4,
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Marcus Brody',
        'Co-Founder @ StartupLab',
        'Transformed our MVP roadmap into a robust production release with zero downtime. Highly recommended for any complex .NET project.',
        'ui/img/testimonials/testimonials-4.jpg',
        4,
        TRUE,
        CURRENT_TIMESTAMP
    ),
    (
        'Lucas Vance',
        'Principal Architect @ CloudScale',
        'Deep technical expertise in modern .NET and high-performance database patterns. Truly an invaluable asset to our tech team.',
        'ui/img/testimonials/testimonials-5.jpg',
        5,
        TRUE,
        CURRENT_TIMESTAMP
    );

-- 5) Inbox Messages (Fictional Contacts)
INSERT INTO Contacts(Name, Email, Subject, Message, IsRead, CreatedAt)
VALUES
    (
        'Jonathan Reed',
        'j.reed@vanguardtech.io',
        'Consulting Inquiry: Enterprise B2B Platform',
        'Hello, we are evaluating technical partners to architect our upcoming B2B commerce platform and would love to schedule a brief discovery call.',
        FALSE,
        CURRENT_TIMESTAMP
    ),
    (
        'Claire Sterling',
        'c.sterling@innovatedigital.com',
        'Career Opportunity: Senior .NET Lead',
        'Hi! We came across your portfolio and were very impressed with your architecture design. We would love to discuss a full-stack role on our core team.',
        TRUE,
        CURRENT_TIMESTAMP
    );

