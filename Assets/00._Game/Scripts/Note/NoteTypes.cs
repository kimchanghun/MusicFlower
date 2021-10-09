using System;

namespace MF.Game
{
    [Flags]
    public enum NoteTypes
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        AB = A | B,
        BC = B | C,
        AC = A | C,
        ABC = A | B | C
    }
}
