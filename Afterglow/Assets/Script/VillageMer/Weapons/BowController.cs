using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    private Animator bowAnimator;
    public string arrowItemName = "Arrow";
    private bool isDrawing = false;

    public string arrowPrefabPath = "Arrow";
    private GameObject arrowPrefab;
    public Transform spawnPosition;

    public float shootingForce = 100f;

    public GameObject viseur;
    public LayerMask aimLayerMask; // NEW

    void Start()
    {
        bowAnimator = GetComponent<Animator>();
        LoadArrowPrefab();
    }

    private void LoadArrowPrefab()
    {
        arrowPrefab = Resources.Load<GameObject>(arrowPrefabPath);
        if (arrowPrefab == null)
        {
            Debug.LogError("Arrow prefab not found at path: " + arrowPrefabPath);
        }
    }

    void Update()
    {
        HandleBowDrawing();
    }

    private void HandleBowDrawing()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartDraw();
        }
        if (Input.GetMouseButtonUp(1) && isDrawing)
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
        viseur.SetActive(true);
    }

    private void CancelDraw()
    {
        isDrawing = false;
        bowAnimator.SetBool("IsDrawing", false);
        viseur.SetActive(false);
    }

    private void ReleaseArrow()
    {
        if (!isDrawing) return;

        isDrawing = false;
        bowAnimator.SetBool("IsDrawing", false);
        viseur.SetActive(false);
        ShootArrow();
    }

    private void ShootArrow()
    {
        Vector3 shootingDirection = CalculateDirection().normalized;

        // Décalage pour éviter de heurter immédiatement le joueur ou un obstacle proche
        Vector3 offsetSpawn = spawnPosition.position + spawnPosition.forward * 0.5f;

        GameObject arrow = Instantiate(arrowPrefab, offsetSpawn, Quaternion.LookRotation(shootingDirection));
        arrow.transform.SetParent(null);

        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        if (arrowRb != null)
        {
            arrowRb.velocity = shootingDirection * shootingForce;
        }
    }

    public Vector3 CalculateDirection()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit, 100f, aimLayerMask))
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
