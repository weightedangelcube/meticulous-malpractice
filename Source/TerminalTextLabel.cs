using Godot;

namespace daydream;

[GlobalClass]
public partial class TerminalTextLabel : Label {

    public void Clear() {
        Text = "";
    }

    public void WriteLine(string text) {
        Text += (text + "\n");
    }
    
}