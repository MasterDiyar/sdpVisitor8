using finalSDP.scripts.entity.enemy;

namespace finalSDP.scripts.strategies;

public interface IBehavior
{
    void Update(AIBehavior context, float[] delta);
}