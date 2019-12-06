using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="CreateCharactorData")]
public class ChractorData : ScriptableObject
{
    
    public enum Warping
    {
        Small,
        Middle,
        Big
    }
    [SerializeField]
    private Warping warping = default(Warping);
    public Warping _war { get => warping; }
}
