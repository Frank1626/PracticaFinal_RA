using UnityEngine;

public class ModelColliderProximityController : MonoBehaviour
{
    public GameObject panelOverlay; // Arrastra el PanelOverlay desde la jerarquía

    void Start()
    {
        if (panelOverlay != null)
        {
            panelOverlay.SetActive(false); // Asegurar que inicia oculto
        }
        else
        {
            //Debug.LogError("❌ PanelOverlay no está asignado en el script.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("🚀 Algo entró en el trigger: " + other.gameObject.name);

        if (other.CompareTag("Modelo"))
        {
            //Debug.Log("✔ Activando PanelOverlay.");
            panelOverlay.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Modelo"))
        {
            //Debug.Log("❌ Desactivando PanelOverlay.");
            panelOverlay.SetActive(false);
        }
    }
}
