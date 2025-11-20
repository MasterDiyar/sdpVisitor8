using System;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.factories;

public partial class TextOption : Node2D
{
    [Export] private LevelBase parentLevel;
    public TextLabel playerText;
    public Action NextText;

    private bool tend = false;
    public int index = 0;
    public override void _Ready()
    {
        playerText = parentLevel.GetNode<TextLabel>("Player/Camera2D/HpInspector/razgovor");
        playerText.TextFinished += TextEnded;
        playerText.StartText(parentLevel.Texts[index]);
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("e") && tend)
        {
            Newator();
            tend = false;
            NextText?.Invoke();
        }
    }
    private void TextEnded()
    {
        tend = true;
    }

    private void Newator()
    {
        index++;
        try {
            playerText.StartText(parentLevel.Texts[index]);
        }
        catch (IndexOutOfRangeException) { }
    }
}