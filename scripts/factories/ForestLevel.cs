using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;

namespace finalSDP.scripts.factories;
using Godot;


public partial class ForestLevel : LevelBase
{
    TextOption textOption;
    public override string[] Texts { get; set; } = [
        "Well, as I hear, first and easiest son of the demon lives in this forest.",
        "If i kill him I should get the heart of Forest.",
        "But...",
        "How did i know about the forest?"
        ,"..."
    ];
    
    protected override void ConfigureCamera()
    {
        Camera.LimitLeft = 30;
        Camera.LimitRight = 2560;
        Camera.LimitTop = 0;
        Camera.LimitBottom = 716;
    }

    protected override void OnLevelLoaded()
    {
        Player.MoveToggle();
        textOption = GetNode<TextOption>("TextOption");
        textOption.NextText += Newator;
    }

    private void Newator()
    {
        if (textOption.index == 4) {
            Player.MoveToggle();
            textOption.playerText.HideText();
        }
    }
}