using finalSDP.scripts.entity.player;
using finalSDP.scripts.entity.enemy;

namespace finalSDP.scripts.factories;
using Godot;
public partial class FirstScene : Node2D
{
    private Player pl;
    private Bolvanchik bolvanchik;

    public override void _Ready()
    {
        var factory =  GetNode<UserFactory>("UserFactory");
        var factory2 = GetNode<EnemyFactory>("EnemyFactory");
        pl = factory.CreateUser();
        bolvanchik = factory2.CreateEnemy();
        var camera = pl.GetNode<Camera2D>("Camera2D");
        camera.LimitLeft = 0;
        camera.LimitRight = 1500;
        camera.LimitTop = 0;
        camera.LimitBottom = 900;
    }
}