namespace QB_Remote_GUI.GUI.Components;

public sealed partial class TorrentPieceView : UserControl
{
    private const int FixedHeight = 48; // Configurable fixed height
    private const int MinBlockSize = 6;
    private const int MaxBlockSize = 16;
    private int[]? _data;
    private readonly Color _colorNotDownloaded = Color.White;
    private readonly Color _colorDownloading = Color.Blue;
    private readonly Color _colorDownloaded = Color.LightGreen;
    private readonly Color _colorSpace = SystemColors.Control;

    public TorrentPieceView()
    {
        InitializeComponent();
        Height = FixedHeight;
        DoubleBuffered = true;
    }

    public void Render(int[] data)
    {
        _data = data;
        if (_data == null || _data.Length == 0) return;

        Invalidate();
    }

    private int GetOptimalBlockSize()
    {
        if (_data == null || _data.Length == 0) return MaxBlockSize;

        int minBlockSize = MinBlockSize;
        int maxBlockSize = MaxBlockSize;
        int optimalBlockSize = minBlockSize;
        while (minBlockSize <= maxBlockSize)
        {
            int midBlockSize = (minBlockSize + maxBlockSize) / 2;

            int blocksPerColumn = FixedHeight / midBlockSize;
            int requiredColumns = (int)Math.Ceiling((double)_data.Length / blocksPerColumn);
            if (requiredColumns * midBlockSize > Width)
            {
                maxBlockSize = midBlockSize - 1;
            }
            else
            {
                optimalBlockSize = midBlockSize;
                minBlockSize = midBlockSize + 1;
            }
        }
        return optimalBlockSize;
    }

    private void TorrentPieceView_Paint(object sender, PaintEventArgs e)
    {
        if (_data == null || _data.Length == 0) return;

        int optimalBlockSize = GetOptimalBlockSize();

        int blocksPerColumn = FixedHeight / optimalBlockSize;
        int totalColumns = Width / optimalBlockSize;
        int totalBlocks = blocksPerColumn * totalColumns;
        int valuesPerBlock = 1;
        if (totalBlocks < _data.Length)
            valuesPerBlock = (int)Math.Ceiling((double)_data.Length / totalBlocks);
        int totalRealBlocks = _data.Length;
        if (valuesPerBlock > 1)
            totalRealBlocks = (int)Math.Ceiling((double)_data.Length / valuesPerBlock);

        using var brush = new SolidBrush(Color.White);
        for (int i = 0; i < totalRealBlocks; i++)
        {
            int column = i / blocksPerColumn;
            int row = i % blocksPerColumn;

            int x = column * optimalBlockSize;
            int y = row * optimalBlockSize;

            // If we need to combine multiple values into one block
            if (valuesPerBlock > 1)
            {
                var values = new List<int>();
                for (int j = 0; j < valuesPerBlock && i * valuesPerBlock + j < _data.Length; j++)
                {
                    values.Add(_data[i * valuesPerBlock + j]);
                }

                brush.Color = GetCombinedColor(values);
            }
            else
            {
                brush.Color = GetColor(_data[i]);
            }

            if (x + optimalBlockSize <= Width) // Only draw if within bounds
            {
                e.Graphics.FillRectangle(brush, x, y, optimalBlockSize - 1, optimalBlockSize - 1);
            }
        }
    }

    private Color GetColor(int value)
    {
        return value switch
        {
            0 => _colorNotDownloaded,
            1 => _colorDownloading,
            2 => _colorDownloaded,
            _ => _colorNotDownloaded
        };
    }

    private Color GetCombinedColor(List<int> values)
    {
        if (values.Count == 0) return _colorSpace;
        if (values.Contains(1)) return _colorDownloading;
        if (values.Contains(0)) return _colorNotDownloaded;
        return _colorDownloaded;
    }
}