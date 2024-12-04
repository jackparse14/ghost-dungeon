using Godot;
using System;

public partial class GameController : Node
{
    [Export] private Node2D world2D;
    [Export] private Node3D world3D;
    [Export] private Control gui;

    private Node2D current2dScene;
    private Node3D current3dScene;
    private Control currentGuiScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Global.gameController = this;
        // TESTING
        ChangeGuiScene("res://Scenes/MainMenu.tscn");
    }

    public void Change3DScene(String newScene, bool delete = true, bool keepRunning = false)
    {
        if (current3dScene != null)
        {
            if (delete) { current3dScene.QueueFree(); }
            else if (keepRunning) { current3dScene.Visible = false; }
            else
            {
                world3D.RemoveChild(current3dScene);
            }
        }
        PackedScene packedScene = GD.Load<PackedScene>(newScene);
        if(packedScene != null)
        {
            Node loadedScene = packedScene.Instantiate();
            if (loadedScene is Node3D new3dScene) {
                world3D.AddChild(new3dScene);
                current3dScene = new3dScene;
            }
        }
    }
    public void Change2DScene(String newScene, bool delete = true, bool keepRunning = false)
    {
        if (current2dScene != null)
        {
            if (delete) { current2dScene.QueueFree(); }
            else if (keepRunning) { current2dScene.Visible = false; }
            else
            {
                world2D.RemoveChild(current2dScene);
            }
        }
        PackedScene packedScene = GD.Load<PackedScene>(newScene);
        if (packedScene != null)
        {
            Node loadedScene = packedScene.Instantiate();
            if (loadedScene is Node2D new2dScene)
            {
                world2D.AddChild(new2dScene);
                current2dScene = new2dScene;
            }
        }
    }
    public void ChangeGuiScene(String newScene, bool delete = true, bool keepRunning = false)
    {
        if (currentGuiScene != null)
        {
            if (delete) { currentGuiScene.QueueFree(); }
            else if (keepRunning) { currentGuiScene.Visible = false; }
            else
            {
                gui.RemoveChild(currentGuiScene);
            }
        }
        PackedScene packedScene = GD.Load<PackedScene>(newScene);
        if (packedScene != null)
        {
            Node loadedScene = packedScene.Instantiate();
            if (loadedScene is Control controlScene)
            {
                gui.AddChild(controlScene);
                currentGuiScene = controlScene;
            }
        }
    }
}
