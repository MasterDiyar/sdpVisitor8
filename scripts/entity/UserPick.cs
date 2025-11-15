using Godot;
using System;
using System.Linq;
using finalSDP.scripts.decorators;
using finalSDP.scripts.entity.enemy;
using finalSDP.scripts.factories;
using finalSDP.scripts.weapon;

public partial class UserPick : Control
{
	private AnimatedSprite2D anim, mobAnim;
	private ColorPicker picker;
	private CheckBox checkbox;
	private HSlider weaponSlider, difficultySlider;
	private VSlider mobTypeSlider;
	private Sprite2D weaponSprite;
	private Button PlayButton;

	private int weaponIndex = 0, mobTypeIndex = 0, difficultyIndex = 0;
	private string[] weaponPath = ["res://assets/bullets/catana.png", "res://assets/player/attack/bow1.png","res://assets/player/attack/poison1.png"],
		mobTypeName = ["golem", "mushroom", "firegolem", "bolvanchik", "agis"];
	private Texture2D[] weaponTexture;

	private CheckButton[] decorators;
	public override void _Ready()
	{
		checkbox = GetNode<CheckBox>("CheckBox");
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		mobAnim = GetNode<AnimatedSprite2D>("Enemy/AnimatedSprite2D");
		picker = GetNode<ColorPicker>("ColorPicker");
		weaponSlider = GetNode<HSlider>("HSlider");
		difficultySlider = GetNode<HSlider>("Enemy/HSlider");
		mobTypeSlider = GetNode<VSlider>("Enemy/VSlider");
		weaponSprite = GetNode<Sprite2D>("Weapon");
		decorators = Enumerable.Range(1, 4).Select(i => GetNode<CheckButton>($"VBoxContainer/CheckButton{i}")).ToArray();
		PlayButton = GetNode<Button>("Button");
		
		weaponTexture = weaponPath.Select(GD.Load<Texture2D>).ToArray();
		
		anim.Play();
		PlayButton.Pressed += PlayButtonOnPressed;
		picker.ColorChanged+= PickerOnColorChanged;
		checkbox.Pressed += CheckboxOnPressed;
		difficultySlider.ValueChanged += value => difficultyIndex = (int)value;
		mobTypeSlider.ValueChanged += MobTypeSliderOnValueChanged;
		weaponSlider.ValueChanged+= WeaponSliderOnValueChanged;
	}

	private void PlayButtonOnPressed()
	{
		var weaponCon = new Func<Weapon>[] {
			WeaponFactory.CreateCatana,
			WeaponFactory.CreateBow,
			WeaponFactory.CreateSpray
		};

		var decoratorFact = new Func<Weapon, Weapon>[] {
			w => new DoubleSizeWeaponDecorator(w),
			w => new PoisonousAttackWeaponDecorator(w),
			w => new RandomAttackWeaponDecorator(w),
			w => new KnockBackWeaponDecorator(w)
		};
		var givenWeapon = weaponCon[weaponIndex]();

		for (int i = 0; i < decorators.Length; i++) {
			if (decorators[i].IsPressed())
				givenWeapon = decoratorFact[i](givenWeapon);
		}

		if (checkbox.ButtonPressed)
		{
			var map = GD.Load<PackedScene>("res://scenes/levels/first_scene.tscn").Instantiate<Node2D>();
			var user = UserFactory.CreatePlayer(new Vector2(100, 100));
			user.Material = anim.Material;
			
			map.AddChild(user);
			user.AddChild(givenWeapon);
			
			GetParent().AddChild(map);
			QueueFree();
		}
		else
		{
			var map = GD.Load<PackedScene>("res://scenes/levels/level.tscn").Instantiate<Node2D>();
			var user = UserFactory.CreatePlayer(new Vector2(100, 100));
			user.Material = anim.Material;
			
			var mob = EnemyFactory.CreateUnit(new Vector2(400, 100), mobTypeName[mobTypeIndex]);
			mob.GetNode<AIBehavior>("aibehavior").MyTactic = (AIBehavior.Tactic)difficultyIndex;
			
			map.AddChild(user);
			map.AddChild(mob);
			user.AddChild(givenWeapon);
			
			GetParent().AddChild(map);
			QueueFree();
		}
	}

	private void CheckboxOnPressed()
	{
		GetNode<Control>("Enemy").Visible = !checkbox.ButtonPressed;
	}

	private void MobTypeSliderOnValueChanged(double value)
	{
		mobTypeIndex = (int)value;
		mobAnim.Play($"new_animation_{mobTypeIndex}");
		mobAnim.Scale = Vector2.One * (mobTypeIndex == 4 ? 3 : 7);
	}

	private void WeaponSliderOnValueChanged(double value)
	{
		weaponIndex = (int)value;
		weaponSprite.Texture = weaponTexture[weaponIndex];
	}

	private void PickerOnColorChanged(Color color)
	{
		if (anim.Material is ShaderMaterial mot) {
			mot.SetShaderParameter("to_color", color);
		}
	}
}
