using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QB_Remote_GUI.GUI.Models
{
    public class LanguageLoader
    {
        private static LanguageLoader _instance;
        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();

        private LanguageLoader()
        {
            LoadTranslations();
        }

        public static LanguageLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LanguageLoader();
                }
                return _instance;
            }
        }

        private void LoadTranslations()
        {
            try
            {
                string langFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "lang", "transgui.zh");
                if (!File.Exists(langFilePath))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(langFilePath, Encoding.UTF8);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//") || !line.Contains("="))
                    {
                        continue;
                    }

                    int equalIndex = line.IndexOf('=');
                    if (equalIndex <= 0 || equalIndex >= line.Length - 1)
                    {
                        continue;
                    }

                    string key = line.Substring(0, equalIndex).Trim();
                    string value = line.Substring(equalIndex + 1).Trim();

                    // Remove quotes if they exist
                    if (key.StartsWith("\"") && key.EndsWith("\""))
                    {
                        key = key.Substring(1, key.Length - 2);
                    }
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    if (!_translations.ContainsKey(key))
                    {
                        _translations.Add(key, value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading language file: {ex.Message}", "Language Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string GetTranslation(string originalText)
        {
            if (string.IsNullOrEmpty(originalText))
            {
                return originalText;
            }

            string translation = _translations.TryGetValue(originalText, out string value) ? value : originalText;
            return translation.Replace("~", Environment.NewLine);
        }
    }
} 
