using QB_Remote_GUI.GUI.Forms;

namespace QB_Remote_GUI.GUI.Views;

public static class ColumnConfigMerger
{
    /// <summary>
    /// Merges stored column configuration with default configuration.
    /// For matching columns, uses stored config values.
    /// For new columns in default config, appends them to the end.
    /// Removes columns that no longer exist in default config.
    /// </summary>
    public static List<ColumnInfo> MergeColumnConfigs(List<ColumnInfo> defaultConfig, List<ColumnInfo> storedConfig)
    {
        var mergedConfig = new List<ColumnInfo>();
        var processedColumns = new HashSet<string>();

        // First, process all stored columns that exist in default config
        foreach (var storedColumn in storedConfig)
        {
            var defaultColumn = defaultConfig.FirstOrDefault(c => c.Name == storedColumn.Name);
            if (defaultColumn == null) continue;
            // Use stored values but keep default text (for language updates)
            mergedConfig.Add(new ColumnInfo
            {
                Name = storedColumn.Name,
                Text = defaultColumn.Text, // Keep default text for language updates
                Width = storedColumn.Width,
                IsVisible = storedColumn.IsVisible
            });
            processedColumns.Add(storedColumn.Name);
        }

        // Then add any new columns from default config that weren't in stored config
        mergedConfig.AddRange(
            defaultConfig
                .Where(defaultColumn => !processedColumns.Contains(defaultColumn.Name))
                .Select(defaultColumn => new ColumnInfo { Name = defaultColumn.Name, Text = defaultColumn.Text, Width = defaultColumn.Width, IsVisible = defaultColumn.IsVisible }));

        return mergedConfig;
    }
} 
