using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Brains/Patroller")]
public class PatrollerBrain : Brain
{
//    [SerializeField] private float punchInterval = 4;

//    [SerializeField] [TextArea] private string developerDescription =
//        "Settings:\n" +
//        "punchInterval in overrideSettings to customise on a per instance level";

    public override void Initialize(Thinker thinker)
    {
        thinker.Remember("drake", thinker.GetComponent<DrakeController>());
        thinker.Remember("movement", thinker.GetComponent<MovementController>());
        thinker.Remember("moveInput", Vector2.zero);
    }

    public override void Think(Thinker thinker)
    {
        DrakeController drake = thinker.Remember<DrakeController>("drake");
        MovementController mc = thinker.Remember<MovementController>("movement");
        Vector2 moveInput = thinker.Remember<Vector2>("moveInput");

        if (mc.IsGrounded)
        {
            if (moveInput.sqrMagnitude <= 0)
            {
                moveInput = new Vector2(1, 0);
            }
            else if (mc.IsAtWall() || mc.IsAtEdge())
            {
                moveInput.x *= -1;
            }

            thinker.Remember("moveInput", moveInput);
            drake.Walk(moveInput);
        }
    }
}