using Godot;

namespace GhostDungeon.Scripts
{
    public partial class MainMenu : Control
    {
        private static void OnContinueButtonPressed()
        {
            GD.Print("Continue Button Pressed");
        }
        private static void OnNewGameButtonPressed()
        {
            GD.Print("New Game Button Pressed");
        }
        private static void OnOptionsButtonPressed()
        {
            GD.Print("Options Button Pressed");
        }
        private void OnQuitButtonPressed()
        {
            GD.Print("Quit Button Pressed");
            GetTree().Quit();
        }
    }
}