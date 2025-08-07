using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    public Transform Camera;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 0.125f;

    // LateUpdate se llama una vez por frame, después de que todos los Updates hayan sido llamados.
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Error - Objetivo no Asignado");
        }
        Vector3 desiredPosition = new Vector3(target.position.x + Camera.position.x, Camera.position.y, offset.z);
        // Usamos Lerp (interpolación lineal) para mover la cámara suavemente desde su posición actual hacia la posición deseada.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // Opcional: Hacer que la cámara mire siempre al objetivo. Esto es útil si quieres que la cámara siempre apunte al personaje.
        // Puedes comentar esta línea si prefieres que la cámara mantenga su rotación original.
        //transform.LookAt(target);
    }
}