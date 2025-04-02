using UnityEngine;

public class ModelHeredarEntreMarcadores : MonoBehaviour
{
    private Transform currentTarget; // Image Target actual

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.name + " (Tag: " + other.tag + ")");

        // Verifica si es un Image Target
        if (other.CompareTag("ImageTarget"))
        {
            Debug.Log("✔ Entrando en marcador: " + other.name);

            // Asigna el nuevo marcador como padre si es diferente al actual
            if (currentTarget != other.transform)
            {
                currentTarget = other.transform;
                transform.SetParent(currentTarget);

                // Alinear correctamente
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el modelo sale del marcador actual, mantiene el último Image Target activo
        if (other.CompareTag("ImageTarget") && other.transform == currentTarget)
        {
            Debug.Log("❌ Saliendo de marcador: " + other.name);
            currentTarget = null;
        }
    }
}
