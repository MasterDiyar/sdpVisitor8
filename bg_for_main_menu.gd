extends ParallaxBackground

var speed: float = 100.0
var div: float = 0.0

func _ready() -> void:
	var move = get_parent().get_node("Player").get_node("Movement")
	move.connect("on_move", Callable(self, "_on_move"))

func _on_move(delt: float) -> void:
	div = delt

func _process(delta: float) -> void:
	scroll_offset.x += div * speed * delta
