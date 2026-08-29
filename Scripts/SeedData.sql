INSERT INTO About(Title, Description, ImageUrl)
VALUES ('Kelly Adams', 'Yazılım Geliştirici','ui/img/hero-bg.jpg');

INSERT INTO Skills(Name, Percentage, DisplayOrder)
VALUES
    ('HTML',90,1),
    ('CSS',95,2),
    ('ASP.NET Core Web API',85,3),
    ('ASP.NET Core MVC',85,4),
    ('React',75,5),
    ('Node',80,6);

INSERT INTO Projects(Title,Description,ImageUrl,IsActive)
VALUES
    ('Proje1','Proje1 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-1.jpg',TRUE),
    ('Proje2','Proje2 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-2.jpg',TRUE),
    ('Proje3','Proje3 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-3.jpg',TRUE),
    ('Proje4','Proje4 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-4.jpg',TRUE),
    ('Proje5','Proje5 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-5.jpg',TRUE),
    ('Proje6','Proje6 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-6.jpg',TRUE),
    ('Proje7','Proje7 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-7.jpg',TRUE),
    ('Proje8','Proje8 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-8.jpg',TRUE),
    ('Proje9','Proje9 Açıklaması','ui/img/masonry-portfolio/masonry-portfolio-9.jpg',FALSE);

INSERT INTO Testimonials(ClientName,ClientPosition,Comment,ClientImageUrl,Rating)
VALUES
    ('Client1','Client Position 1', 'Client 1 Comment','ui/img/testimonials/testimonials-1.jpg',4),
    ('Client2','Client Position 2', 'Client 2 Comment','ui/img/testimonials/testimonials-2.jpg',5),
    ('Client3','Client Position 3', 'Client 3 Comment','ui/img/testimonials/testimonials-3.jpg',4),
    ('Client4','Client Position 4', 'Client 4 Comment','ui/img/testimonials/testimonials-4.jpg',5),
    ('Client5','Client Position 5', 'Client 5 Comment','ui/img/testimonials/testimonials-5.jpg',5);

