using System;
using System.Collections.Generic;
using System.Text;

namespace ddprotobuffer
{
    /// <summary>
    /// 数据解包
    /// </summary>
    class DeserializeArchive : IArchive
    {
        public void SetInit(byte[] buffer, int offset)
        {
            m_Buffer = buffer;
            m_Used = offset;
            m_RecvSize = m_Buffer.Length;
        }

        public void DoSomething(IExtensible t)
        {
            t.Serialize(this);
        }

        public void DoSomething(ref byte t)
        {
            if (GetRemaining() < sizeof(byte))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(byte));

            t = m_Buffer[m_Used];
            m_Used += sizeof(byte);
        }

        public void DoSomething(ref sbyte t)
        {
            if (GetRemaining() < sizeof(sbyte))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(sbyte));

            t = (sbyte)m_Buffer[m_Used];
            m_Used += sizeof(sbyte);
        }

        public void DoSomething(ref short t)
        {
            if (GetRemaining() < sizeof(short))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(short));

            t = BitConverter.ToInt16(m_Buffer, m_Used);
            m_Used += sizeof(short);
        }

        public void DoSomething(ref ushort t)
        {
            if (GetRemaining() < sizeof(ushort))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(ushort));

            t = BitConverter.ToUInt16(m_Buffer, m_Used);
            m_Used += sizeof(ushort);
        }

        public void DoSomething(ref int t)
        {
            if (GetRemaining() < sizeof(int))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(int));

            t = BitConverter.ToInt32(m_Buffer, m_Used);
            m_Used += sizeof(int);
        }

        public void DoSomething(ref uint t)
        {
            if (GetRemaining() < sizeof(uint))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(uint));

            t = BitConverter.ToUInt32(m_Buffer, m_Used);
            m_Used += sizeof(uint);
        }

        public void DoSomething(ref long t)
        {
            if (GetRemaining() < sizeof(long))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(long));

            byte[] abc = new byte[8];
            Array.Copy(m_Buffer, m_Used, abc, 0, 8);

            t = BitConverter.ToInt64(m_Buffer, m_Used);
            m_Used += sizeof(long);
        }

        public void DoSomething(ref ulong t)
        {
            if (GetRemaining() < sizeof(ulong))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(ulong));

            t = BitConverter.ToUInt64(m_Buffer, m_Used);
            m_Used += sizeof(ulong);
        }

        public void DoSomething(ref float t)
        {
            if (GetRemaining() < sizeof(float))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(float));

            t = BitConverter.ToSingle(m_Buffer, m_Used);
            m_Used += sizeof(float);
        }

        public void DoSomething(ref double t)
        {
            if (GetRemaining() < sizeof(double))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(double));

            t = BitConverter.ToDouble(m_Buffer, m_Used);
            m_Used += sizeof(double);
        }

        public void DoSomething(ref bool t)
        {
            byte s = 0;
            if (GetRemaining() < sizeof(byte /*NOT bool*/))
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + sizeof(byte));

            DoSomething(ref s);
            if (s == 0)
                t = false;
            else
                t = true;
        }

        public void DoSomething(ref string t)
        {
            short len = 0; // bytes
            DoSomething(ref len);

            if (GetRemaining() < len)
                throw new Exception("Remaining data: " + GetRemaining() + ", requested: " + len);

            t = Encoding.UTF8.GetString(m_Buffer, m_Used, len);
            m_Used += len;
        }

        /// <summary>
        /// 剩余字节长度
        /// </summary>
        /// <returns></returns>
        private int GetRemaining()
        {
            return m_RecvSize - m_Used;
        }

        private byte[] m_Buffer = null;

        /// <summary>
        /// 已经使用的字节
        /// </summary>
        /// <returns></returns>
        public int Used
        {
            get { return m_Used; }
        }
        private int m_Used;

        /// <summary>
        /// 实际接收到的字节数
        /// </summary>
        /// <returns></returns>
        public int RecvSize
        {
            get { return m_RecvSize; }
        }
        private int m_RecvSize; 
    }
}
