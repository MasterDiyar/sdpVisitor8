using System;
using Godot;

namespace finalSDP.scripts.entity.player;

public partial class TextLabel : Label
{
    [Export] private float LPS = 30;
    private float counter = 0;
    private string FullText = "";
    [Export] private ColorRect rect;
    public void AddText(string text)
    {
        rect.Visible = true;
        Visible = true;
        FullText = text;
    }

    public override void _Process(double delta)
    {
        counter += (float)delta;
        if (counter >= 1/LPS) {
            counter = 0;
            try {
                if (Text != FullText)
                    Text += FullText[Text.Length];
            } catch (IndexOutOfRangeException) { }
        }
        if (Input.IsActionJustPressed("space") && Text != "")
            Text = FullText;
        if (Input.IsActionJustPressed("esc"))
        {
            Text = "";
            rect.Visible = false;
            Visible = false;
        }
    }
}