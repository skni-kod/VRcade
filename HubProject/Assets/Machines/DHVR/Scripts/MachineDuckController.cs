using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DuckState
{
    STATE_IDLE,
    STATE_FLY,
    STATE_FLY_AWAY,
    STATE_HIT,
    STATE_DEAD_DROP
}

public class MachineDuckController : MonoBehaviour
{
    public AreaPointGenerator duckFlyingArea;
    public Vector3 target;

    [SerializeField]
    GameObject animatedSprite;
    [SerializeField]
    GameObject hitSprite;

    [SerializeField]
    Animator anim;

    [SerializeField]
    float speed;
    [SerializeField]
    float hitTime = 0.5f;
    [SerializeField]
    float flyAwayTime = 20f;

    float duckTimer = 0f;
    // Start is called before the first frame update

    public bool ready = false;


    DuckState state = DuckState.STATE_IDLE;

    void Start()
    {
        animatedSprite.SetActive(true);
        hitSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //make state machine
        switch(state)
        {
            case DuckState.STATE_IDLE:
                if(ready)
                {
                    duckTimer = flyAwayTime;
                    state = DuckState.STATE_FLY;
                }
                break;
            case DuckState.STATE_FLY:
                if (duckTimer <= 0)
                {
                    anim.SetBool("FlyAway", true);
                    target = transform.position + new Vector3(0f, 40f, 0f);
                    state = DuckState.STATE_FLY_AWAY;
                }
                if (Vector3.Distance(transform.position, target) < 0.01f)
                {
                    target = duckFlyingArea.GetPoint();
                    transform.localScale = new Vector3(Vector3.Normalize(target - transform.position).x < 0f ? -1f : 1f, transform.localScale.y, transform.localScale.z);
                    anim.SetBool("NormalFly", Mathf.Abs(Vector3.Dot(transform.forward, (target - transform.position).normalized)) < 0.707f);
                }
                transform.position += Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;
                break;
            case DuckState.STATE_FLY_AWAY:
                if (transform.position.y > -28.6f)
                    Destroy(gameObject);
                transform.position += Vector3.Normalize(target - transform.position) * speed * Time.deltaTime;
                break;
            case DuckState.STATE_HIT:
                if(duckTimer <= 0)
                {
                    hitSprite.SetActive(false);
                    anim.SetBool("IsDead", true);
                    animatedSprite.SetActive(true);
                    anim.Play("duck1_dead");
                    state = DuckState.STATE_DEAD_DROP;
                }
                break;
            case DuckState.STATE_DEAD_DROP:
                if (transform.position.y < -33f)
                    Destroy(gameObject);
                transform.position += new Vector3(0f, -1.5f, 0f) * Time.deltaTime;
                break;
        }
        if (duckTimer > 0f) duckTimer -= Time.deltaTime;
    }

    public void HitDuck()
    {
        state = DuckState.STATE_HIT;
        duckTimer = hitTime;
        animatedSprite.SetActive(false);
        transform.localScale = new Vector3(Vector3.Normalize(target - transform.position).x < 0f ? -1f : 1f, transform.localScale.y, transform.localScale.z);
        hitSprite.SetActive(true);
    }
}
