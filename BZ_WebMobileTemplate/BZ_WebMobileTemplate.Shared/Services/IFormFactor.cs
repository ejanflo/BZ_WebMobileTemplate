namespace BZ_WebMobileTemplate.Shared.Services
{
    public interface IFormFactor
    {
        string GetFormFactor();   // Raw idiom or "Web"
        string GetPlatform();     // OS / version
        bool IsWeb();
        bool IsMobile();          // Phone or Tablet (native host or mobile browser if you later add detection)
        bool IsDesktop();         // Convenience
    }
}
