shader_type canvas_item;

uniform float mix_amount = 1.0;  // 0 = оригинал, 1 = полностью серый
uniform bool use_threshold = false  ;             // если true -> чисто ч/б (0 или 1)
uniform float threshold = 0.5;    // порог для ч/б
uniform vec3 lum_coeffs = vec3(0.2126, 0.7152, 0.0722); // стандартные Luma coeffs (Rec.709)

void fragment() {
    vec4 src = texture(TEXTURE, UV) * COLOR; // для Control/Label/CanvasItem берём COLOR в учет
    float gray = dot(src.rgb, lum_coeffs);

    if (use_threshold) {
        // step возвращает 0.0 или 1.0; используем smoothstep если нужно сглаживание
        gray = step(threshold, gray);
    }

    vec3 out_rgb = mix(src.rgb, vec3(gray), clamp(mix_amount, 0.0, 1.0));
    COLOR = vec4(out_rgb, src.a);
}
