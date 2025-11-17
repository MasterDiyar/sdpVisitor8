using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;

namespace finalSDP.scripts.factories;
using Godot;


public partial class MountainScene : Node2D
{
    private Player pl;
    public override void _Ready()
    {
        pl = GetNode<Player>("Player");
        var camera = pl.GetNode<Camera2D>("Camera2D");

        camera.LimitLeft = 0;
        camera.LimitRight = 3830;
        camera.LimitTop = 0;
        camera.LimitBottom = 1053;
        var	mA = GetNode<MovementAdapter>("/root/MovementAdapter");
        pl.Material = mA.playerColor;
        pl.AddChild(mA.savedWeapon);
    }
}
