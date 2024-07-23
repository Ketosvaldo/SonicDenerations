using UnityEngine;

//Esta clase controla todos los controles del jugador. NO TOCAR
public class ControlsInstance : MonoBehaviour
{
    private static ThirdPersonInputs instance;

    public static ThirdPersonInputs Current => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = new ThirdPersonInputs();
    }

    private void OnEnable()
    {
        instance.Enable();
    }

    private void OnDisable()
    {
        instance.Disable();
    }
}
