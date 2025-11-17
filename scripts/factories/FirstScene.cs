using System;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.entity.enemy;

namespace finalSDP.scripts.factories;
using Godot;
public partial class FirstScene : Node2D
{
    private Player pl;
    private Bolvanchik bolvanchik;
    TextLabel playerText;
    private AnimatedSprite2D agis;
    
    private int index = 0;
    private bool tend = false;

    private string[] Texts =
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

    public override void _Ready()
    {
        agis = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        agis.Play();
        var factory =  GetNode<UserFactory>("UserFactory");
    }

    public void UserLoad()
    {
        pl = GetNode<Player>("Player");
        var camera = GetNode<Camera2D>( "Player/Camera2D");
        playerText = GetNode<TextLabel>("Player/Camera2D/HpInspector/razgovor");
        playerText.TextFinished += TextEnded;
        playerText.StartText(Texts[index]);
        camera.LimitLeft = 0;
        camera.LimitRight = 4032;
        camera.LimitTop = 0;
        camera.LimitBottom = 832;
        pl.MoveToggle();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("space") && tend) {
            Newator();
            tend = false;
        }
        
        if (index == 10)
            agis.Modulate = new Color(agis.Modulate, agis.Modulate.A-(float)delta);
    }

    private void TextEnded()
    {
        tend = true;
    }
    private void Newator()
    {
        index++;
        try{
            playerText.StartText(Texts[index]);
        }catch(IndexOutOfRangeException){}

        if (index == 3)
            agis.Visible = true;
        
        if (index == 4)
            pl.MoveToggle();
        
        if (index == 11)
            playerText.HideText();
            
    }
}