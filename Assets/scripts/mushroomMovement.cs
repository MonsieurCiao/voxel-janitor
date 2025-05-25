using UnityEngine;

public class mushroomMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var randomRotation = Random.Range(0,360f);
        transform.eulerAngles = new Vector3(0, randomRotation, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.fixedDeltaTime,0,0);
    }
}
