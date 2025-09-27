using Godot;
using System;
using Godot.Collections;

public partial class Terminal : Node2D {
	private Array<Node> _children;
	private RichTextLabel _terminalText;
	public override void _Ready() {
		_children = GetChildren();
		foreach (var child in _children) {
			if (child.Name.ToString().Equals)
			child.Name.ToString().Equals("Terminal") ? _terminalText = child as RichTextLabel : throw new Exception("");
		}
		_terminalText = _children.
	}

	public void UpdateText(string text) {
		
	}
	public void InitGame() {
		
	}
}
