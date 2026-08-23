-- CREATE TABLE komutları
-- INDEX oluşturma komutları
-- CONSTRAINT oluşturma komutları

-- SERIAL: otomatik olarak artan integer değerler
-- RETURNING: INSERT/UPDATE işlemlerinde yeni değerleri döndürür
-- TEXT: sınırsız uzunluktaki metinsel değerler
-- BOOLEAN: bool değerler 

-- IF NOT EXISTS


-- About
-- Skills
-- Projects
-- Testimonials
-- Contacts 

-- About Tablosu: Hakkımda bilgilerini içerir
CREATE TABLE IF NOT EXISTS About(
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Description TEXT,
    ImageUrl VARCHAR(500),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Skills Tablosu: Yetenek bilgilerini içerir
CREATE TABLE IF NOT EXISTS Skills(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Percentage INTEGER NOT NULL CHECK (Percentage>=0 AND Percentage<=100),
    DisplayOrder INTEGER NOT NULL DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Projects Tablosu: Proje bilgilerini içerir
CREATE TABLE IF NOT EXISTS Projects(
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Description TEXT,
    ImageUrl VARCHAR(500),
    ProjectUrl VARCHAR(500),
    GithubUrl VARCHAR(500),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE
);

-- Testimonials Tablosu: Müşteri referanslarını içerir
CREATE TABLE IF NOT EXISTS Testimonials(
    Id SERIAL PRIMARY KEY,
    ClientName VARCHAR(100) NOT NULL,
    ClientPosition VARCHAR(100),
    Comment TEXT NOT NULL,
    ClientImageUrl VARCHAR(500),
    Rating INTEGER NOT NULL CHECK (Rating>=1 AND Rating<=5),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE    
);

-- Contacts Tablosu: İletişim formu mesajlarını içerir
CREATE TABLE IF NOT EXISTS Contacts(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,   
    Email VARCHAR(255) NOT NULL,   
    Subject VARCHAR(200),
    Message TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsRead BOOLEAN DEFAULT FALSE        
);