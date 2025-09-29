using System;
using Godot;

namespace daydream.Utils;

public static class Draggable {
	public static bool CheckMouseDown(InputEvent e) {
		if (e.GetType() == typeof(InputEventMouseButton)) {
			if ((e as InputEventMouseButton).ButtonIndex == MouseButton.Left) {
				return e.IsPressed();
			}
		}

		throw new ArgumentNullException();
	}
}
