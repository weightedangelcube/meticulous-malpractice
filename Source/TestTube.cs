using Godot;
using daydream;

namespace daydream;

public partial class TestTube : Control {
	private bool mouseDown;
	private Vector2 offset;
	
	private void OnInput(InputEvent e) {
		mouseDown = Utils.Draggable.CheckMouseDown(e);
		offset = GetLocalMousePosition();
	}

	public override void _Process(double delta) {
		if (mouseDown) {
			Position = GetViewport().GetMousePosition() - offset;
		}
	}
}
