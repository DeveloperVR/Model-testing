using System.Numerics;
using UnityEngine;

public class FunctionLevelCurves : MonoBehaviour
{
    [SerializeField]
    GameObject Plane;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        DrawContactPoints(collision);
    }

    void DrawContactPoints(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            UnityEngine.Vector3 position = contact.point;
            position.y = Plane.transform.position.y; // Set a small height above the ground
            sphere.GetComponent<SphereCollider>().enabled = false; // Disable collider to avoid further collisions
            Debug.Log("Contact point at: " + contact.point);
            sphere.transform.position = position;
        }
    }
}
