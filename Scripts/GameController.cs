using Godot;
using System;

public partial class GameController : Node
{
    [Export] private World2D world2D;
    [Export] private World3D world3D;
    [Export] private Control gui;

    private World2D current2dScene;
    private World2D current3dScene;
    private World2D currentGuiScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Global.gameController = this;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
