using Godot;
using System;

public partial class Button : Godot.Button {
	[Export]
	private Camera3D camera;
	public override void _Pressed() {
		Animator a = (Animator)camera;
		a.Next();
		base._Pressed();
	}
}
