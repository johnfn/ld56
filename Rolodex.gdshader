shader_type canvas_item;

uniform float curvature : hint_range(0.0, 1.0) = 0.2; // Adjustable curvature

void fragment() {
    // Use default UV coordinates to sample texture
    vec2 uv = UV;

    // Apply a simple vertical warp effect based on horizontal position
    uv.y += sin(uv.x * 3.1416) * curvature;

    // Sample the texture using the modified UV coordinates
    COLOR = texture(TEXTURE, uv);
}
