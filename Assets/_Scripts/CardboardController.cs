using UnityEngine;
using System.Collections;

public class CardboardController : MonoBehaviour
{
    public AudioClip winClip;
    public AudioClip deathClip;
    public AudioClip eatingStarClip;
    public AudioClip eatingPointClip;
    public AudioClip eatingGhostClip;
    public Vector2 startPoint;
    public float speed;
    public Camera cam;
    public Camera UIcam;
    public GameValue gameValue;
    public GameObject[] disableWhenOver;
    public GameObject overText;
    public SceneFaderScript fader;

    ParticleSystem particle;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        transform.position = new Vector3(startPoint.x, 1.25f, startPoint.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += cam.transform.forward * Time.deltaTime * speed;
        particle = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            audioSource.PlayOneShot(eatingPointClip, 1f);
            particle.Play();
            other.gameObject.SetActive(false);
            gameValue.AddPoint(10);
        }

        if (other.gameObject.CompareTag("Ghost") && gameValue.GetState() == GameValue.START_STATE)
        {
            if (gameValue.IsFever())
            {
                audioSource.PlayOneShot(eatingGhostClip, 1f);
                GhostScript gs = other.gameObject.GetComponent<GhostScript>();
                gs.WaitToRespawn();
                gameValue.AddPoint(250);
            }
            else
            {
                audioSource.PlayOneShot(deathClip, 1f);
                speed = 0f;
                StartCoroutine(GameOver());
            }
        }

        if (other.gameObject.CompareTag("Star"))
        {
            audioSource.PlayOneShot(eatingStarClip, 1f);
            other.gameObject.SetActive(false);
            gameValue.SetFeverTime(10);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(startPoint.x, 1.25f, startPoint.y);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winClip, 1f);
    }

    IEnumerator GameOver()
    {
        fader.FadeOut("GAME OVER");
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Retry");
    }
}