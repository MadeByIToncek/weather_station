extends Control


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass



func _on_button_pressed() -> void:
	var address = $Address.text;
	var port = int($Port.text);
	
	Multiplayer.connectRemote(address, port);
	pass # Replace with function body.