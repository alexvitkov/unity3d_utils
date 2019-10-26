using UnityEngine;

public class MouseLook : MonoBehaviour {

    public Vector2 sensitivity = new Vector3(50, 65);
    public float smooth = 5;

    public Transform body, head;
    private Vector2 angles;
    
    void Start() {
        if (body == null) body = transform;
        if (head == null) head = GetComponentInChildren<Camera>().transform;
    }

    void Update() {
        angles.x += Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime;
        angles.y -= Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;
        angles.y = Mathf.Clamp(angles.y, -90f, 90f);

        Vector3 ang = body.localEulerAngles;

        if (smooth > 0) {
            ang.x = Mathf.LerpAngle(ang.x, angles.x, smooth * Time.deltaTime);
            ang.y = Mathf.LerpAngle(ang.y, angles.y, smooth * Time.deltaTime);
        }
        else {
            ang = angles;
        }

        body.localEulerAngles = new Vector3(0f, ang.x, 0f);
        head.localEulerAngles = new Vector3(ang.y, 0f, 0f);
    }
}
