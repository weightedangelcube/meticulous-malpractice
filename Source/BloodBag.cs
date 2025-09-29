using System;
using Godot;

namespace daydream;

public partial class BloodBag : Control {
	private bool mouseDown;
	private Vector2 offset;
	
	private void OnInput(InputEvent e) {
		mouseDown = Utils.Draggable.CheckMouseDown(e);
		offset = GetLocalMousePosition();
	}

	public override void _Process(double delta) {
		if (mouseDown) {
			Position = (GetViewport().GetMousePosition() - offset) / new Vector2(0.6f, 0.6f);
		}
	}

	// public override Variant _GetDragData(Vector2 atPosition) {
	// 	// return Variant.From(new BloodSample(new Random().Next(2) >= 1));
	// }

	public override void _DropData(Vector2 atPosition, Variant data) {
		
	}
}
