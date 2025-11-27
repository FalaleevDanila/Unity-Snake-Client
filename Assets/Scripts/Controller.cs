using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform _cursor;
    private Camera _camera;
    private Plane _plane;
    
    void Awake()
    {
        _camera = Camera.main;
        _plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveCursor();
        }
    }

    void MoveCursor()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);

        _cursor.position = point;
    }
}
