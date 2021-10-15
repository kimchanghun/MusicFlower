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

    // | => OR 연산(+)
    // CBA 
    // 001 => 1 => A
    // 010 => 2 => B
    // 011 => 3 => AB
    // 100 => 4 => C
    // 101 => 5 => AC
    // 110 => 6 => BC
    // 111 => 7 => ABC

    // 000 None -> OR연산
    // 001 (A) => 001 (A)
    // 100 (C) => 101 (AC)
    // 010 (B) => 111 (ABC)

    // 0 + 0 => 0
    // 0 + 1 => 1
    // 1 + 0 => 1
    // 1 + 1 => 1

    // & => AND 연산 (*)
    // 0 * 0 => 0
    // 0 * 1 => 0
    // 1 * 0 => 0
    // 1 * 1 => 1

    // 101(AC)
    // 010(B)  => 000(None)

    public static class NoteTypeHelper
    {
        public static NoteTypes StringToNoteType(string noteType)
        {
            // noteTYpe "A" => NoteTypes.A
            // noteTYpe "AC" => NoteTypes.AC
            NoteTypes retNoteType = NoteTypes.None;

            if (noteType.Contains("A"))
            {
                retNoteType |= NoteTypes.A;
            }

            if (noteType.Contains("B"))
            {
                retNoteType |= NoteTypes.B;
            }

            if (noteType.Contains("C"))
            {
                retNoteType |= NoteTypes.C;
            }

            return retNoteType;
        }
    }

}
