using Godot;
using System;
using System.Linq;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] CpuParticles2D particles2D;
	public override void _Process(double delta)
	{
		particles2D.Emitting = AllInputCheck(["a", "w", "d"]);
		Play((particles2D.Emitting) ? "run" : "idle");
	}

	public static bool AllInputCheck(string[] inputs)
		=> inputs.Aggregate(false, (current, input) => current | Input.IsActionPressed(input));
	
}
