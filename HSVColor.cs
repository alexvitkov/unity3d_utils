using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct HSVColor {
	public float h, s, v, a;

	public HSVColor(Color color) {
		Color.RGBToHSV(color, out h, out s, out v);
		this.a = color.a;
	}

	public HSVColor(float h, float s, float v, float a = 1) {
		this.h = h;
		this.s = s;
		this.v = v;
		this.a = a;
	}

	public static implicit operator Color(HSVColor hsvCol) {
		Color rgbColor = Color.HSVToRGB(hsvCol.h, hsvCol.s, hsvCol.v);
		rgbColor.a = hsvCol.a;
		return rgbColor;
	}

	public static explicit operator HSVColor(Color rgbCol) {
		return new HSVColor(rgbCol);
	}
	public override string ToString() {
		return string.Format(
			"HSVA({0}, {1}, {2}, {3})", 
			h.ToString("0.000"), 
			s.ToString("0.000"), 
			v.ToString("0.000"), 
			a.ToString("0.000")
		);
	}

	// TODO
	// hue will lerp from 0.1 to 0.9 like this: .1->.15->...->.85->.95
	// should be able to go like this: .1->.05->0->.95->.9
	// LerpAngle has similar functionality, can use that
	// maybe later
	public static HSVColor Lerp(HSVColor col1, HSVColor col2, float t) {
		return new HSVColor(
			Mathf.Lerp(col1.h, col2.h, t),
			Mathf.Lerp(col1.s, col2.s, t),
			Mathf.Lerp(col1.v, col2.v, t),
			Mathf.Lerp(col1.a, col2.a, t)
		);
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(HSVColor))]
public class HSVColorDrawerDrawer : PropertyDrawer {
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);

		// Draw prefix label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Reset indent because Unity
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		var hProp = property.FindPropertyRelative("h");
		var sProp = property.FindPropertyRelative("s");
		var vProp = property.FindPropertyRelative("v");
		var aProp = property.FindPropertyRelative("a");

		float h = hProp.floatValue;
		float s = sProp.floatValue;
		float v = vProp.floatValue;
		float a = aProp.floatValue;

		Color rgbCol = Color.HSVToRGB(h, s, v);
		rgbCol.a = a;
		rgbCol = EditorGUI.ColorField(position, rgbCol);
		Color.RGBToHSV(rgbCol, out h, out s, out v);
		
		hProp.floatValue = h;
		sProp.floatValue = s;
		vProp.floatValue = v;
		aProp.floatValue = a;

		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
#endif
