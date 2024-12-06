using Godot;
using System;

public partial class SplashScreenManager : Control
{
	[Export] PackedScene loadScene;
    [Export] float inTime = 0.5f;
    [Export] float fadeInTime = 1.5f;
    [Export] float pauseTime = 1.5f;
    [Export] float fadeOutTime = 1.5f;
    [Export] float outTime = 0.5f;
    [Export] TextureRect splashScreen;

    public override void _Ready()
    {
        fade();
    }
    public async void fade() {
        splashScreen.Modulate = new Color(splashScreen.Modulate.R, splashScreen.Modulate.G, splashScreen.Modulate.B, 0.0f);
        Tween tween = CreateTween();
        tween.TweenProperty(splashScreen, "modulate:a", 1.0f, fadeInTime);

        await ToSignal(tween, "tween_all_completed");
        await ToSignal(GetTree().CreateTimer(pauseTime), "timeout");

        tween.TweenProperty(splashScreen, "modulate:a", 0.0f, fadeOutTime);

        await ToSignal(tween,"tween_all_completed");
        await ToSignal(GetTree().CreateTimer(outTime), "timeout");

        Global.gameController.ChangeGuiScene("res://Scenes/MainMenu.tscn");
    }

}
