using UnityEngine;
using Zenject;

public static class Events
{
    public static CrouchPressEvent CrouchPressEvent = new();
    public static LocomotionEvent LocomotionEvent = new();
    public static MouseMoveEvent MouseMoveEvent = new();
    public static SwordAttackPressEvent SwordAttackPressEvent = new();
    public static MagicAttackPressEvent MagicAttackPressEvent = new();
    public static SystemsInitializedEvent SystemsInitializedEvent = new();
    public static JumpEvent JumpEvent = new();
    public static BlockPressEvent BlockPressEvent = new();
    public static RunEvent RunEvent = new();
    public static AttackStartedEvent AttackStartedEvent = new();
    public static AttackEndedEvent AttackEndedEvent = new();
    public static BlockStartedEvent BlockStartedEvent = new();
    public static BlockEndedEvent BlockEndedEvent = new();
    public static MagicStartedEvent MagicStartedEvent = new();
    public static MagicEndedEvent MagicEndedEvent = new();
<<<<<<< Updated upstream
=======
    public static EscPressEvent EscPressEvent = new();
    public static SaveAndQuitEvent SaveAndQuitEvent = new();
    public static TogglePeacefulEvent TogglePeacefulEvent = new();
    public static QuitEvent QuitEvent = new();
    public static BossSpawnEvent BossSpawnEvent = new();
    public static EnemyKilledEvent EnemyKilledEvent = new();
>>>>>>> Stashed changes
}

public class RunEvent : GameEvent {}
public class BlockPressEvent : GameEvent { 
    public bool IsBlocking;
}
public class CrouchPressEvent : GameEvent { }
public class SwordAttackPressEvent : GameEvent { }
public class MagicAttackPressEvent : GameEvent { }
public class LocomotionEvent : GameEvent
{
    public Vector2 LocomotionInput;
}

public class JumpEvent : GameEvent
{
    
}

public class MouseMoveEvent : GameEvent
{
    public Vector2 MouseInput;
}

public class BossSpawnEvent : GameEvent { }
public class SystemsInitializedEvent : GameEvent { }
public class AttackStartedEvent : GameEvent
{
    public string SenderID;
}
public class AttackEndedEvent : GameEvent
{
    public string SenderID;
}
public class BlockStartedEvent : GameEvent {}
public class BlockEndedEvent : GameEvent {}
public class MagicStartedEvent : GameEvent
{
    public string SenderID;
}
public class MagicEndedEvent : GameEvent
{
    public string SenderID;
}

<<<<<<< Updated upstream
=======
public class PlayerStatsChangedEvent : GameEvent
{
    public int MaxHp;
    public int CurrentHp;   
}

public class LoadSceneEvent : GameEvent {}
public class SceneLoadedEvent : GameEvent {}
public class EscPressEvent : GameEvent {}
public class SaveAndQuitEvent : GameEvent { }
public class QuitEvent : GameEvent { }
public class TogglePeacefulEvent : GameEvent { }
public class EnemyKilledEvent : GameEvent
{
}
>>>>>>> Stashed changes
//public class StartDialogueEvent : GameEvent
//{
//    public Dialogue Dialogue;
//    public NPC NPC;
//}

//public class EndDialogueEvent : GameEvent { }