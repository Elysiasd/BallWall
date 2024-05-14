using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;
[RequireComponent(typeof(BoxCollider2D))]
public class WindParticle : MonoBehaviour
{
    private Vector2 shape = new Vector2(2, .1f);
    private int cnt;
    [Header("Á£×Ó")]
    [SerializeField] private float interval = .2f;
    [SerializeField] private float velocity = 1f;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material mat;
    [Header("·ç³¡")]
    [SerializeField] private float force = 2f;
    private static readonly int matricesID = Shader.PropertyToID("_Matrices");
    private NativeArray<Vector3> pos;
    private NativeArray<Vector3> scales;
    private NativeArray<Matrix4x4> matrices;
    private int idx;
    private float timer;
    private float lifespan;
    private Vector2 orient;
    private Matrix4x4 selfMatrix;
    private ComputeBuffer buffer;

    private bool isBallIn;
    private BoxCollider2D box;
    [BurstCompile(CompileSynchronously = true)]
    public struct Move : IJobFor
    {
        public Vector2 orient;
        public float velocity;
        public float deltaTime;
        public Quaternion rotation;
        public NativeArray<Vector3> pos;
        public NativeArray<Vector3> scales;
        [WriteOnly]
        public NativeArray<Matrix4x4> matrices;
        public void Execute(int i)
        {
            pos[i] += (Vector3)orient.normalized * deltaTime * velocity;
            matrices[i] = Matrix4x4.TRS(pos[i], rotation, scales[i]);
        }
    }

    private void OnEnable()
    {
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;

        lifespan = transform.localScale.x / velocity;
        cnt = Mathf.CeilToInt(lifespan / interval);
        idx = 0;
        timer = 0;

        orient = new Vector2(
            Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));

        selfMatrix = Matrix4x4.TRS
            (transform.position, transform.rotation, transform.localScale);

        matrices = new NativeArray<Matrix4x4>(cnt, Allocator.Persistent);
        pos = new NativeArray<Vector3>(cnt, Allocator.Persistent);
        scales = new NativeArray<Vector3>(cnt, Allocator.Persistent);
        buffer = new ComputeBuffer(cnt, 64);
        for (int i = 0; i < cnt; i++) scales[i] = Vector3.zero;
    }
    private void OnDisable()
    {
        pos.Dispose();
        scales.Dispose();
        matrices.Dispose();

        buffer?.Release();
        buffer = null;
    }
    private void Update()
    {
        new Move()
        {
            orient = orient,
            velocity = velocity,
            deltaTime = Time.deltaTime,
            rotation = transform.rotation,
            pos = pos,
            scales = scales,
            matrices = matrices,
        }.Schedule(cnt, default).Complete();
        buffer.SetData(matrices);
        mat.SetBuffer(matricesID, buffer);
        Graphics.DrawMeshInstanced(mesh, mesh.subMeshCount - 1, mat, matrices.ToArray());
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > interval)
        {
            timer = 0;
            InitParticle();
            NextIdx();
        }

        if (isBallIn) Ball.Instance.RB.AddForce(orient * force, ForceMode2D.Force);
    }
    private void NextIdx() => idx = (cnt + idx + 1) % cnt;
    private void InitParticle()
    {
        pos[idx] = selfMatrix.MultiplyPoint(Vector3.left / 2 +
            Vector3.Lerp(Vector3.up, Vector3.down, UnityEngine.Random.Range(.25f, .75f)));
        scales[idx] = shape * UnityEngine.Random.Range(.25f, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) isBallIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) isBallIn = false;
    }
}