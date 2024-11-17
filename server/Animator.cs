using Godot;
using System;
using System.Collections.Generic;

public partial class Animator : Camera3D {
	[Export]
	private Node3D trajectoryScene;


	List<Keyframe> keyframes = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		keyframes.Add(new Keyframe(new Vector3(-0.316f, 0.215f, 0.323f), new Vector3(60.2f, -69.2f, -23.7f),true, 0));
		keyframes.Add(new Keyframe(new Vector3(-0.321f, 0.203f, 0.332f), new Vector3(60.2f, -69.2f, -23.7f), true, 333));
		keyframes.Add(new Keyframe(new Vector3(-0.316f, 0.215f, 0.323f), new Vector3(60.2f, -69.2f, -23.7f), true, 595));
		keyframes.Add(new Keyframe(new Vector3(-0.315f, 0.223f, 0.399f), new Vector3(-4.3f, -47.4f, -11.6f), true, 596));
		keyframes.Add(new Keyframe(new Vector3(-0.043f, 0.157f, 0.646f), new Vector3(2.8f, -14.1f, -12f), false, 1163));
		keyframes.Add(new Keyframe(new Vector3(-0.277f, 0.046f, 0.652f), new Vector3(8.3f, 18.6f, -7.7f), false, 1594));
		keyframes.Add(new Keyframe(new Vector3(-0.277f, 0.046f, 0.652f), new Vector3(8.3f, 18.6f, -7.7f), false, 2136));
		Position = keyframes[0].position;
		RotationDegrees = keyframes[0].rotation;
	}

	float t = 0;
	long targetT = 4;
	int idx = 0;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		t += (float)delta;
		GD.Print(targetT + "," + t);
		if (t >= targetT) {
			GD.Print("Right place");
			Position = keyframes[idx+1].position;
			RotationDegrees = keyframes[idx+1].rotation;
			return;
		} else if(keyframes.Count <= idx+1) {
			return;
		} else {
			Position = keyframes[idx].position.Lerp(keyframes[idx+1].position, t/4);
			RotationDegrees = keyframes[idx].rotation.Lerp(keyframes[idx+1].rotation, t/4);
		}
	}

	public void Next() {
		if (idx + 1 < keyframes.Count) {
			t = 0;
			idx++;
			//targetT = DetermineTargetT(idx);
		}
	}

	private long DetermineTargetT(int idx) {
		long result = 1;
		for (int i = 0; i < keyframes.Count; i++) {
			if (i < idx) continue;
			if (keyframes[i].stop) break;
			else result++;
		}

		return result;
	}

	private record Keyframe(Vector3 position, Vector3 rotation, bool stop, int simFrame) {

	}
}
