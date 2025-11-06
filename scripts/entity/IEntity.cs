using finalSDP.scripts.visitors;

namespace finalSDP.scripts.entity;

public interface IEntity
{
    void Visit(IVisitor visitor);
    
    void TakeDamage(float damage);
    
    void Attack(float angle);

}