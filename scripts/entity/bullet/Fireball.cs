using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.entity.bullet;

public partial class Fireball : Bullet
{
	public override void _Ready()
	{
		Speed = 21;
		Gravity = 6;
		var lal =
		GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			lal.Rotation = Angle.Angle();
			lal.Play();
		base._Ready();
	}

	public override void OnBodyHit(Node body)
	{
		if (body is not Player && body is Entity entity)
		{
			entity.TakeDamage(Damage);
		}
	}
}