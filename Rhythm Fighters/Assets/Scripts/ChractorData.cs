using UnityEngine;

[CreateAssetMenu(menuName ="CreateCharactorData")]
public class ChractorData : ScriptableObject
{
    // None     のけぞりがない攻撃
    // Small    のけぞり(小)
    // Middle   のけぞり(中)
    // Big      のけぞり(大)
    // Gigant   のけぞり()

    //弱
    public enum LightPunch
    {
        None,
        Small,
        Middle,
        Big,
        Gigant
    }
    //強
    public enum HeavyPunch
    {
        None,
        Small,
        Middle,
        Big,
        Gigant
    }
    //コマンド1
    public enum Comand1
    {
        None,
        Small,
        Middle,
        Big,
        Gigant
    }
    //コマンド2
    public enum Comand2
    {
        None,
        Small,
        Middle,
        Big,
        Gigant
    }
    [SerializeField]
    private LightPunch lightPunch = default(LightPunch);
    public LightPunch _lp { get => lightPunch; }
    [SerializeField]
    private HeavyPunch heavyPunch = default(HeavyPunch);
    public HeavyPunch _hp { get => heavyPunch; }
    [SerializeField]
    private Comand1 comand1 = default(Comand1);
    public Comand1 _c1 { get => comand1; }
    [SerializeField]
    private Comand2 comand2 = default(Comand2);
    public Comand2 _c2 { get => comand2; }
}
