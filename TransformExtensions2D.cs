using UnityEngine;

public static class TransformExtensions2D {

	public static void SetScale(this Transform t, float scale) {
		t.localScale = new Vector3(scale, scale, 1f);
	}

	public static float GetScale(this Transform t)
		=> t.localScale.x;

	public static void SetRotation(this Transform t, float angleDeg) {
		t.localEulerAngles = new Vector3(0f, 0f, angleDeg);
	}

	public static float GetRotation(this Transform t)
		=> t.eulerAngles.z;

	public static void LookAt2D(this Transform t, Vector3 point) {
		Vector3 dir = point - t.position;
		float angleRad = Mathf.Atan2(dir.y, dir.x);
		t.SetRotation(angleRad * Mathf.Rad2Deg);
	}

}
