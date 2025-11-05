using Godot;
using System;
using finalSDP.scripts.visitors;

public partial class Main : Node2D
{
    private DebugVisitor _debugVisitor =  new DebugVisitor();
    

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("o"))
            _debugVisitor.GetALlMobs(GetChild(0).GetChildren());
        
    }
}
