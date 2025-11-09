using finalSDP.scripts.entity.enemy;
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
      
}