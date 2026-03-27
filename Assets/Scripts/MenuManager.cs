using Unity.VisualScripting;
using UnityEngine;
using thread = System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField]private float spawnDistance = 2;
    [SerializeField] private Transform canvas;

    private void Start()
    {
        SetActive();
    }

    private void Update() 
    {
        // el canvas siempre mira al usuario.
        canvas.transform.LookAt(new Vector3(head.position.x, canvas.transform.position.y, head.position.z));
        canvas.transform.forward *= -1;
           
    }
    async public void SetActive()
    {
        await thread.Task.Delay(500);
        canvas.gameObject.SetActive(true);

        canvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        canvas.transform.LookAt(new Vector3(head.position.x, canvas.transform.position.y + 2, head.position.z));
        canvas.transform.forward *= -1; 
    }
}
