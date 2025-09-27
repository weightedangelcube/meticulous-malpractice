using Godot;

namespace daydream;

[GlobalClass]
public partial class TerminalText : TextEdit {
	
	// public void Clear() {
	//     Text = "";
	// }

	public void WriteLine(string text) {
		Text += (text + "\n");
	}
	
	
}
