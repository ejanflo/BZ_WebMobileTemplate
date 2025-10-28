using BZ_WebMobileTemplate.Shared.Services;

namespace BZ_WebMobileTemplate.Web.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor() => "Web";
        public string GetPlatform() => Environment.OSVersion.ToString();

        public bool IsWeb() => true;

        // (Optional) enhance later with JS to detect mobile browser; for now treat as non-mobile layout.
        public bool IsMobile() => false;

        public bool IsDesktop() => true;
    }
}
