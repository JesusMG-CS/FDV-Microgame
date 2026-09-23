using UnityEngine;

public class Meteor : MonoBehaviour
{
    public enum MeteorSize
    {
        Grande,
        Pequeño
    }

    [Header("Configuración")]
    public MeteorSize size = MeteorSize.Grande;

    [Header("Movimiento")]
    public float speed = 5f;
    public float destroyY = -10f;

    [Header("Fragmentación")]
    public GameObject smallMeteorPrefab;
    public float fragmentHorizontalSpeed = 2f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // El meteorito siempre se mueve hacia abajo.
        rb.linearVelocity = Vector3.down * speed;
    }

    private void Update()
    {
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
    public void Hit()
    {
        if (size == MeteorSize.Grande)
        {
            Fragment();
        }

        Destroy(gameObject);
    }

    private void Fragment()
    {
        if (smallMeteorPrefab == null)
        {
            Debug.LogWarning("No se ha asignado el prefab del meteorito pequeño.");
            return;
        }

        GameObject meteorLeft = Instantiate(
            smallMeteorPrefab,
            transform.position,
            Quaternion.identity
        );

        GameObject meteorRight = Instantiate(
            smallMeteorPrefab,
            transform.position,
            Quaternion.identity
        );

        Rigidbody rbLeft = meteorLeft.GetComponent<Rigidbody>();
        Rigidbody rbRight = meteorRight.GetComponent<Rigidbody>();

        if (rbLeft != null)
        {
            rbLeft.linearVelocity = new Vector3(
                -fragmentHorizontalSpeed,
                -speed,
                0f
            );
        }

        if (rbRight != null)
        {
            rbRight.linearVelocity = new Vector3(
                fragmentHorizontalSpeed,
                -speed,
                0f
            );
        }
    }
}
