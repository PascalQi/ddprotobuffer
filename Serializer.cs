using System;
using System.Collections.Generic;
using System.Text;

namespace ddprotobuffer
{
    public class Serializer
    {
        SerializeArchive _SerializeArchive = new SerializeArchive();
        DeserializeArchive _DeserializeArchive = new DeserializeArchive();

        //序列化
        public void Serialize(IExtensible packet, byte[] Buffer, int offset, ref int Length)
        {
            lock (_SerializeArchive)
            {
                _SerializeArchive.SetInit(Buffer, offset);
                packet.Serialize(_SerializeArchive);
                Length = _SerializeArchive.Length;
            }
        }

        //反序列化
        public void Deserialize(byte[] Buffer, int offset, IExtensible packet)
        {
            lock (_DeserializeArchive)
            {
                _DeserializeArchive.SetInit(Buffer, offset);//前面两字节的长度,后1字节Cmd,1字节SubCmd
                packet.Serialize(_DeserializeArchive);
            }
        }

        private static Serializer instance = null;
        Serializer() { }
        public static Serializer Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Serializer();
                }
                return instance;
            }
        }
    }
}