using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherStation;
using static Godot.HttpClient;

public partial class FetchTrajectory : Node3D {
	[Export]
	private HttpRequest request;
	[Export]
	private Label label;
	[Export]
	private Node3D orbitParent;

	public List<List<MeshInstance3D>> instances = new();

	public override void _Ready() {
		request.RequestCompleted += (result, response_code, headers, body) => {
			label.Text = "Response " + response_code;
			if (response_code == 200) {
				string json = Encoding.Default.GetString(body);
				dynamic array = JsonConvert.DeserializeObject(json);
				dynamic stages = array[0].data.stageTrajectories;

				DrawCurve(stages[0], Color.Color8(255, 0, 0));
				DrawCurve(stages[1], Color.Color8(0, 0, 255));
				label.Text = "";
			}
		};
		label.Text = "Loading";
		request.Request("https://api.flightclub.io/v3/simulation?simulationId=sim_13z8oh40z", new string[] { "Origin: https://flightclub.io" });
		label.Text = "Downloading";
	}

	private void DrawCurve(dynamic stage, Color c) {
		label.Text = "Processing " + stage.stageNumber;
		List<Vector3> vecs = new List<Vector3>();
		foreach (dynamic telemetryPoint in stage.telemetry) {
			dynamic position = telemetryPoint.x_NI;
			vecs.Add(new(((float)position[0]) / -10000000f, ((float)position[1]) / -10000000f, ((float)position[2]) / -10000000f));
		}

		for (int i = 0; i < vecs.Count - 1; i++) {
			MeshInstance3D line = Draw3D.Line(vecs[i], vecs[i + 1], c);
			orbitParent.AddChild(line);
			if (instances.Count-1 < i) {
				instances.Add(new List<MeshInstance3D>());
			}
			instances[i].Add(line);
		}
	}
}
