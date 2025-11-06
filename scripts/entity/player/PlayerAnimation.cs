using Godot;
using System;
using System.Linq;
using finalSDP.scripts.entity.player;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] CpuParticles2D particles2D;
	private Player parent;
		
	public override void _Ready()
		=> parent = GetParent<Player>();
	public override void _Process(double delta)
	{
		particles2D.Emitting = AllInputCheck(["a", "w", "d"]) && parent.IsOnFloor();
		Play((particles2D.Emitting) ? "run" : "idle");
	}

	public static bool AllInputCheck(string[] inputs)
		=> inputs.Aggregate(false, (current, input) => current | Input.IsActionPressed(input));
	
}
