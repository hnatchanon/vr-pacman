using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public CardboardController main;
    public GenerateBlip minimap;
    public GhostResetable ghosts;
    public Resetable stars;
    public Resetable points;
    public CardboardController cardboard;
    public SceneFaderScript fader;
    public GameValue gameValue;

    int level = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameValue.GetState() == GameValue.WIN_STATE)
        {
            gameValue.SetState(GameValue.WAIT_STATE);
            StartCoroutine(LevelUp());
        }
    }

    public int GetLevel()
    {
        return level;
    }

    IEnumerator LevelUp()
    {
        level++;
        fader.FadeOut("Level " + level);
        main.PlayWinSound();
        yield return new WaitForSeconds(5);
        cardboard.Reset();
        ghosts.Reset();
        points.Reset();
        stars.Reset();
        minimap.Generate();
        gameValue.SetState(GameValue.START_STATE);
        fader.FadeIn();
    }
}
