using BZ_WebMobileTemplate.Shared.Services;

namespace BZ_WebMobileTemplate.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor() => DeviceInfo.Idiom.ToString();

        public string GetPlatform() =>
            $"{DeviceInfo.Platform} - {DeviceInfo.VersionString}";

        public bool IsWeb() => false;

        public bool IsMobile() =>
            DeviceInfo.Idiom == DeviceIdiom.Phone || DeviceInfo.Idiom == DeviceIdiom.Tablet;
        public bool IsDesktop() => DeviceInfo.Idiom == DeviceIdiom.Desktop;
    }
}
