extends Node2D

var peer = ENetMultiplayerPeer.new()
@export_node_path("Label") var label;

func startServer(log_consumer:Callable):
	peer.create_server(4567)
	multiplayer.multiplayer_peer = peer
	log_consumer.call("Server running; waiting for client!")
	
func connectRemote(address: String = "localhost", port:int = 4567): 
	peer.create_client(address,port)
	multiplayer.multiplayer_peer = peer
	get_tree().change_scene_to_file("res://client/control.tscn");
	
@rpc("any_peer","call_remote","reliable")
func connectionReady():
	$ServerStatus.text = ""
	
@rpc("any_peer","call_remote","reliable")
func scene_gulf_clouds():
	get_tree().change_scene_to_file("res://server/gulf.tscn")
	
@rpc("any_peer","call_remote","reliable")
func scene_landing_clouds():
	get_tree().change_scene_to_file("res://server/landing_area.tscn")
	
@rpc("any_peer","call_remote","reliable")
func scene_orbit1():
	get_tree().change_scene_to_file("res://server/fulldisk1.tscn")
	
@rpc("any_peer","call_remote","reliable")
func scene_orbit2():
	get_tree().change_scene_to_file("res://server/fulldisk2.tscn")
	
@rpc("any_peer","call_remote","reliable")
func scene_adsb():
	get_tree().change_scene_to_file("res://server/radar.tscn")
