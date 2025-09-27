using Godot;
using System;

public partial class Main : Node {
	private Node _terminal;
	public override void _Ready() {
		foreach (Node child in GetChildren()) {
			if (child.Name == "Terminal") {
				_terminal = child;
			}
		}
		
		
	}
}
