using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    private Animator bowAnimator;
    //public InventorySysteme inventory;
    public string arrowItemName = "Arrow";
    private bool isDrawing = false;

    public string arrowPrefabPath = "Arrow";

    private GameObject arrowPrefab;
    public Transform spawnPosition;

    public float shootingForce = 100;

    void Start()
    {
        bowAnimator = GetComponent<Animator>();
        LoadArrowPrefab();
    }

    private void LoadArrowPrefab()
    {
        arrowPrefab = Resources.Load<GameObject>(arrowPrefabPath);

        if(arrowPrefab == null)
        {
            Debug.LogError("Arrow prefab not found at path: " + arrowPrefabPath);
        }
    }

    void Update()
    {
        if (true)
        {
            HandleBowDrawing();
        } 
        else
        {
            if (isDrawing) CancelDraw();
        }
    }

    private void HandleBowDrawing()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
        {
            StartDraw();
        }
        if (Input.GetMouseButtonUp(1) && isDrawing) //Right mouse button released
        {
            CancelDraw();
        }
        if (Input.GetMouseButtonDown(0) && isDrawing)
        {
            ReleaseArrow();
        }
    }

    private void StartDraw()
    {
        isDrawing = true;
        bowAnimator.SetBool("IsDrawing", true);
    }

    private void CancelDraw()
    {
        isDrawing = false;
        bowAnimator.SetBool("IsDrawing", false);
    }

    private void ReleaseArrow()
    {
        if (!isDrawing) return;

        isDrawing = false;
        bowAnimator.SetBool("IsDrawing", false);

        ShootArrow();
    }

    private void ShootArrow()
    {
        Vector3 shootingDirection = CalulateDirection().normalized;

        GameObject arrow = Instantiate(arrowPrefab, spawnPosition.position, Quaternion.identity);
        arrow.transform.SetParent(null);

        arrow.transform.forward = shootingDirection;

        arrow.GetComponent<Rigidbody>().AddForce(shootingDirection * shootingForce, ForceMode.Impulse);
    }

    public Vector3 CalulateDirection()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        return targetPoint - spawnPosition.position;
    }
}
