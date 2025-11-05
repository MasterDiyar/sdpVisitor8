using Godot;
using System;
using finalSDP.scripts.visitors;

public partial class Main : Node2D
{
    private DebugVisitor _debugVisitor =  new DebugVisitor();

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.Pressed)
                _debugVisitor.GetALlMobs(GetChild(0).GetChildren());
        }
    }
}
