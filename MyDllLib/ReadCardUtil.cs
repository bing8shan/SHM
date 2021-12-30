using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDllLib
{
    public class ReadCardUtil
    {
        /// <summary>
        /// 读3代社保卡信息 
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <returns></returns>
        public static int ReadCardBas(ref CardInfo cardInfo)
        {
            int ret = -1;
            //string s = MapFileHelper.readMemoryMappedFile();
            //if (MapFileHelper.CONTENT.Equals(s)) return ret;

            string retstr=Dcrf32Obj.readCardBas(1, "", ref cardInfo);

            if (retstr == "1")
                ret = 0;

            return ret;
        }

        //二代社保卡可以了
        //string s = Dcrf32Obj.getSiCardNO("USB", 9600);
        //MessageBox.Show(s);
        //string? ss;
        //ss = HttpHelper.Post("http://localhost:19080/utf8", s);
        //MessageBox.Show(ss);

        public static int getSiCardNO(ref CardInfo cardInfo)
        {
            int ret = -1;
            string s = Dcrf32Obj.getSiCardNO("USB", 9600);
            if (s.Length > 10)
            {
                cardInfo.other = s;
            }

            return ret;
        }

        /// <summary>
        /// 读身份证信息
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <returns></returns>
        public static int ReadIdCard(ref CardInfo cardInfo)
        {
            int ret = -1;
            //string s = MapFileHelper.readMemoryMappedFile();
           // if (MapFileHelper.CONTENT.Equals(s)) return ret;

            string retstr = Dcrf32Obj.getIDCard("USB", 9600, @"c:\me.bmp", ref cardInfo);

            if (retstr == "1")
                ret = 0;

            return ret;
        }

        /// <summary>
        /// 院内就诊卡卡号
        /// </summary>
        /// <returns></returns>
        public static string ReadJzCardSnr()
        {        
            //string s = MapFileHelper.readMemoryMappedFile();
           // if (MapFileHelper.CONTENT.Equals(s)) return "";

            string retstr = Dcrf32Obj.getCpuTypeA("USB", 9600);

            return retstr;
        }
        /// <summary>
        /// 身份证序列号
        /// </summary>
        /// <returns></returns>
        public static string ReadCertCardSnr()
        {
            //string s = MapFileHelper.readMemoryMappedFile();
           // if (MapFileHelper.CONTENT.Equals(s)) return "";

            string retstr = Dcrf32Obj.getCertCardSnr("USB", 9600);

            return retstr;
        }

    }
}
