using Godot;
using System;

public partial class Fridge : Node2D {
	private void FridgeTopPressed() {
		var sprite = GetNode("FridgeTopOpenSprite") as Sprite2D;
		sprite.Visible = !sprite.Visible;
	}

	private void FridgeBottomPressed() {
		var sprite = GetNode("FridgeBottomOpenSprite") as Sprite2D;
		sprite.Visible = !sprite.Visible;
	}
}
