using System.Text;

namespace QB_Remote_GUI.GUI.Utils;

public sealed class LanguageLoader
{
    private static LanguageLoader? _instance;
    public const string Dots = "...";
    private static readonly object _lock = new();
    private readonly Dictionary<string, string> _translations = new();

    private static readonly string _baseDir = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string _langDir = Path.Combine(_baseDir, "Resources", "lang");
    private static readonly string _transguiPath = Path.Combine(_langDir, "transgui.{0}");
    private static readonly string _qbguiPath = Path.Combine(_langDir, "qbgui.{0}");

    private LanguageLoader(string language)
    {
        LoadTranslations(language);
    }

    public static LanguageLoader Instance
    {
        get
        {
            if (_instance != null) return _instance;
            throw new InvalidOperationException("Language Loader not initialized.");
        }
    }

    public static LanguageLoader GetInstance(string language = "zh")
    {
        if (_instance != null) return _instance;
        lock (_lock)
            _instance ??= new LanguageLoader(language);
        return _instance;
    }

    private void LoadTranslations(string language)
    {
        try
        {
            string transguiFilePath = string.Format(_transguiPath, language);
            string qbguiFilePath = string.Format(_qbguiPath, language);

            LoadFile(transguiFilePath);
            LoadFile(qbguiFilePath); // This will overwrite any duplicate keys from transgui
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading language files: {ex.Message}", "Language Load Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
            {
                continue;
            }

            if (line.Contains('"'))
            {
                // Regex to match key-value pairs with optional quotes
                var match = System.Text.RegularExpressions.Regex.Match(line, """^"(?<key>[^"]*)"="(?<value>[^"]*)"$""");

                if (!match.Success) continue;
                string key = match.Groups["key"].Value.Trim();
                string value = match.Groups["value"].Value.Trim();

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    _translations[key] = value; // Use indexer to overwrite existing keys
                }
            }
            else if (line.Contains('='))
            {
                int equalIndex = line.IndexOf('=');
                if (equalIndex <= 0 || equalIndex >= line.Length - 1) continue;
                string key = line.Substring(0, equalIndex).Trim();
                string value = line.Substring(equalIndex + 1).Trim();

                _translations[key] = value; // Use indexer to overwrite existing keys
            }
        }
    }

    public string GetTranslation(string originalText)
    {
        if (string.IsNullOrEmpty(originalText))
        {
            return originalText;
        }

        string translation = _translations.GetValueOrDefault(originalText, originalText);
        return translation.Replace("~", Environment.NewLine);
    }
}
