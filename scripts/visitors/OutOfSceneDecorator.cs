using finalSDP.scripts.entity;
using Godot;
using Godot.Collections;

namespace finalSDP.scripts.visitors;

public class OutOfSceneVisitor : IVisitor
{
    public void GetALlMobs(Array<Node> nodes)
    {
        foreach (var node in nodes)
            if (node is Entity ent)
                ent.Visit(this);
    }

    public void Visit(Entity entity)
    {
        if (entity.Position.Y > 1500) entity.QueueFree();
    }
}