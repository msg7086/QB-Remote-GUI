using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using QB_Remote_GUI.API.Models.Torrents;

namespace QB.Remote.GUI.Models;

public class TorrentFileTree
{
    public string BaseName { get; set; } = string.Empty;
    public string FullPath { get; set; } = string.Empty;
    public long Size { get; set; }
    public double Progress { get; set; }
    public int Priority { get; set; }
    public bool IsSeed { get; set; }
    public double Availability { get; set; }
    public List<TorrentFileTree> Children { get; set; } = new();
    public TorrentFileTree? Parent { get; set; }
    public int IndentCount { get; set; }
    public bool IsExpanded { get; set; } = false;
    public int Index { get; set; } = -1;  // -1 for folders
    public int[] PieceRange { get; set; } = Array.Empty<int>();

    public CheckBoxState CachedCheckBoxState { get; set; } = CheckBoxState.UncheckedNormal;

    public static List<TorrentFileTree> BuildTree(IEnumerable<TorrentContentInfo> files)
    {
        var root = new Dictionary<string, TorrentFileTree>();
        var result = new List<TorrentFileTree>();

        foreach (var file in files)
        {
            var parts = file.Name.Split('/', '\\');
            var currentPath = "";
            TorrentFileTree? parent = null;

            for (int i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                currentPath = i == 0 ? part : Path.Combine(currentPath, part);

                if (!root.ContainsKey(currentPath))
                {
                    var node = new TorrentFileTree
                    {
                        BaseName = part,
                        FullPath = currentPath,
                        IndentCount = i
                    };

                    if (i == parts.Length - 1)
                    {
                        // This is a file
                        node.Size = file.Size;
                        node.Progress = file.Progress;
                        node.Priority = file.Priority;
                        node.IsSeed = file.IsSeed;
                        node.Availability = file.Availability;
                        node.Index = file.Index;
                        node.PieceRange = file.PieceRange;
                        node.Parent = parent;
                    }

                    if (parent == null)
                    {
                        result.Add(node);
                    }
                    else
                    {
                        parent.Children.Add(node);
                    }

                    root[currentPath] = node;
                }

                parent = root[currentPath];
            }
        }

        return result;
    }

    public void UpdateStateRecursively()
    {
        if (Children.Count == 0)
        {
            CachedCheckBoxState = Priority == 0 ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal;
            return;
        }
        Children.ForEach(child => child.UpdateStateRecursively());
        var states = Children.Select(c => c.CachedCheckBoxState).Distinct();
        CachedCheckBoxState = states.Count() == 1 ? states.First() : CheckBoxState.MixedNormal;
        Size = Children.Sum(c => c.Size);
        Progress = Children.Sum(c => c.Progress * c.Size) / Size;
        var priorities = Children.Select(c => c.Priority).Distinct();
        Priority = priorities.Count() == 1 ? priorities.First() : -1; // -1 means mixed
    }
} 
