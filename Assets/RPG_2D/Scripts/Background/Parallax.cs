using UnityEngine;
public class Parallax : MonoBehaviour
{
    [SerializeField] private float speedLayer;
    private Camera mainCam;
    private Vector3 startPos;

    private void Start()
    {
        mainCam = Camera.main;
        startPos = mainCam.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 position = startPos;
        position += speedLayer * (mainCam.transform.position - startPos);
        position.z = 0;
        transform.position = position;
    }

}

