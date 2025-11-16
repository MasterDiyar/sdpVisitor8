namespace finalSDP.scripts.entity.player;
using Godot;


public partial class Player : Entity
{
    public override float MaxHp { get; set; } = 100;
    public override void TakeDamage(float damage)
    {
        Hp -= damage;
        OnHurt?.Invoke(damage);
        if (Hp <= 0) GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://main.tscn"));
        
    }
    
}