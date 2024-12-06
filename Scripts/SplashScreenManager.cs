using Godot;
using System.Threading.Tasks;

namespace GhostDungeon.Scripts
{
    public partial class SplashScreenManager : Control
    {
        [Export] PackedScene loadScene;
        [Export] float inTime = 0.5f;
        [Export] float fadeInTime = 1.5f;
        [Export] float pauseTime = 1.5f;
        [Export] float fadeOutTime = 1.5f;
        [Export] float outTime = 0.5f;
        [Export] Node splashScreenContainer;

        private Godot.Collections.Array<Node> splashScreens;

        public async override void _Ready()
        {

            GetScreens();
            await Fade();
            Global.GameControllerInstance.ChangeGuiScene("res://Scenes/MainMenu.tscn");
        }

        public void GetScreens()
        {
            splashScreens = splashScreenContainer.GetChildren();
            GD.Print(splashScreens.Count);
            for (int i = 0; i < splashScreens.Count; i++)
            {
                TextureRect screen = (TextureRect)splashScreens[i];
                screen.Modulate = new Color(screen.Modulate.R, screen.Modulate.G, screen.Modulate.B, 0.0f);
            }
        }

        public async Task Fade()
        {
            foreach (Node screen in splashScreens)
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

        }


        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event.IsPressed())
            {
                Global.GameControllerInstance.ChangeGuiScene("res://Scenes/MainMenu.tscn");
            }
        }
    }

}
