using Godot;
using System;

public partial class Fridge : Node2D {
	private void FridgeTopPressed() {
		var sprite = GetNode("FridgeTopOpenButton/FridgeTopOpenSprite") as Sprite2D;
		sprite.Visible = !sprite.Visible;
	}

	private void FridgeBottomPressed() {
		var sprite = GetNode("FridgeBottomOpenButton/FridgeBottomOpenSprite") as Sprite2D;
		sprite.Visible = !sprite.Visible;
	}
}
