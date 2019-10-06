using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Brains/Dumb Puncher")]
public class DumbPuncherBrain : Brain
{
    [SerializeField] private float punchInterval = 4;

    [SerializeField] [TextArea] private string developerDescription =
        "Settings:\n" +
        "punchInterval in overrideSettings to customise on a per instance level";

    public override void Initialize(Thinker thinker)
    {
        thinker.Remember("drake", thinker.GetComponent<DrakeController>());
        thinker.Remember("punchInterval",
            thinker.HasMemory("punchInterval")
                ? float.Parse(thinker.Remember<string>("punchInterval"))
                : punchInterval);
    }

    public override void Think(Thinker thinker)
    {
        if (!thinker.HasMemory("coroutineStarted"))
        {
            thinker.Remember("coroutineStarted", true);
            float punchInterval = thinker.Remember<float>("punchInterval");
            DrakeController drake = thinker.Remember<DrakeController>("drake");
            thinker.StartCoroutine(
                CoroutineUtils.Repeat(() => { drake.Attack(); }, 0, punchInterval));
        }
    }
}