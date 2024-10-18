using System;
using System.Collections.Generic;
using System.Text;

namespace ddprotobuffer
{
    /// <summary>
    /// 数据打包
    /// </summary>
    class SerializeArchive : IArchive
    {
        public void SetInit(byte[] buffer, int offset)
        {
            m_Buffer = buffer;
            m_Index = offset;
        }

        private void CopyBuffer(ref byte[] buf)
        {
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(IExtensible t)
        {
            t.Serialize(this);
        }

        public void DoSomething(ref byte t)
        {
            m_Buffer[m_Index] = t;
            m_Index += 1;
        }

        public void DoSomething(ref sbyte t)
        {
            m_Buffer[m_Index] = (byte)t;
            m_Index += 1;
        }

        public void DoSomething(ref short t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref ushort t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref int t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref uint t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref long t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref ulong t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref float t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref double t)
        {
            byte[] buf = BitConverter.GetBytes(t);
            Array.Copy(buf, 0, m_Buffer, m_Index, buf.Length);
            m_Index += buf.Length;
        }

        public void DoSomething(ref bool t)
        {
            byte s = 0;
            if (t == true)
                s = 1;
            DoSomething(ref s);
        }

        public void DoSomething(ref string t)
        {
            byte[] buf = Encoding.UTF8.GetBytes(t);
            ushort len = (ushort)buf.Length;
            DoSomething(ref len);
            CopyBuffer(ref buf);
        }
        
        //获取数据长度
        public int Length { get { return m_Index; }}

        private byte[] m_Buffer;  //接收到的数据
        private int m_Index;      //记录读取位置
    }
}
