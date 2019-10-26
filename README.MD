# What is this
Unity scripts that I've needed more than once. most of these use c# 6+ feautes

## Int2.cs
Serialziable int tuple struct and a nice UnityEditor property drawer to go with it.

## HSVColor.cs
HSV color, property drawer for it, and operators to convert between it and Unity's Color class.

## ColorExtensions.cs
Functions to quickly modify colors.
Instead of
```C#
Color c = spriteRenderer.color;
c.a = .5f
spriteRenderer.color = c;
```
you can now do
```C#
spriteRenderer.color = spriteRenderer.color.WithAlpha(.5f);
```

## TransformExtensions2D
Functions for quickly rotating transforms over the Z axis and uniformly scaling them, useful for 2D.

## FlyCamera
A very basic fly camera, about as basic as they come. Unity has their own which but this one is like 20 lines so it's easier to extend.

## VectorExtensions
Extension methods for quickly modifying vectors.
```C#
Vector3 pos = transform.position;
pos.x = 100;
transform.position = pos;
```
becomes
```C#
transform.position = transform.position.WithX(100);
```

## MouseLook
A mouse look script! This one supports smooth mouse scrolling.
