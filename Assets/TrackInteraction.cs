using Project.Screpts;
using UnityEngine;

public class TrackInteraction : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Truck>(out var truck)) // Для объекта Truck
                {
                    if (truck is not null)
                        truck.HandleRayCastHit();
                }
            }
        }
    }
}