using Godot;
using System.Collections.Generic;

public class MyButton : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var node = (LineChart) GetNode("LineChart");
		node.Plot(new List<float> { 5, 100, 200, 4, 54, 123, 99 });
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
