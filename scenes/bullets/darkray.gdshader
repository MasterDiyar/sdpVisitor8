shader_type canvas_item;

uniform float speed : hint_range(0.0, 5.0) = 1.0;
uniform float line_width : hint_range(0.0, 0.2) = 0.15;
uniform vec4 line_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform float repeat_distance : hint_range(0.5, 4.0) = 2.0;
uniform int pixelate_line : hint_range(0, 1) = 1;

// --- Новые uniform для свечения ---
uniform vec4 glow_color : source_color = vec4(0.8, 0.9, 1.0, 0.5); // Цвет свечения (голубоватый по умолчанию)
uniform float glow_intensity : hint_range(0.0, 2.0) = 0.5; // Интенсивность свечения
uniform float glow_spread : hint_range(0.0, 0.5) = 0.1; // Насколько широко распространяется свечение от линии

void fragment() {
    vec4 base_texture = texture(TEXTURE, UV);
    
    // Пропустить полностью прозрачные пиксели
    if (base_texture.a < 0.01) {
        discard;
    }
    
    // Непрерывное зацикливание позиции линии
    float line_pos_raw = TIME * speed;
    float line_position = mod(line_pos_raw, repeat_distance);
    
    vec2 uv_for_line = UV;
    
    // Пикселизация расчета линии
    if (pixelate_line == 1) {
        vec2 texture_size = 1.0 / TEXTURE_PIXEL_SIZE;
        uv_for_line = floor(UV * texture_size) / texture_size;
    }
    
    // Диагональное вращение UV
    float diagonal_uv = (uv_for_line.x + uv_for_line.y) * 0.5;

    // Сдвигаем диагональное UV с учетом времени
    float dist_mod = mod(diagonal_uv - line_position, repeat_distance);
    
    // "Заворачиваем" расстояние, чтобы получить симметричную полосу
    float dist_from_line = min(dist_mod, repeat_distance - dist_mod);
    
    // Интенсивность самой линии
    float line_intensity = smoothstep(line_width * 0.5, 0.0, dist_from_line);

    // --- Расчет эффекта свечения ---
    // Свечение будет более широким и плавным, чем сама линия
    // Мы используем dist_from_line, но с более широким "разбросом"
    float current_glow_spread = line_width * 0.5 + glow_spread; // Расширяем область свечения
    float glow_amount = smoothstep(current_glow_spread, 0.0, dist_from_line);
    
    // Смешиваем основной цвет (который будет включать свечение) с цветом текстуры
    vec3 mixed_color = base_texture.rgb;

    // Применяем свечение: чем дальше от линии, тем меньше свечения
    // Умножаем glow_color.rgb на glow_amount и glow_intensity, затем добавляем к mixed_color
    // Мы также используем альфа-канал glow_color для его прозрачности
    mixed_color += glow_color.rgb * glow_amount * glow_intensity * glow_color.a;
    
    // Накладываем цвет линии поверх всего остального, если это не полностью прозрачный пиксель линии
    // Используем line_intensity, чтобы плавно переходить к line_color
    // Это гарантирует, что сама линия будет четкой, а свечение будет вокруг нее
    mixed_color = mix(mixed_color, line_color.rgb, line_intensity * line_color.a);
    
    // Сохранение оригинального альфа-канала
    COLOR = vec4(mixed_color, base_texture.a);
}