using Godot;

namespace daydream;

[GlobalClass]
public partial class Draggable : Control {
	private bool mouseDown = false;

	private void OnInput(InputEvent e) {
		if (e.GetType() == typeof(InputEventMouseButton)) {
			if ((e as InputEventMouseButton).ButtonIndex == MouseButton.Left) {
				mouseDown = e.IsPressed();
			}
			
		}
	}

	public override void _Process(double delta) {
		if (mouseDown) {
			Position = GetViewport().GetMousePosition();
		}
	}
}
