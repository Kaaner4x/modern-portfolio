using System;
using ModernPortfolio.Models;
namespace ModernPortfolio.ViewModels;
public class HomeViewModel
{    public About? About { get; set; }
    public IEnumerable<Testimonial> Testimonials { get; set; } = [];
    // Setting bilgilerini de buraya ekleyeceğiz
}
