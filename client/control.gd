extends Control

func _on_gulf_clouds_pressed() -> void:
	Multiplayer.scene_gulf_clouds.rpc_id(1)
	pass # Replace with function body.

func _on_landing_clouds_pressed() -> void:
	Multiplayer.scene_landing_clouds.rpc_id(1)
	pass # Replace with function body.

func _on_orbit_path_pressed() -> void:
	Multiplayer.scene_orbit1.rpc_id(1)
	pass # Replace with function body.

func _on_orbit_path_2_pressed() -> void:
	Multiplayer.scene_orbit2.rpc_id(1)
	pass # Replace with function body.

func _on_adsb_pressed() -> void:
	Multiplayer.scene_adsb.rpc_id(1)
	pass # Replace with function body.
