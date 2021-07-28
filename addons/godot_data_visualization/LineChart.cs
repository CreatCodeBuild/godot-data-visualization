using Godot;
using System.Collections.Generic;
using System.Linq;

[Tool]
public class LineChart : Control
{
    PackedScene LineChartScene = GD.Load<PackedScene>("res://addons/godot_data_visualization/LineChart.tscn");


    // The area in which the chart will be draw, in pixel
    public int Width = 400;
    public int Height = 200;
    public int Padding = 20;

    public override void _EnterTree()
    {
        base._EnterTree();
        // var instnace = LineChartScene.Instance();
        // AddChild(instnace);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        DrawBorder();
    }

    public void Plot(List<float> data)
    {
        var xSeparation = Width / (float)(data.Count - 1);

        var max = data.Max(number => number);
        var min = data.Min(number => number);

        var line = new Line2D();
        line.Width = 3;
        var i = 0;
        foreach (var datum in data)
        {
            var yPosition = (datum - min) / (max - min) * Height;
            line.AddPoint(new Vector2(i * xSeparation + Padding / 2, Height - yPosition + Padding / 2));
            i++;
        }
        AddChild(line);
    }

    public void DrawBorder()
    {
        var line = new Line2D();
        line.Width = 3;
        line.AddPoint(new Vector2(0, 0));
        line.AddPoint(new Vector2(Width + Padding, 0));
        line.AddPoint(new Vector2(Width + Padding, Height + Padding));
        line.AddPoint(new Vector2(0, Height + Padding));
        line.AddPoint(new Vector2(0, 0));
        AddChild(line);
    }

}
