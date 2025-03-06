using QB_Remote_GUI.API.Models.Torrents;

namespace QB_Remote_GUI.GUI.Models;

public class TorrentInfoComparer
{
    static internal int Compare(TorrentInfo a, TorrentInfo b, string columnName)
    {
        return columnName switch
        {
            "nameColumn" => string.CompareOrdinal(a.Name, b.Name),
            "sizeDownloadColumn" => CompareNumbers(a.Size, b.Size),
            "sizeColumn" => CompareNumbers(a.TotalSize, b.TotalSize),
            "progressColumn" => CompareNumbers(a.Progress, b.Progress),
            "downloadedColumn" => CompareNumbers(a.Downloaded, b.Downloaded),
            "uploadedColumn" => CompareNumbers(a.Uploaded, b.Uploaded),
            "statusColumn" => string.CompareOrdinal(a.State, b.State),
            "seedsColumn" => CompareNumbers(a.TotalSeeds, b.TotalSeeds),
            "peersColumn" => CompareNumbers(a.TotalPeers, b.TotalPeers),
            "downloadSpeedColumn" => CompareNumbers(a.DownloadSpeed, b.DownloadSpeed),
            "uploadSpeedColumn" => CompareNumbers(a.UploadSpeed, b.UploadSpeed),
            "etaColumn" => CompareNumbers(a.Eta, b.Eta),
            "ratioColumn" => CompareNumbers(a.Ratio, b.Ratio),
            "addedOnColumn" => CompareNumbers(a.AddedOn, b.AddedOn),
            "completedOnColumn" => CompareNumbers(a.CompletionOn, b.CompletionOn),
            "lastActiveColumn" => CompareNumbers(a.LastActive, b.LastActive),
            "pathColumn" => string.CompareOrdinal(a.SavePath, b.SavePath),
            "priorityColumn" => CompareNumbers(a.Priority, b.Priority),
            "seedingTimeColumn" => CompareNumbers(a.SeedingTime, b.SeedingTime),
            "sizeLeftColumn" => CompareNumbers(a.AmountLeft, b.AmountLeft),
            "isPrivateColumn" => CompareBooleans(a.Private, b.Private),
            "labelColumn" => string.CompareOrdinal(a.Tags, b.Tags),
            _ => 0
        };
    }

    static int CompareNumbers(double? a, double? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.Value.CompareTo(b.Value);
    }

    static int CompareNumbers(long? a, long? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.Value.CompareTo(b.Value);
    }

    static int CompareNumbers(int? a, int? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.Value.CompareTo(b.Value);
    }

    static int CompareBooleans(bool? a, bool? b)
    {
        if (a == null && b == null) return 0;
        if (a == null) return -1;
        if (b == null) return 1;
        return a.Value.CompareTo(b.Value);
    }
}
