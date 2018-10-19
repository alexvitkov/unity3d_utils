using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public struct Int2 {
	public int x;
	public int y;

	public Int2(int x, int y) {
		this.x = x;
		this.y = y;
	}
	
	public static explicit operator Vector2(Int2 i) {
		return new Vector2(i.x, i.y);
	}

	public static explicit operator Int2(Vector2 v) {
		return new Int2(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
	}

	public override string ToString() {
		return string.Format("(Int2: {0}, {1})", x, y);
	}

	public static Int2 operator +(Int2 a, Int2 b) {
		return new Int2(a.x + b.x, a.y + b.y);
	}

	public static Int2 operator -(Int2 a, Int2 b) {
		return new Int2(a.x - b.x, a.y - b.y);
	}

	public static Int2 operator *(int s, Int2 i) {
		return new Int2(s * i.x, s * i.y);
	}

	public static Int2 operator /(Int2 i, int s) {
		return new Int2(i.x / s, i.y / s);
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Int2))]
public class Int2Drawer : PropertyDrawer {
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		
		// Draw prefix label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Reset indent because Unity
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		// Draw x and y fields
		var xRect = new Rect(position.x, position.y, position.width/2, position.height);
		EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), new GUIContent(""));

		var yRect = new Rect(position.x+position.width/2, position.y, position.width/2, position.height);
		EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), new GUIContent(""));


		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
#endif