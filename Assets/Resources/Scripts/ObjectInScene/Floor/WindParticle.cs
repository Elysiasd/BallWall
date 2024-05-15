using Unity.Collections;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class WindParticle : MonoBehaviour
{
    private Vector2 shape = new Vector2(1, .1f);
    private int cnt;
    [Header("Á£×Ó")]
    [SerializeField] private float interval = .2f;
    [SerializeField] private float velocity = 1f;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material mat;

    [Header("·ç³¡")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private float force = 2f;
    //private static readonly int matricesID = Shader.PropertyToID("_Matrices");
    private NativeArray<Vector3> pos;
    private NativeArray<Vector3> scales;
    private Matrix4x4[] matrices;
    private int idx;
    private float timer;
    private float lifespan;
    private Vector2 orient;
    private Matrix4x4 selfMatrix;

    private bool isBallIn;
    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        lifespan = transform.localScale.x / velocity;
        cnt = Mathf.CeilToInt(lifespan / interval);
        idx = 0;
        timer = 0;

        orient = new Vector2(
            Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));

        matrices = new Matrix4x4[cnt];
        selfMatrix = Matrix4x4.TRS
            (transform.position, transform.rotation, transform.localScale);

        pos = new NativeArray<Vector3>(cnt, Allocator.Persistent);
        scales = new NativeArray<Vector3>(cnt, Allocator.Persistent);
        for (int i = 0; i < cnt; i++) scales[i] = shape * 0;
    }
    private void OnDisable()
    {
        pos.Dispose();
        scales.Dispose();
    }
    private void OnApplicationQuit() => OnDisable();
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            InitParticle();
            NextIdx();
        }
        for (int i = 0; i < cnt; i++)
        {
            pos[i] += (Vector3)orient.normalized * Time.deltaTime * velocity;
            matrices[i] = Matrix4x4.TRS(pos[i], transform.rotation, scales[i]);
            Graphics.DrawMesh(mesh, matrices[i], mat, 1);
        }
    }
    private void FixedUpdate()
    {
        if (isBallIn && !SlideWall.isBallCollison)
            Ball.Instance.RB.AddForce(orient * force, ForceMode2D.Force);
    }
    private void NextIdx() => idx = (cnt + idx + 1) % cnt;
    private void InitParticle()
    {
        pos[idx] = selfMatrix.MultiplyPoint(Vector3.left / 2 +
            Vector3.Lerp(Vector3.up, Vector3.down, Random.Range(.25f, .75f)));
        scales[idx] = shape * Random.Range(.5f, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            isBallIn = true;
            AudioManager.Instance.PlayLoop(clip);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            isBallIn = false;
            AudioManager.Instance.StopAll();
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
    //    Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    //}
}
