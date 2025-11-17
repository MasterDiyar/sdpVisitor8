using Godot;
using System;
using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.visitors;

public partial class HellLevel : Node2D
{
	private Player pl;
	private TextLabel la;
	private int index = 0;
	private string[] texts = ["Hello my dear gayman i am your shugar daddy:)\n but im not gay. Yall should now about that",
		"RegularCustomerDiscount, MemberCustomerDiscount, PremiumCustomerDiscount (Concrete Strategies):\nThese classes implement IDiscountStrategy and provide specific implementations for calculating discounts based on different customer types.",
	"ShoppingCart (Context Class):\nThis class holds a reference to the IDiscountStrategy interface. It delegates the discount calculation to the currently assigned strategy. The SetDiscountStrategy method allows changing the strategy at runtime.",
	"Program (Client Usage):\nThe client code creates ShoppingCart instances, injecting the desired IDiscountStrategy at creation or dynamically changing it later, demonstrating the flexibility of the pattern."
	];
	public override void _Ready()
	{
		OutOfSceneVisitor sceneVisitor = new OutOfSceneVisitor();
		pl = GetNode<Player>("Player");
		pl.GetNode<Movement>("Movement").JumpForce = -440;
		var camera = pl.GetNode<Camera2D>("Camera2D");

		camera.LimitLeft = 0;
		camera.LimitRight = 2550;
		camera.LimitTop = 0;
		camera.LimitBottom = 825;

		la =GetNode<TextLabel>("Player/Camera2D/HpInspector/razgovor");
		la.StartText(texts[index]);
		
		var	mA = GetNode<MovementAdapter>("/root/MovementAdapter");
		pl.Material = mA.playerColor;
		pl.AddChild(mA.savedWeapon);
	}

	public override void _Process(double delta)
	{
		
			
	}
}
