﻿namespace QB_Remote_GUI.GUI;

/// <summary>
/// Extension methods for List Views
/// </summary>
public static class ListViewExtensions
{
    /// <summary>
    /// Sets the double buffered property of a list view to the specified value
    /// </summary>
    /// <param name="listView">The List view</param>
    /// <param name="doubleBuffered">Double Buffered or not</param>
    public static void SetDoubleBuffered(this ListView listView, bool doubleBuffered = true)
    {
        listView
            .GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
            .SetValue(listView, doubleBuffered, null);
    }
}