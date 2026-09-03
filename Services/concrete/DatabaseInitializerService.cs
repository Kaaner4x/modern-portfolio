using Dapper;
using ModernPortfolio.Services.@abstract;
using Npgsql;

namespace ModernPortfolio.Services.concrete;

public class DatabaseInitializerService : IDatabaseInitializerService
{
    private readonly string _connectionString;
    private readonly IUserSeedService _userSeedService;
    private readonly ILogger<DatabaseInitializerService> _logger;

    public DatabaseInitializerService(
        IConfiguration configuration,
        IUserSeedService userSeedService,
        ILogger<DatabaseInitializerService> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("DefaultConnection string is not configured.");
        _userSeedService = userSeedService ?? throw new ArgumentNullException(nameof(userSeedService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InitializeDatabaseAsync()
    {
        try
        {
            _logger.LogInformation("Initializing Aveny Technologies database schema and seed data...");

            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            var initSql = @"
                -- Users Table
                CREATE TABLE IF NOT EXISTS Users (
                    Id SERIAL PRIMARY KEY,
                    UserName VARCHAR(50) NOT NULL UNIQUE,
                    PasswordHash VARCHAR(255) NOT NULL,
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    UpdatedAt TIMESTAMP
                );

                -- About Table (Company Profile)
                CREATE TABLE IF NOT EXISTS About (
                    Id SERIAL PRIMARY KEY,
                    Title VARCHAR(200) NOT NULL,
                    Description TEXT,
                    ImageUrl VARCHAR(500),
                    Age INTEGER,
                    City VARCHAR(150),
                    Email VARCHAR(255),
                    PhoneNumber VARCHAR(50),
                    GithubUrl VARCHAR(300),
                    LinkedInUrl VARCHAR(300),
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    UpdatedAt TIMESTAMP
                );

                -- Skills Table (Tech Stack & Capabilities)
                CREATE TABLE IF NOT EXISTS Skills (
                    Id SERIAL PRIMARY KEY,
                    Name VARCHAR(100) NOT NULL,
                    Percentage INTEGER NOT NULL CHECK (Percentage >= 0 AND Percentage <= 100),
                    DisplayOrder INTEGER NOT NULL DEFAULT 0,
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );

                -- Projects Table (Solutions & Case Studies)
                CREATE TABLE IF NOT EXISTS Projects (
                    Id SERIAL PRIMARY KEY,
                    Title VARCHAR(200) NOT NULL,
                    Description TEXT,
                    ImageUrl VARCHAR(500),
                    ProjectUrl VARCHAR(500),
                    GithubUrl VARCHAR(500),
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    IsActive BOOLEAN DEFAULT TRUE
                );

                -- Testimonials Table (Enterprise Client Reviews)
                CREATE TABLE IF NOT EXISTS Testimonials (
                    Id SERIAL PRIMARY KEY,
                    ClientName VARCHAR(100) NOT NULL,
                    ClientPosition VARCHAR(100),
                    Comment TEXT NOT NULL,
                    ClientImageUrl VARCHAR(500),
                    Rating INTEGER NOT NULL CHECK (Rating >= 1 AND Rating <= 5),
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    IsActive BOOLEAN DEFAULT TRUE    
                );

                -- Contacts Table (Inquiries & Leads)
                CREATE TABLE IF NOT EXISTS Contacts (
                    Id SERIAL PRIMARY KEY,
                    Name VARCHAR(100) NOT NULL,   
                    Email VARCHAR(255) NOT NULL,   
                    Subject VARCHAR(200),
                    Message TEXT NOT NULL,
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    IsRead BOOLEAN DEFAULT FALSE        
                );
            ";

            await connection.ExecuteAsync(initSql);

            // 1. Seed Aveny Technologies About (Company Profile) if empty
            var aboutCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM About;");
            if (aboutCount == 0)
            {
                var seedAboutSql = @"
                    INSERT INTO About (Title, Description, Age, City, Email, PhoneNumber, GithubUrl, LinkedInUrl, ImageUrl, CreatedAt)
                    VALUES (
                        'Enterprise Software Engineering & Intelligent Cloud Architectures',
                        'Aveny Technologies is an innovative software engineering and technology consulting company. We architect robust cloud-native platforms, high-throughput distributed microservices, and AI-driven digital ecosystems that empower forward-thinking enterprises worldwide.',
                        6,
                        'San Francisco, CA & Global Hubs',
                        'contact@avenytechnologies.com',
                        '+1 (800) 555-AVENY',
                        'https://github.com',
                        'https://linkedin.com',
                        '/ui/img/profile-img.jpg',
                        CURRENT_TIMESTAMP
                    );";
                await connection.ExecuteAsync(seedAboutSql);
            }

            // 2. Seed Aveny Technologies Skills (Core Tech Stack) if empty
            var skillsCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Skills;");
            if (skillsCount == 0)
            {
                var seedSkillsSql = @"
                    INSERT INTO Skills (Name, Percentage, DisplayOrder, CreatedAt) VALUES
                    ('.NET 10 / ASP.NET Core & C#', 96, 1, CURRENT_TIMESTAMP),
                    ('Cloud Architecture (AWS & Azure)', 92, 2, CURRENT_TIMESTAMP),
                    ('Distributed Microservices & Docker', 90, 3, CURRENT_TIMESTAMP),
                    ('High-Performance PostgreSQL & Data Engines', 94, 4, CURRENT_TIMESTAMP),
                    ('Modern Web & React / TypeScript Platforms', 88, 5, CURRENT_TIMESTAMP),
                    ('DevOps, CI/CD & Kubernetes Orchestration', 89, 6, CURRENT_TIMESTAMP);";
                await connection.ExecuteAsync(seedSkillsSql);
            }

            // 3. Seed Aveny Technologies Projects (Solutions & Case Studies) if empty
            var projectsCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Projects;");
            if (projectsCount == 0)
            {
                var seedProjectsSql = @"
                    INSERT INTO Projects (Title, Description, ImageUrl, ProjectUrl, GithubUrl, CreatedAt, IsActive) VALUES
                    (
                        'Aveny CloudMesh - Enterprise Microservices Gateway',
                        'High-performance API gateway and service mesh platform engineered with .NET 10 and Docker for zero-latency distributed communication.',
                        '/ui/img/portfolio/portfolio-1.jpg',
                        'https://google.com',
                        'https://github.com',
                        CURRENT_TIMESTAMP,
                        TRUE
                    ),
                    (
                        'Nexora AI - Predictive Analytics & Data Engine',
                        'Real-time intelligence engine integrating machine learning pipelines with high-throughput streaming data architecture.',
                        '/ui/img/portfolio/portfolio-2.jpg',
                        'https://google.com',
                        'https://github.com',
                        CURRENT_TIMESTAMP,
                        TRUE
                    ),
                    (
                        'FinEdge Core - Scalable Banking & Ledger Infrastructure',
                        'ACID-compliant, high-volume financial transaction processing engine with distributed event sourcing and bank-grade security.',
                        '/ui/img/portfolio/portfolio-3.jpg',
                        'https://google.com',
                        'https://github.com',
                        CURRENT_TIMESTAMP,
                        TRUE
                    );";
                await connection.ExecuteAsync(seedProjectsSql);
            }

            // 4. Seed Aveny Technologies Testimonials (Enterprise Client Endorsements) if empty
            var testimonialsCount = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Testimonials;");
            if (testimonialsCount == 0)
            {
                var seedTestimonialsSql = @"
                    INSERT INTO Testimonials (ClientName, ClientPosition, Comment, ClientImageUrl, Rating, CreatedAt, IsActive) VALUES
                    (
                        'Sarah Jenkins',
                        'VP of Engineering, CloudScale Global',
                        'Aveny Technologies delivered our core microservices platform ahead of schedule with unmatched performance, scalability, and engineering quality.',
                        '/ui/img/testimonials/testimonials-1.jpg',
                        5,
                        CURRENT_TIMESTAMP,
                        TRUE
                    ),
                    (
                        'Marcus Vance',
                        'Chief Technology Officer, Quantum Capital',
                        'The team at Aveny Technologies demonstrated world-class architectural mastery. Their high-throughput data solutions transformed our trading infrastructure.',
                        '/ui/img/testimonials/testimonials-2.jpg',
                        5,
                        CURRENT_TIMESTAMP,
                        TRUE
                    ),
                    (
                        'Elena Rostova',
                        'Director of Product, Nexus Health Systems',
                        'Partnering with Aveny Technologies accelerated our time-to-market by 40%. Their technical acumen and transparent communication were remarkable.',
                        '/ui/img/testimonials/testimonials-3.jpg',
                        5,
                        CURRENT_TIMESTAMP,
                        TRUE
                    );";
                await connection.ExecuteAsync(seedTestimonialsSql);
            }

            // 5. Ensure default admin user is seeded
            await _userSeedService.SeedDefaultUserAsync();

            _logger.LogInformation("Aveny Technologies database initialized successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing Aveny Technologies database tables.");
        }
    }
}
