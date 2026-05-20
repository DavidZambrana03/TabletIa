using Microsoft.Extensions.Localization;
using System.Globalization;
using WhiteFlexo.Resources;

public class CultureResources
{
    private readonly IStringLocalizer<Resources> _localizer;

    private static readonly List<CultureInfo> _supportedCultures = new();

    public CultureResources(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;

        if (_supportedCultures.Count == 0)
            LoadSupportedCultures();
    }

    private void LoadSupportedCultures()
    {
        _supportedCultures.Add(new CultureInfo("en")); // default
        _supportedCultures.Add(new CultureInfo("de"));
        _supportedCultures.Add(new CultureInfo("fr"));
    }

    public IReadOnlyList<CultureInfo> SupportedCultures => _supportedCultures;

    public void SetCulture(CultureInfo culture)
    {
        if (!_supportedCultures.Contains(culture))
            culture = new CultureInfo("en");

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }

    public string GetValue(string key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        return _localizer[key]; // returns translation if .resx is correct
    }
}
