using Godot;
using System;
using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.factories;
using finalSDP.scripts.visitors;

public partial class HellLevel : LevelBase
{
	private int index = 0;
	TextOption textOption;
	public override string[] Texts { get; set; } = [
		"I am in hell before my death.",
		"Can i call myself as alive?",
		"Well, as Rene Descartes once said, \"I think, therefore i am.\"",
		"I need to kill fire keepers for come back to the bloody island."
		,"And defeat the God of Darkness...",
		"..."
	];

	protected override void OnLevelLoaded()
	{
		Player.GetNode<Movement>("Movement").JumpForce = -440;
		Player.MoveToggle();
		textOption = GetNode<TextOption>("TextOption");
		textOption.NextText += Newator;
	}

	protected override void ConfigureCamera()
	{
		Camera.LimitLeft = 0;
        Camera.LimitRight = 2550;
        Camera.LimitTop = 0;
        Camera.LimitBottom = 825;
	}

	private void Newator()
	{
		index++;

		if (index == 5)
		{
			Player.MoveToggle();
			textOption.playerText.HideText();
		}
	}
	
}
