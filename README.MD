# ???
unity3D scripts

## Int2.cs
serialziable int tuple struct + unityeditor propertydrawer class for it.

## HSVColor.cs
hsv color, operators to convert to unity's rgb float-based color & static method that lerps based on hsv rather than rgb (broken :D) + unityeditor propertydrawer for it

## ColorExtensions.cs
functions to quickly modify colors.
instead of
```C#
Color c = spriteRenderer.color;
c.a = .5f
spriteRenderer.color = c;
```
you can do
```C#
spriteRenderer.color = spriteRenderer.color.WithAlpha(.5f);
```

## TransformExtensions2D
functions for quickly rotating transforms over the Z axis and uniformly scaling them, useful for 2D.
