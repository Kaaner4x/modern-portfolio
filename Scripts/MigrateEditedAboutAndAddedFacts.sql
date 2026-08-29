-- ==========================================
-- MigrateEditedAboutAndAddedFacts.sql
-- About tablosuna yeni kolonlar ekliyoruz
-- Facts tablosunu oluşturuyoruz
-- Mevcut About kaydını yeni kolonlara veri girerek güncelliyoruz
-- Facts tablosuna veri ekliyoruz
-- ==========================================


-- 1) About tablosuna yeni kolonlar ekleniyor
ALTER TABLE About
ADD COLUMN Age INTEGER,
ADD COLUMN LinkedInUrl VARCHAR(300),
ADD COLUMN GithubUrl VARCHAR(300),
ADD COLUMN Email VARCHAR(255),
ADD COLUMN PhoneNumber VARCHAR(50),
ADD COLUMN City VARCHAR(150);

-- 2) Facts tablosu oluşturuluyor
CREATE TABLE
    IF NOT EXISTS Facts (
        Id SERIAL PRIMARY KEY,
        ClientsNumber INTEGER NOT NULL DEFAULT 0,
        ProjectsNumber INTEGER NOT NULL DEFAULT 0,
        HoursOfSupport INTEGER NOT NULL DEFAULT 0,
        YearsOfExperience INTEGER NOT NULL DEFAULT 0,
        CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    );

-- 3) About tablosundaki mevcut satır güncelleniyor
-- Id = 1 olduğunu varsayarak güncelliyoruz.
UPDATE About
SET
    Age = 30,
    LinkedInUrl = 'https://www.linkedin.com/in/kellyadams',
    GithubUrl = 'https://github.com/kellyadams',
    Email = 'kelly@example.com',
    PhoneNumber = '+1 555 123 4567',
    City = 'New York',
    UpdatedAt = CURRENT_TIMESTAMP
WHERE
    Id = 1;

-- 4) Facts tablosuna 1 adet örnek satır ekleniyor
INSERT INTO
    Facts (
        ClientsNumber,
        ProjectsNumber,
        HoursOfSupport,
        YearsOfExperience
    )
VALUES
    (120, 45, 3500, 8);