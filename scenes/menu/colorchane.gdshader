shader_type canvas_item;

uniform vec4 from_color : source_color; 
uniform vec4 to_color   : source_color; 
uniform float threshold = 0.05;         

void fragment() {
    vec4 col = texture(TEXTURE, UV);

    // Проверяем, насколько цвет пикселя близок к исходному
    float diff = distance(col.rgb, from_color.rgb);

    if (diff < threshold) {
        col.rgb = to_color.rgb;
    }

    COLOR = col;
}
