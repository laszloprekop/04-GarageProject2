# Renderer refactoring plan
Uniform 5x6 grid with auto-generated separators

**Date**: 2026-05-22


## New simplified Grid model

Every data cell is exactly 5x6 characters in the rendered garage layout. 
This will simplify the grid model and make it easier to implement the new grid rendering system.

```
abcde·      col 0-3 = sprite content (4 wide)
fghij·      col 4 = right edge padding (·)
klmno·      row 0-4 = sprite content (5 tall)
pqrst·      row 5 = bottom edge padding (·····)
uvwxy·      a-z = sprite graphics
······      · = placeholder character
```

The function of the `·` padding is to have a dedicated a space for the atomatic separator generator to place separator lines, corners, connectors, walls etc.

## Glyphs

- the basic glyph is 5x6 characters, with · baked into the right and bottom edges
- multi-cell glyphs are rendered as a single cell, sides are: multiple of 5 (width) and multiple of 6 (height)
- the content / graphics design of the glyphs fills the spanned area, padding of · characters baked into the right and bottom edges of the full glyphs content, but not at the inner cell edges
- safety: if a glyph is not a perfect multiple of 5x6, spaces are added around the content to match the grid and to center it

## 3-step render pipeline

1. Base render: Garage Blueprint converted to grid model
2. Multi-cell paint: calculate the glyph anchor positions and assign the related/different sized glyph brushes
3. Design separator lines, connectors, roads, walls etc.: based on adjacent cell types, determine which border drawing-, wall-, road characters shall replace the · placeholders in the padding edges

## Affected areas

- Blueprints: remove pre-determined separators, those will be auto-generated

- BuildRenderPlan: cut out dynamic sizing logic of walls, separators, roads, etc.

- docs
