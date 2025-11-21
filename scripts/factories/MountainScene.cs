using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;

namespace finalSDP.scripts.factories;
using Godot;

public partial class MountainScene : LevelBase
{
    private int index = 0;
    TextOption textOption;
    public override string[] Texts { get; set; } = [
        "I have never gone so far from my house.",
        "Stop.",
        "How do i recall where my house is?",
        "Well, i still cant go to my house.",
        "I need to destroy Ice Stone Golem, the great keeper of nature.",
        "It sounds difficult."
    ];
    protected override void ConfigureCamera()
    {
        Camera.LimitLeft = 0;
        Camera.LimitRight = 3830;
        Camera.LimitTop = 0;
        Camera.LimitBottom = 1053;
    }
    
    protected override void OnLevelLoaded()
    {
        Player.MoveToggle();
        textOption = GetNode<TextOption>("TextOption");
        textOption.NextText += () => {if(++index > 5){Player.MoveToggle();textOption.playerText.HideText();} } ;
        
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Player.Position.Y > 1080)
        {
            Player.Position = new Vector2(Player.Position.X, Player.Position.Y - 1480);
            Player.TakeDamage(10);
        }
    }
}

