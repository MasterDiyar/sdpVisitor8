using finalSDP.scripts.entity.player;

namespace finalSDP.scripts.factories;
using Godot;
public partial class UserFactory : Node2D
{
    [Export] public PackedScene PlayerScene { get; set; }
    [Export] public PackedScene MovementComponentScene { get; set; }
    public Player CreateUser()
    {
        var userScene = PlayerScene.Instantiate<Player>();
        var p1 = GetParent().GetNode<Marker2D>("SpawnPlayer");
        var move = MovementComponentScene.Instantiate<Movement>();
       
        userScene.GlobalPosition = p1.GlobalPosition;
        GetParent().AddChild(userScene);
        userScene.AddChild(move);
        
        move.Body = userScene;
        return userScene;
    }

    public static Player CreatePlayer(Vector2 position)
    {
        var userScene = GD.Load<PackedScene>("res://scenes/player/player.tscn").Instantiate<Player>();
        userScene.GlobalPosition = position;
        
        return userScene;
    }
}