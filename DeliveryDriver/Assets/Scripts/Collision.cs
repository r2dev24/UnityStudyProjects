using System;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField]
    Color32 noPackageColor = new Color32(1,1,1,1);

    [SerializeField]
    float destroyDelay = 0.5f;
    bool hasPAckage;

    SpriteRenderer spriteRenderer;

    private void Start() {
        hasPAckage = false;
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = noPackageColor;

        Debug.Log(hasPAckage);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package01" && !hasPAckage) {
            Debug.Log("Package Picked Up");
            hasPAckage = true;

            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPAckage) {
            Debug.Log("Package Delivered");
            hasPAckage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
