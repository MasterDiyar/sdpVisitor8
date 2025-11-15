using finalSDP.scripts.entity;
using finalSDP.scripts.entity.enemy;

namespace finalSDP.scripts.factories;
using Godot;

public partial class EnemyFactory : Node2D
{
    [Export] public PackedScene EnemyScene { get; set; }
    [Export] public PackedScene MovementComponentEnemyScene { get; set; }
    public Bolvanchik CreateEnemy()
    {
        var userScene = EnemyScene.Instantiate<Bolvanchik>();
        var p1 = GetParent().GetNode<Marker2D>("SpawnPlayer2");
       
        userScene.GlobalPosition = p1.GlobalPosition;
        GetParent().AddChild(userScene);
        
        return userScene;
    }

    public static Entity CreateUnit(Vector2 position, string type)
    {
        var EntityScene = GD.Load<PackedScene>($"res://scenes/entities/{type}.tscn").Instantiate<Entity>();
        EntityScene.GlobalPosition = position;
        return EntityScene;
    }
      
}