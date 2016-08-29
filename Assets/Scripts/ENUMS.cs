using UnityEngine;
using System.Collections;

public static class ENUMS{

    public enum FORMS { Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
    public enum MATERIALGROUPS { NONE,Wood, Leather, Iron };

    public enum MATERIALS {NONE, PigLeather, CrocodileLeather, UnicornLeather, Beech, Cherry, Mahagoni, Iron, Steel, Mithril};


    public enum WEAPONTYPES { Dagger, ShortSword, LongSword, BroadSword };
    public enum SUBBUTTONTYPES { Center, Left, Right, Up, Down };
}
