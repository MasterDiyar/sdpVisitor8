using System;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.entity.enemy;

namespace finalSDP.scripts.factories;
using Godot;
public partial class FirstScene : LevelBase
{
    TextOption textOption;
    private AnimatedSprite2D agis;
    
    private int index = 0;
    private bool tend = false;

    public override string[] Texts { get; set; } =
    [
        "Where am I?",
        "Who am I?",
        "What's happening?",
        "SHUT UP",
        "YOU ARE JUST A DUST ON MY SHOE",
        "For what did I give my body?",
        "YOU GAVE IT FOR 1 BAD-SMELLING CANDLE! HA-HA-HA",
        "JUST KIDDING",
        "YOU WILL KNOW ABOUT THAT AFTER WINNING MY KIDS",
        "And if I win, will you return everything back?",
        "WE WILL SEE..."
    ];
    
    protected override void OnLevelLoaded()
    {
        agis = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        agis.Play();
        Player.MoveToggle();
        textOption = GetNode<TextOption>("TextOption");
        textOption.NextText += Newator;
    }

    protected override void ConfigureCamera()
    {
        Camera.LimitLeft = 0;
        Camera.LimitRight = 3000;
        Camera.LimitTop = 0;
        Camera.LimitBottom = 832;
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (index >= 10)
        {
            agis.Modulate = new Color(agis.Modulate, agis.Modulate.A - (float)delta);
            agis.Position += new Vector2(0, -5);
            agis.Scale += (float)delta*Vector2.One;
        }
    }

    private void Newator()
    {
        index++;

        switch (index)
        {
            case 3:
                agis.Visible = true;
                break;
            case 4:
                Player.MoveToggle();
                break;
            case 11:
                textOption.playerText.HideText();
                break;
        }
    }
}