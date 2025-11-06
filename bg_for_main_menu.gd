extends ParallaxBackground

var speed = 100


func _process(delta: float):
	scroll_offset.x -= speed * delta 
	
	
