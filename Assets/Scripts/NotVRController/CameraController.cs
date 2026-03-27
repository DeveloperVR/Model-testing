using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    public Transform orientation;
    private float xRotation;
    private float yRotation;
    Ray cameraRay;
    LayerMask UILayerMask;

    [SerializeField] Camera cam;
    public InputActionReference PanelButtonDesktop;

    [SerializeField]private MonoBehaviour movementScript;

    void Awake()
    {
        PanelButtonDesktop.action.Enable();
    }
    void Start()
    {
        LockCursor();
        UILayerMask = LayerMask.GetMask("UI");
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraRotation();
        HandleRaycast();
    }

    private void OnEnable()
    {
        PanelButtonDesktop.action.performed += ActivateEscapeKey;
    }
    
    private void OnDisable()
    {
        PanelButtonDesktop.action.performed -= ActivateEscapeKey;
    }

    public void ActivateEscapeKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HandleMenuToggle();
        }
    }

    public void HandleCameraRotation()
    {

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Debug.Log("Cursor is not locked, camera rotation skipped.");
            return;
        }
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public void HandleRaycast()
    {
        
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Debug.Log("Cursor is not locked, Raycast skipped.");
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            cameraRay = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 50f, UILayerMask))
            {
                Debug.Log("Hit: " + hit.collider.name);

                UnityEngine.UI.Button button = hit.collider.GetComponent<UnityEngine.UI.Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                    Debug.Log("Button clicked: " + button.name);
                }

                UnityEngine.UI.InputField inputField = hit.collider.GetComponent<UnityEngine.UI.InputField>();
                if (inputField != null)
                {
                    inputField.ActivateInputField();
                    inputField.Select();
                    Debug.Log("InputField selected: " + inputField.name);
                }
                TMPro.TMP_InputField tmpInput = hit.collider.GetComponent<TMPro.TMP_InputField>();
                if (tmpInput != null)
                {
                    PointerEventData pointer = new PointerEventData(EventSystem.current);
                    pointer.pointerPressRaycast = new RaycastResult { gameObject = tmpInput.gameObject };

                    tmpInput.OnPointerClick(pointer);
                    tmpInput.Select();
                    tmpInput.ActivateInputField();

                    Debug.Log("TMP_InputField Selected");
                }
            }
        }

    }

    public void HandleMenuToggle()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movementScript.enabled = true;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        movementScript.enabled = false;
    }
        
}
