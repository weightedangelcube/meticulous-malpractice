using Godot;

namespace daydream;

public partial class Menu : Node {
    public override void _Process(double delta) {
        if (Input.IsActionPressed("ui_menu_return")) {
            CallDeferred(MethodName.DeferredExitToMenu);
        }
    }

    public void DeferredExitToMenu() {
        GetTree().ChangeSceneToFile("res://Source/MainScene.tscn");
    }
}