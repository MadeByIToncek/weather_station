using Godot;
using System;
using System.IO;

public partial class LoadImage : TextureRect
{
	[Export]
	private string URL;

	public override void _Ready() {
		HttpRequest req = new();
		AddChild(req);

		req.RequestCompleted += (result, resp_code, headers, body) => {
			Image img = new();
			Error e = img.LoadJpgFromBuffer(body);

			if (e != Error.Ok) {
				throw new Exception(e.ToString());
			}

			ImageTexture tex = ImageTexture.CreateFromImage(img);
			this.Texture = tex;
			GD.Print("Loaded!");
		};

		Error error = req.Request(URL);
		if (error != Error.Ok) {
			throw new IOException("An error occurred in the HTTP request!");
		}
	}
}
