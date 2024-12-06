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
    //[Export] TextureRect splashScreen;

    [Export] Node splashScreenContainer;

    private Godot.Collections.Array<TextureRect> splashScreens;

    public override void _Ready()
    {
        getScreens();
        fade();
    }

    public void getScreens()
    {
        splashScreens = new Godot.Collections.Array<TextureRect>();
        foreach(TextureRect screen in splashScreenContainer.GetChildren())
        {
            splashScreens.Add(screen);
            screen.Modulate = new Color(screen.Modulate.R, screen.Modulate.G, screen.Modulate.B, 0.0f);
        }
    }

    public async void fade() {
        foreach (TextureRect screen in splashScreens)
        {
            // Fade In
            Tween tween = GetTree().CreateTween();
            tween.TweenProperty(screen, "modulate:a", 1.0f, fadeInTime);
            await ToSignal(tween, "finished");
            
            // Pause
            await ToSignal(GetTree().CreateTimer(pauseTime), "timeout");
            
            // Fade Out
            tween = GetTree().CreateTween();
            tween.TweenProperty(screen, "modulate:a", 0.0f, fadeOutTime);
            await ToSignal(tween, "finished");

            // Pause
            await ToSignal(GetTree().CreateTimer(outTime), "timeout");
        }
        Global.gameController.ChangeGuiScene("res://Scenes/MainMenu.tscn");
    }


    public void unhandledInput(InputEvent input){
        if (input.IsPressed()) {
            Global.gameController.ChangeGuiScene("res://Scenes/MainMenu.tscn");
        }
    }
}
