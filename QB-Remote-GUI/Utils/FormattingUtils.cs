using System;

namespace QB_Remote_GUI.GUI.Utils
{
    public static class FormattingUtils
    {
        public static string FormatSize(long bytes)
        {
            string[] sizes = ["B", "KB", "MB", "GB", "TB"];
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        public static string FormatSize(long? bytes)
        {
            if (bytes.HasValue)
                return FormatSize(bytes.Value);
            return "N/A";
        }

        public static string FormatSpeed(long bytesPerSecond)
        {
            if (bytesPerSecond == 0)
                return "";
            return $"{FormatSize(bytesPerSecond)}/s";
        }

        public static string FormatSpeed(long? bytesPerSecond)
        {
            if (bytesPerSecond.HasValue)
                return FormatSpeed(bytesPerSecond.Value);
            return "N/A";
        }

        public static string FormatTime(long? seconds)
        {
            if (seconds.HasValue)
                return TimeSpan.FromSeconds(seconds.Value).ToString(@"hh\:mm\:ss");
            return "N/A";
        }

        public static string FormatReadableTime(long? seconds)
        {
            if (!seconds.HasValue)
                return "N/A";
            if (seconds.Value < 60)
                return $"{seconds.Value}s";
            if (seconds.Value < 3600)
                return $"{seconds.Value / 60}m";
            if (seconds.Value < 86400)
                return $"{seconds.Value / 3600}h, {seconds.Value % 3600 / 60}m";
            return $"{seconds.Value / 86400}d, {seconds.Value % 86400 / 3600}h";
        }

        public static string FormatDateTime(long? unixTimestamp)
        {
            if (unixTimestamp.HasValue)
                return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp.Value).LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return "N/A";
        }
    }
} 
