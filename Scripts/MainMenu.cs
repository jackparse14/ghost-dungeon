using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//// Called every frame. 'delta' is the elapsed time since the previous frame.
	//public override void _Process(double delta)
	//{
	//}
	private void _on_ContinueButton_pressed()
	{
		GD.Print("Continue Button Pressed");
	}
	private void _on_NewGameButton_pressed()
	{
		GD.Print("New Game Button Pressed");
	}
	private void _on_OptionsButton_pressed()
	{
		GD.Print("Options Button Pressed");
	}
	private void _on_QuitButton_pressed()
	{
		GD.Print("Quit Button Pressed");
		GetTree().quit();
	}
}
