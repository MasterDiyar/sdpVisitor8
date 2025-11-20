using System;
using Godot;

namespace finalSDP.scripts.entity.player;

public partial class TextLabel : Label
{
    [Export] private float LPS = 30f; 
    private float _timeSinceLastChar = 0f; 
    private string _fullText = "";
    private int _charIndex = 0; 
    [Export] private ColorRect _rect; 
    public Action TextFinished; 
    private bool _isPrinting = false;
    public void StartText(string text)
    {
        _fullText = text;
        _charIndex = 0; 
        Text = "";      
        _isPrinting = true;
        
        if (_rect != null) _rect.Visible = true;
        Visible = true;
    }

    public override void _Process(double delta)
    {
        HandleInput();

        if (!_isPrinting)
            return;

        _timeSinceLastChar += (float)delta;
        float timePerChar = 1f / LPS; 

        if (_timeSinceLastChar >= timePerChar)
        {
            _timeSinceLastChar -= timePerChar; 
            
            if (_charIndex < _fullText.Length)
            {
                Text += _fullText[_charIndex];
                _charIndex++;
                
                if (_charIndex >= _fullText.Length)
                    FinishPrinting();
                
            }
        }
    }
    
    private void HandleInput()
    {
        if (_isPrinting && Input.IsActionJustPressed("space"))
        {
            Text = _fullText; 
            FinishPrinting();
            return;
        }

        if (Input.IsActionJustPressed("esc"))
        {
            HideText();
        }
    }
    private void FinishPrinting()
    {
        _isPrinting = false;
        TextFinished?.Invoke(); 
    }
    public void HideText()
    {
        _isPrinting = false;
        Text = "";
        if (_rect != null) _rect.Visible = false;
        Visible = false;
    }
}
