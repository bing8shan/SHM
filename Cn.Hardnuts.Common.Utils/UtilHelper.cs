using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace Cn.Hardnuts.Common.Utils
{
    public class UtilHelper
    {
        public static string? GetAppConfig(string strKey)
        {
            string? strValue = ConfigurationManager.AppSettings[strKey];
            return strValue;

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //if (config.AppSettings.Settings[strKey] != null)
            //    return config.AppSettings.Settings[strKey].Value;
            //else
            //    return string.Empty;
        }

        public static void SetAppConfig(string strKey, string strValue)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings[strKey].Value = strValue;
            cfa.Save();
        }

        public static string encript(string str)
        {
            int i, k;
            byte temp;
            String lsstr1 = "";
            if ("".Equals(str) || string.IsNullOrEmpty(str))
                return "";

            str = str.Trim();
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            for (i = 1; i <= b.Length; i++)
            {
                temp = b[i - 1];
                if (i % 2 == 0)
                    k = temp + i - 32;
                else
                    k = temp - i + 8;
                lsstr1 = lsstr1 + (char)k;
            }
            /*
	            lsstr2=Mid(str,i,1)
	            if  mod(i,2) = 0 then
		            k=ASC(lsstr2) + i -32
	            else
		            k=ASC(lsstr2) - i + 8
	            end if
	            lsstr1=lsstr1+CHAR(k)
            NEXT
             * */
            return lsstr1;
        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //�õ�������
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //��IP��ַ�б���ɸѡ��IPv4���͵�IP��ַ
                    //AddressFamily.InterNetwork��ʾ��IPΪIPv4,
                    //AddressFamily.InterNetworkV6��ʾ�˵�ַΪIPv6����
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception)
            {

                return "";
            }
        }

        public static string GetIP() //��ȡ����IP
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            return ipAddr.ToString();
        }

        public static void callObjectEvent(Object obj, string EventName)
        {
            //����һ�����ͣ�AssemblyQualifiedName�ó���Ч������
            Type? t = null;
            String? name = obj.GetType().AssemblyQualifiedName;
            if (name != null)
                t = Type.GetType(name);
            //��������      
            object[] p = new object[1];
            //��������
            MethodInfo? m = null;
            if (t != null && EventName != null)
                m = t.GetMethod(EventName, BindingFlags.NonPublic | BindingFlags.Instance);
            //������ֵ�����뺯��      
            //��ò�������  
            ParameterInfo[]? para = null;
            if (m != null)
                para = m.GetParameters();
            //���ݲ��������֣��ò����Ŀ�ֵ��

            if (para != null)
            {
                name = para[0].ParameterType?.BaseType?.FullName;
                if (name != null)
                    t = Type.GetType(name);
                if (t != null)
                {
                    PropertyInfo? info = t.GetProperty("Empty");
                    if (info != null)
                        p[0] = info;
                }

            }
            //����      
            m?.Invoke(obj, p);
            return;
        }

        /// <summary>
        /// �ַ���ת16�����ֽ�����
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// �ֽ�����ת16�����ַ���
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// �Ӻ���ת����16����
        /// </summary>
        /// <param name="s"></param>
        /// <param name="charset">����,��"utf-8","gb2312"</param>
        /// <param name="fenge">�Ƿ�ÿ�ַ��ö��ŷָ�</param>
        /// <returns></returns>
        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//�ո�
                //throw new ArgumentException("s is not valid chinese string!");
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str += string.Format("{0}", ",");
                }
            }
            return str.ToLower();
        }

        ///<summary>
        /// ��16����ת���ɺ���
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="charset">����,��"utf-8","gb2312"</param>
        /// <returns></returns>
        public static string UnHex(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//�ո�
            }
            // ��Ҫ�� hex ת���� byte ���顣 
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // ÿ�����ַ���һ�� byte�� 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }
    }
}
