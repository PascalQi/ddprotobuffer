using System;

namespace ddprotobuffer
{
    public interface IArchive
    {
        void DoSomething(ref byte t);
        void DoSomething(ref sbyte t);
        void DoSomething(ref short t);
        void DoSomething(ref ushort t);
        void DoSomething(ref int t);
        void DoSomething(ref uint t);
        void DoSomething(ref long t);
        void DoSomething(ref ulong t);
        void DoSomething(ref float t);
        void DoSomething(ref double t);
        void DoSomething(ref bool t);
        void DoSomething(ref string t);
        void DoSomething(IExtensible t);
    }

    public interface IExtensible
    {
        void Serialize(IArchive ar);
    }
}
