using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineBrain cinema;
    void Start()
    {
        cinema = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinema.enabled = !cinema.enabled;
        }
    }
}
