using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitmarker : MonoBehaviour
{
    public GameObject laserPrefab;
    public Camera mainCamera;
    public GameObject objectToClone;
    public float maxRange = 50f;
    public float destroyDelay = 10f; // Zeit in Sekunden, nach der das Objekt gelöscht wird

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRange))
        {
            if (hit.collider.CompareTag("AnderesObjektTag"))
            {
                Debug.Log("Laser hat ein anderes Objekt berührt!");

                if (objectToClone != null)
                {
                    GameObject newObject = Instantiate(objectToClone, hit.point, Quaternion.identity);

                    // Starte den Timer zum Löschen des Objekts nach der definierten Zeit
                    StartCoroutine(DestroyObjectAfterDelay(newObject, destroyDelay));
                }
            }
        }
        else
        {
            Debug.Log("Laser hat kein Objekt innerhalb der Reichweite getroffen.");
        }

        if (laserPrefab != null)
        {
            Instantiate(laserPrefab, hit.point, Quaternion.identity);
        }
    }

    IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        // Warte die angegebene Zeit
        yield return new WaitForSeconds(delay);

        // Zerstöre das GameObject
        Destroy(obj);
    }
}
