extends Control

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var os = OS.get_name();
	if(os == "Windows"):
		print_debug("Starting control server");
		Multiplayer.startServer(func(text): $ServerStatus.text = text);
	else:
		print_debug("Starting mobile system")
		get_tree().change_scene_to_file("res://client/connect.tscn")
	pass
