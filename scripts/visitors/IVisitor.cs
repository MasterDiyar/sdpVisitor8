using finalSDP.scripts.entity;

namespace finalSDP.scripts.visitors;

public interface IVisitor
{
    public void Visit(Entity entity);
}