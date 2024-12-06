using Godot;
using System;

public partial class MainMenu : Control
{
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
		GetTree().Quit();
	}
}
