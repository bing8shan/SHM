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
        /// 异步读取身份证信息
        /// </summary>
        /// <param name="readTimes"></param>
        /// <param name="readInterval"></param>
        /// <returns>0 成功 -1失败</returns>
        public static Task<CardInfo> ReadIdCard(int readTimes,int readInterval)
        {
            return Task.Factory.StartNew(() =>
            {
                CardInfo cardInfo = new CardInfo();
                cardInfo.ret = -1;
                for (int i = 0; i < readTimes; i++)
                {
                    string retstr = Dcrf32Obj.getIDCard("USB", 9600, @"c:\me.bmp", ref cardInfo);
                    if (retstr == "1")
                    {
                        cardInfo.ret = 0;
                        cardInfo.cardType = CARDTYPE.SFZ;
                        cardInfo.xh = ReadCertCardSnr();
                        return cardInfo;
                    }
                    Task.Delay(TimeSpan.FromMilliseconds(readInterval));
                }
                return cardInfo;
            });
        }

        /// <summary>
        /// 异步读取社保卡
        /// </summary>
        /// <param name="readTimes"></param>
        /// <param name="readInterval"></param>
        /// <returns></returns>
        public static Task<CardInfo> ReadCardBas(int readTimes, int readInterval)
        {
            return Task.Factory.StartNew(() =>
            {
                CardInfo cardInfo = new CardInfo();
                cardInfo.ret = -1;
                for (int i = 0; i < readTimes; i++)
                {
                    string retstr = Dcrf32Obj.readCardBas(1, "", ref cardInfo);
                    if (retstr == "1")
                    {
                        cardInfo.ret = 0;
                        cardInfo.cardType = CARDTYPE.SBK;
          
                        return cardInfo;
                    }
                    Task.Delay(TimeSpan.FromMilliseconds(readInterval));
                }
                return cardInfo;
            });
        }

        public static Task<CardInfo> ReadJzCardSnr(int readTimes, int readInterval)
        {
            return Task.Factory.StartNew(() =>
            {
                CardInfo cardInfo = new CardInfo();
                cardInfo.ret = -1;
                for (int i = 0; i < readTimes; i++)
                {
                    string retstr = Dcrf32Obj.getCpuTypeA("USB", 9600); 
                    if (retstr.Length>5)
                    {
                        cardInfo.ret = 0;
                        cardInfo.cardType = CARDTYPE.JZK;
                        cardInfo.kh=retstr;
                        return cardInfo;
                    }
                    Task.Delay(TimeSpan.FromMilliseconds(readInterval));
                }
                return cardInfo;
            });
        }


        public static void ResolveCardInfo(ref CardInfo cardInfo,string infoStr)
        {
            if (cardInfo == null || infoStr==null) return;

            string[] infos = infoStr.Split(new char[] { '$' });

            switch (cardInfo.cardType)
            {
                case CARDTYPE.SFZ:
                    cardInfo.name= infos[0];
                    cardInfo.sex= infos[1];
                    cardInfo.nation= infos[2];
                    cardInfo.birth_day= infos[3];
                    cardInfo.address= infos[4];
                    cardInfo.id_number= infos[5];
                    cardInfo.department= infos[6];
                    cardInfo.expire_start_day= infos[7];
                    cardInfo.expire_end_day= infos[8];
                    break;
                case CARDTYPE.SBK:
                    cardInfo.name = infos[4];
                    cardInfo.sex = infos[2];
                    cardInfo.id_number = infos[1];
                    cardInfo.sbkh = infos[2];
                    break;
                default: return;
            }
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
