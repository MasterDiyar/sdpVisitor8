namespace finalSDP.scripts.factories;
using Godot;

public partial class MountainScene : Node2D
{

    public override void _Ready()
    {
        var camera = GetNode<Camera2D>("Camera2D");

        camera.LimitLeft = 0;
        camera.LimitRight = 2550;
        camera.LimitTop = 0;
        camera.LimitBottom = 825;
    }
}
