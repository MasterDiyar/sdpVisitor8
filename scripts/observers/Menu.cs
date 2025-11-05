using Godot;
public partial class Menu : Node2D
{
    [Export] private Button _playButton;

    public override void _Ready()
    {
        _playButton.Pressed += JoinToGame;
    }

    void JoinToGame()
    {
        var gameScene = GD.Load<PackedScene>("res://scenes/game.tscn").Instantiate();
        GetParent().AddChild(gameScene);
        QueueFree();
    }
}
