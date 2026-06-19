
using System;

namespace Genial
{
    [Flags]
    public enum NoteType
    {
        None = 0,
        C = 1 << 0,
        T = 1 << 1,
        G = 1 << 2,
        A = 1 << 3
    }
}