using UnityEngine;

public class MouseLook : MonoBehaviour {

    public Vector2 sensitivity = new Vector3(50, 65);
    public float smooth = 5;

    public Transform body = null;
    public Transform head = null;

    private Vector2 angles, currentAngles;
    
    void Start() {
        if (body == null) body = transform;
        if (head == null) head = GetComponentInChildren<Camera>().transform;
    }

    void Update() {
        angles.x += Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        angles.y -= Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;
        angles.y = Mathf.Clamp(angles.y, -90f, 90f);

        if (smooth > 0) {
            currentAngles.x = Mathf.LerpAngle(currentAngles.x, angles.x, smooth * Time.deltaTime);
            currentAngles.y = Mathf.LerpAngle(currentAngles.y, angles.y, smooth * Time.deltaTime);
        }
        else {
            currentAngles = angles;
        }

        body.localEulerAngles = new Vector3(0f, currentAngles.x, 0f);
        head.localEulerAngles = new Vector3(currentAngles.y, 0f, 0f);
    }
}
