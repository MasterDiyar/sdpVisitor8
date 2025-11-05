using Godot;
using System;
using System.Linq;

public partial class PlayerAnimation : AnimatedSprite2D{

	public override void _Process(double delta)
		=>
		Play(AllInputCheck(["a", "w", "d"]) ? "run" : "idle");
	

	public static bool AllInputCheck(string[] inputs)
		=> inputs.Aggregate(false, (current, input) => current | Input.IsActionPressed(input));
	
}
