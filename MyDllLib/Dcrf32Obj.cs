using Cn.Hardnuts.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyDllLib
{
    public    class Dcrf32Obj
    {
        [DllImport("dcrf32.dll")]
        public static extern short dc_init(Int16 port, int baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern short dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_reset(int icdev, uint sec);
        [DllImport("dcrf32.dll")]
        public static extern short dc_config_card(int icdev, char cardtype);  //初试化
        //short USER_API dc_card_n(HANDLE icdev, unsigned char _Mode, unsigned int* SnrLen, unsigned char* _Snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_n(int icdev, byte _Mode, ref uint SnrLen, [Out] byte[] _Snr);
        //short USER_API dc_beep(HANDLE icdev, unsigned short _Msec);

        [DllImport("dcrf32.dll")]
        public static extern short dc_cardstr(int icdev, byte _Mode, [Out] char[] _Snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_beep(int icdev, ushort _Msec);
        //short USER_API dc_authentication_passaddr(HANDLE icdev, unsigned char _Mode, unsigned char _Addr, unsigned char* passbuff);
        [DllImport("dcrf32.dll")]
        public static extern short dc_authentication_passaddr(int icdev, byte _Mode, byte _Addr, [In] byte[] passbuff);
        //short USER_API dc_write(HANDLE icdev, unsigned char _Adr, unsigned char* _Data);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write(int icdev, byte adr, [In] byte[] sdata);  //向卡中写入数据
        //short USER_API dc_write_hex(HANDLE icdev, unsigned char _Adr, char *_Data);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_hex(int icdev, int adr, [In] byte[] sdata);  //向卡中写入数据(转换为16进制)
        //short USER_API dc_read(HANDLE icdev, unsigned char _Adr, unsigned char *_Data);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read(int icdev, byte adr, [Out] byte[] sdata);  //从卡中读数据
        //short USER_API dc_read_hex(HANDLE icdev, unsigned char _Adr, char *_Data);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据(转换为16进制)
        //short USER_API a_hex(unsigned char *a, unsigned char *hex, short len);
        [DllImport("dcrf32.dll")]
        public static extern short a_hex([In] byte[] a, [Out] byte[] hex, short len);  //普通字符转换成十六进制字符
        //short USER_API hex_a(unsigned char *hex, unsigned char *a, short length);
        [DllImport("dcrf32.dll")]
        public static extern short hex_a([In] byte[] hex, [Out] byte[] a, short length);  //普通字符转换成十六进制字符
        //short USER_API dc_initval(HANDLE icdev, unsigned char _Adr, unsigned int _Value);
        [DllImport("dcrf32.dll")]
        public static extern short dc_initval(int icdev, byte _Adr, uint _Value);  //普通字符转换成十六进制字符
        // short USER_API dc_readval(HANDLE icdev, unsigned char _Adr, unsigned int *_Value);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readval(int icdev, byte _Adr, ref uint _Value);  //普通字符转换成十六进制字符
        // short USER_API dc_increment(HANDLE icdev, unsigned char _Adr, unsigned int _Value);
        [DllImport("dcrf32.dll")]
        public static extern short dc_increment(int icdev, byte _Adr, uint _Value);  //普通字符转换成十六进制字符
        // short USER_API dc_decrement(HANDLE icdev, unsigned char _Adr, unsigned int _Value);
        [DllImport("dcrf32.dll")]
        public static extern short dc_decrement(int icdev, byte _Adr, uint _Value);  //普通字符转换成十六进制字符
        //short USER_API dc_restore(HANDLE icdev, unsigned char _Adr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_restore(int icdev, byte _Adr);  //普通字符转换成十六进制字符
        //short USER_API dc_transfer(HANDLE icdev, unsigned char _Adr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_transfer(int icdev, byte _Adr);  //普通字符转换成十六进制字符
        //short USER_API dc_pro_resetInt(HANDLE icdev, unsigned char *rlen, unsigned char *receive_data);
        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_resetInt(int icdev, ref byte rlen, [Out] byte[] receive_data);  //普通字符转换成十六进制字符
        //short USER_API dc_pro_commandlinkInt(HANDLE icdev, unsigned int slen, unsigned char *sendbuffer, unsigned int *rlen, unsigned char *databuffer, unsigned char timeout);
        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_commandlinkInt(int icdev, uint slen, [In] byte[] sendbuffer, ref uint rlen, [Out] byte[] databuffer, byte timeout);  //普通字符转换成十六进制字符
        //short USER_API dc_card_b(HANDLE icdev, unsigned char *rbuf);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_b(int icdev, [Out] byte[] rbuf);  //普通字符转换成十六进制字符
        // short USER_API dc_MFPL0_writeperso(HANDLE icdev, unsigned int BNr, unsigned char *dataperso);
        [DllImport("dcrf32.dll")]
        public static extern short dc_MFPL0_writeperso(int icdev, [In] uint BNr, [Out] byte[] dataperso);  //普通字符转换成十六进制字符
        //short USER_API dc_auth_ulc(HANDLE icdev, unsigned char *key);
        [DllImport("dcrf32.dll")]
        public static extern short dc_auth_ulc(int icdev, [In] byte[] key);  //普通字符转换成十六进制字符
        //short USER_API dc_verifypin_4442(HANDLE icdev, unsigned char *passwd);
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4442(int icdev, [In] byte[] passwd);  //普通字符转换成十六进制字符
        //short USER_API dc_write_4442(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4442(int icdev, short offset, short length, [In] byte[] data_buffer);  //普通字符转换成十六进制字符
        //short USER_API dc_read_4442(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4442(int icdev, short offset, short length, [Out] byte[] data_buffer);  //普通字符转换成十六进制字符
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4428(int icdev, [In] byte[] passwd);  //普通字符转换成十六进制字符
        //short USER_API dc_write_4442(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4428(int icdev, short offset, short length, [In] byte[] data_buffer);  //普通字符转换成十六进制字符
        //short USER_API dc_read_4442(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4428(int icdev, short offset, short length, [Out] byte[] data_buffer);  //普通字符转换成十六进制字符
        //short USER_API dc_setcpu(HANDLE icdev, unsigned char _Byte);
        [DllImport("dcrf32.dll")]
        public static extern short dc_setcpu(int icdev, [In] byte _Byte);  //普通字符转换成十六进制字符
        //short USER_API dc_write_24c(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_24c(int icdev, short offset, short length, [In] byte[] data_buffer);  //普通字符转换成十六进制字符
        //short USER_API dc_read_4442(HANDLE icdev, short offset, short length, unsigned char *data_buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_24c(int icdev, short offset, short length, [Out] byte[] data_buffer);  //普通字符转换成十六进制字符
        //short USER_API dc_cpureset(HANDLE icdev, unsigned char *rlen, unsigned char *databuffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpureset(int icdev, ref byte rlen, [Out] byte[] databuffer);  //普通字符转换成十六进制字符
        //short USER_API dc_cpuapduInt(HANDLE icdev, unsigned int slen, unsigned char *sendbuffer, unsigned int *rlen, unsigned char *databuffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapduInt(int icdev, uint slen, [In] byte[] sendbuffer, ref uint rlen, [Out] byte[] databuffer);  //普通字符转换成十六进制字符
        [DllImport("dcrf32.dll")]
        public static extern short dc_SamAReadCardInfo(int handle, int type, ref int text_len, [Out] byte[] text, ref int photo_len, [Out] byte[] photo, ref int fingerprint_len, [Out] byte[] fingerprint, ref int extra_len, [Out] byte[] extra);

        [DllImport("dcrf32.dll", EntryPoint = "dc_ParseTextInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern short dc_ParseTextInfo(int handle, int charset, int info_len, [Out] byte[] info, [Out] byte[] name, [Out] byte[] sex, [Out] byte[] nation, [Out] byte[] birth_day, [Out] byte[] address, [Out] byte[] id_number, [Out] byte[] department, [Out] byte[] expire_start_day, [Out] byte[] expire_end_day, [Out] byte[] reserved);
        [DllImport("dcrf32.dll")]
        public static extern short dc_ParseTextInfoForForeigner(int handle, int charset, int info_len, [Out] byte[] info, [Out] byte[] english_name, [Out] byte[] sex, [Out] byte[] id_number, [Out] byte[] citizenship, [Out] byte[] chinese_name, [Out] byte[] expire_start_day, [Out] byte[] expire_end_day, [Out] byte[] birth_day, [Out] byte[] version_number, [Out] byte[] department_code, [Out] byte[] type_sign, [Out] byte[] reserved);
        [DllImport("dcrf32.dll")]
        public static extern short dc_ParsePhotoInfo(int handle, int type, int info_len, [Out] byte[] info, ref int photo_len, [Out] byte[] photo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_ParseOtherInfo(int icdev, int flag, [In] byte[] in_info, [Out] byte[] out_info);
        [DllImport("dcrf32.dll")]
        public static extern short dc_get_idsnr_hex(int icdev, [Out] byte[] _Data);

        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapdu_hex(int icdev, int slen, [In] byte[] sendbuffer, int rlen, [Out] byte[] databuffer);

        [DllImport("HealthyCarder.dll")]
        public static extern int DC_OpenDevice(int port, [Out] byte[] errInfo);
        [DllImport("HealthyCarder.dll")]
        public static extern int DC_CloseDevice(int handle, [Out] byte[] errInfo);

        [DllImport("HealthyCarder.dll")]
        public static extern int GetCertCardSnr(int handle, [Out] byte[] CertCardSnr, [Out] byte[] errInfo);
        [DllImport("HealthyCarder.dll")]
        public static extern int GetSiCardNO(int handle, [Out] byte[] SiCardNO, [Out] byte[] errInfo);

        [DllImport("HealthyCarder.dll")]
        public static extern int DeviceBeep(int iDevHandle, int iBeepTime, [Out] byte[] pchErrInfo);

        [DllImport("HealthyCarder.dll")]
        public static extern int ReadSiHomeAddr(int iDevHandle, [Out] byte[] pchAddr, [Out] byte[] pchErrInfo);

        [DllImport("HealthyCarder.dll")]
        public static extern int iGetTwoBarCodes(int iDevHandle, int iTimeOut, [Out] byte[] pOutInfo);

        //读取证件信息
        [DllImport("HealthyCarder.dll")]
        public static extern int iReadIdentityCard(int iDevHandle, ref int piFingerPrintLen, [Out] byte[] ucaFingerPrint, byte[] pBmpFile, [Out] byte[] pOutInfo);

        //读取三代社保卡
        [DllImport("SSCardDriver.dll")]
        public static extern int iReadCardBas(int iType, byte[] pDevInfo, [Out] byte[] pOutInfo);
       
        public static String readCardBas(int iType, string pDevInfoStr, ref CardInfo info)       
        {
            byte[] pDevInfo = System.Text.Encoding.Default.GetBytes(pDevInfoStr);
            byte[] pOutInfo = new byte[1024];

            byte[] databuffer = new byte[100];
            //short iport = 9600;
            //int handle = 0;
            int ret = 0;
            string retstr = "";
            byte[] errInfo = new byte[100];
            try
            {
                ret = iReadCardBas(iType, pDevInfo, pOutInfo);
                if (ret == 0)
                {
                    //String s1 = System.Text.Encoding.Default.GetString(pOutInfo);
                    String s1=Byte2Str(pOutInfo);

                    //string[] infos = s1.Split('|');

                    //if (infos.Length >= 8)
                    //{
                    //    retstr = "1";
                    //    info.name = infos[4];
                    //    //info.sex = infos[2];
                    //    info.id_number = infos[1];
                    //    info.sbkh= infos[2];

                    //}
                    info.other=s1;
                    retstr = "1";

                    return retstr;

                }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {

            }

            return retstr;
        }


        public static String readIdentityCard(String port, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;
            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";

                int piFingerPrintLen = 0;
                byte[] ucaFingerPrint = new byte[2048];
                byte[] pBmpFile = System.Text.Encoding.Default.GetBytes("c:/me.bmp");
                byte[] pOutInfo = new byte[2048];
                ret = iReadIdentityCard(handle, ref piFingerPrintLen, ucaFingerPrint, pBmpFile, pOutInfo);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(pOutInfo);
                    DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);
            }

            return "";
        }



        public static String readSiHomeAddr(String port, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;
            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";


                ret = ReadSiHomeAddr(handle, SiCardNO, errInfo);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(SiCardNO);
                    DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);
            }

            return "";
        }

        public static String getTwoBarCodes(String port, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;
            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";


                ret = iGetTwoBarCodes(handle, 10000, SiCardNO);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(SiCardNO);
                    DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);
            }

            return "";
        }

        public static String getTwoBarCodes(String port, int outtime, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;
            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";


                ret = iGetTwoBarCodes(handle, outtime, SiCardNO);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(SiCardNO);
                    DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);
            }

            return "";
        }


        public static String getCertCardSnr(String port, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;

            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";

                ret = GetCertCardSnr(handle, CertCardSnr, errInfo);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(CertCardSnr);
                    String s2 = System.Text.Encoding.Default.GetString(errInfo);
                    DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //MessageBox.Show("身份证：" + s1, s2);
                }


                ret = GetSiCardNO(handle, SiCardNO, errInfo);

                if (ret == 0)
                {
                    String s1 = System.Text.Encoding.Default.GetString(SiCardNO);

                    if (!String.IsNullOrEmpty(s1))
                    {
                        String[] items = s1.Split('|');
                        if (items.Length >= 2)
                            DeviceBeep(handle, 10, errInfo);

                        return items[1];
                    }

                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);

            }

            return "";
        }

        public static String getSiCardNO(String port, int baund)
        {
            byte[] databuffer = new byte[100];
            short iport = 0;
            int handle = 0;
            int ret = 0;
            byte[] CertCardSnr = new byte[100];
            byte[] errInfo = new byte[100];

            byte[] SiCardNO = new byte[1024];

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                handle = DC_OpenDevice(iport, databuffer);

                if (handle <= 0)
                    return "";


                ret = GetSiCardNO(handle, SiCardNO, errInfo);

                if (ret == 0)
                {
                    // String s1 = System.Text.Encoding.Default.GetString(SiCardNO);
                    String s1 = Byte2Str(SiCardNO);
                     DeviceBeep(handle, 10, errInfo);
                    return s1;
                    //String s2 = System.Text.Encoding.Default.GetString(errInfo);

                    //MessageBox.Show("社保卡：" + s1, s2);
                }


            }
            catch (Exception )
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
            finally
            {
                DC_CloseDevice(handle, errInfo);
            }

            return "";
        }



        //TypeA 卡读序列号
        public static String getCpuTypeA(String port, int baund)
        {
            //string str;
            int icdev = -1;
            int st = -1;
            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            uint SnrLen = 0;
            short iport = 0;
            string serialNO = "";

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return serialNO;
                }


                //射频复位
                dc_reset(icdev, 1);
                st = dc_config_card(icdev, 'A');
                // int st = dc_find_i_d(icdev);
                st = dc_card_n(icdev, 0x00, ref SnrLen, _Snr);

                //char[] szSnr11 = new char[100];
                // st = dc_cardstr(icdev, 0x00, szSnr11);
                // String str1 = new String(szSnr11);

                if (st == 0)
                {
                    dc_beep(icdev, 10);
                    if (SnrLen == 4)
                    {
                        // long ll = _Snr[3] * 256 * 256 * 256 + _Snr[2] * 256 * 256 + _Snr[1] * 256 + _Snr[0]; //医卡通 体检卡 
                        long ll = BitConverter.ToInt64(_Snr, 0);
                        serialNO = ll.ToString().PadLeft(10, '0');
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                {
                    st = dc_exit(icdev);
                    if (st != 0)
                    {
                        // editAddString("dc_exit Error!");
                        // return;
                    }
                    else
                    {
                        // editAddString("dc_exit OK!");
                        //icdev = -1;
                    }
                }
            }

            return serialNO;

        }

        public static string getIDCard(String port, int baund, string path, ref CardInfo info)
        {
            int icdev = -1;
            int st = -1;
            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            short iport = 0;

            string ret = "0";

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {

                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return ret;
                }

                //dc_beep(icdev, 10);
                int result = -1;
                int text_len = 0;
                byte[] text = new byte[256];
                int photo_len = 0;
                byte[] photo = new byte[1024];
                int fingerprint_len = 0;
                byte[] fingerprint = new byte[1024];
                int extra_len = 0;
                byte[] extra = new byte[70];
                int type = 0;
                //string tempbuffer;

                result = dc_SamAReadCardInfo(icdev, 3, ref text_len, text, ref photo_len, photo, ref fingerprint_len, fingerprint, ref extra_len, extra);
                // st = dc_SamAReadCardInfo(icdev, 3, &text_len, text, &photo_len, photo, &fingerprint_len, fingerprint, &extra_len, extra);
                if (result == 0)
                {
                    dc_beep(icdev, 10);

                    if ((text[0] >= 'A') && (text[0] <= 'Z') && (text[1] == 0))
                    {
                        type = 1;
                    }
                    if (text[248] == 'J')
                        type = 2;

                    info.type = type;
                    if (type == 0 || type == 2)
                    {
                        byte[] name = new byte[64];
                        byte[] sex = new byte[8];
                        byte[] nation = new byte[12];
                        byte[] birth_day = new byte[36];
                        byte[] address = new byte[144];
                        byte[] id_number = new byte[76];
                        byte[] department = new byte[64];
                        byte[] expire_start_day = new byte[36];
                        byte[] expire_end_day = new byte[36];
                        byte[] reserved = new byte[76];
                        byte[] info_buffer = new byte[64];


                        result = dc_ParseTextInfo(icdev, 0, text_len, text, name, sex, nation, birth_day, address, id_number, department, expire_start_day, expire_end_day, reserved);
                        if (result == 0)
                        {
                            info.other = Byte2Str(name);

                            info.other +="$"+ Byte2Str(sex);
    
                            info.other += "$" + Byte2Str(nation);
              
                            info.other += "$" + Byte2Str(birth_day);

                            info.other += "$" + Byte2Str(address);

                            info.other += "$" + Byte2Str(id_number);

                            info.other += "$" + Byte2Str(department);

                            info.other += "$" + Byte2Str(expire_start_day);
 
                            info.other += "$" + Byte2Str(expire_end_day);

                            ret = "1";
                        }
                    }
                    else if (type == 1)
                    {
                        byte[] english_name = new byte[244];
                        byte[] sex = new byte[8];
                        byte[] id_number = new byte[64];
                        byte[] citizenship = new byte[16];
                        byte[] chinese_name = new byte[64];
                        byte[] expire_start_day = new byte[36];
                        byte[] expire_end_day = new byte[36];
                        byte[] birth_day = new byte[36];
                        byte[] version_number = new byte[12];
                        byte[] department_code = new byte[20];
                        byte[] type_sign = new byte[8];
                        byte[] reserved = new byte[16];
                        byte[] info_buffer = new byte[64];

                        result = dc_ParseTextInfoForForeigner(icdev, 0, text_len, text, english_name, sex, id_number, citizenship, chinese_name, expire_start_day, expire_end_day, birth_day, version_number, department_code, type_sign, reserved);
                        if (result == 0)
                        {

                            //tempbuffer = string.Format("name: {0}", System.Text.Encoding.Default.GetString(english_name));

                            //info.name = tempbuffer;
                            info.other =  Byte2Str(english_name);
                            //dc_ParseOtherInfo(icdev, 0, sex, info_buffer);
                            info.other += "$" + Byte2Str(info_buffer);

                            info.other += "$" + Byte2Str(id_number);
                      
                            info.other += "$" + Byte2Str(citizenship);

                            info.other += "$" + Byte2Str(chinese_name);


                            info.other += "$" + Byte2Str(expire_start_day);
                  
                            info.other += "$" + Byte2Str(expire_end_day);
  
                            info.other += "$" + Byte2Str(birth_day);

                            info.other += "$" + Byte2Str(version_number);

                            info.other += "$" + Byte2Str(department_code);

                            info.other += "$" + Byte2Str(type_sign);

                            ret = "1";
                        }


                    }

                    int rlen1 = 0;
                    result = dc_ParsePhotoInfo(icdev, 0, photo_len, photo, ref rlen1, System.Text.Encoding.Default.GetBytes(path));
                    if (result != 0)
                    {
                        //editAddString("dc_ParsePhotoInfo error!");
                        // goto safeExit;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                {
                    st = dc_exit(icdev);
                    if (st != 0)
                    {
                        // editAddString("dc_exit Error!");
                        // return;
                    }
                    else
                    {
                        // editAddString("dc_exit OK!");
                        //icdev = -1;
                    }
                }
            }
            return ret;
        }

        public static int IcWrite(String port, int baund, string password, int addr, string data)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(password)) password = "FFFFFFFFFFFFFF";
            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            uint SnrLen = 0;

            int icdev = -1;
            int st = -1;
            short iport = 0;

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return ret;
                }
                //射频复位
                dc_reset(icdev, 1);
                st = dc_config_card(icdev, 'A');
                if (st != 0) return ret;

                //寻卡并返回卡序列号
                st = dc_card_n(icdev, 0x00, ref SnrLen, _Snr);
                if (st != 0) return ret;

                byte[] pwd = UtilHelper.strToToHexByte(password);
                byte len = (byte)pwd.Length;

                st = dc_authentication_passaddr(icdev, 0, len, pwd);
                if (st != 0) return ret;

                dc_beep(icdev, 10);

                byte[] writedata = System.Text.Encoding.Default.GetBytes(data);

                st = dc_write(icdev, (byte)addr, writedata);
                if (st != 0) return ret;

                ret = 1;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                    st = dc_exit(icdev);
            }


            return ret;
        }

        public static int IcRead(String port, int baund, string password, int addr, ref string data)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(password)) password = "FFFFFFFFFFFFFF";

            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            uint SnrLen = 0;
            int icdev = -1;
            int st = -1;
            short iport = 0;

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return ret;
                }
                //射频复位
                dc_reset(icdev, 1);
                st = dc_config_card(icdev, 'A');
                if (st != 0) return ret;

                //寻卡并返回卡序列号
                st = dc_card_n(icdev, 0x00, ref SnrLen, _Snr);
                if (st != 0) return ret;

                byte[] pwd = UtilHelper.strToToHexByte(password);
                byte len = (byte)pwd.Length;

                st = dc_authentication_passaddr(icdev, 0, len, pwd);
                if (st != 0) return ret;

                dc_beep(icdev, 10);

                byte[] rdata = new byte[33];

                st = dc_read(icdev, (byte)addr, rdata);
                if (st != 0) return ret;

                data = System.Text.Encoding.Default.GetString(rdata);

                ret = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                    st = dc_exit(icdev);
            }


            return ret;
        }

        public static int IcReadVal(String port, int baund, string password, int addr, ref uint val)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(password)) password = "FFFFFFFFFFFFFF";

            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            uint SnrLen = 0;
            int icdev = -1;
            int st = -1;
            short iport = 0;

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return ret;
                }
                //射频复位
                dc_reset(icdev, 1);
                st = dc_config_card(icdev, 'A');
                if (st != 0) return ret;

                //寻卡并返回卡序列号
                st = dc_card_n(icdev, 0x00, ref SnrLen, _Snr);
                if (st != 0) return ret;

                byte[] pwd = UtilHelper.strToToHexByte(password);
                byte len = (byte)pwd.Length;

                st = dc_authentication_passaddr(icdev, 0, len, pwd);
                if (st != 0) return ret;

                dc_beep(icdev, 10);

                uint ivalue = 0;

                st = dc_readval(icdev, (byte)addr, ref ivalue);

                if (st != 0) return ret;

                val = ivalue;

                ret = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                    st = dc_exit(icdev);
            }


            return ret;
        }

        public static int IcWriteVal(String port, int baund, string password, string optype, int addr, uint val)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(password)) password = "FFFFFFFFFFFFFF";

            byte[] _Snr = new byte[100];
            byte[] szSnr = new byte[100];
            uint SnrLen = 0;
            int icdev = -1;
            int st = -1;
            short iport = 0;

            if (port == "USB")
                iport = 100;
            else if (port == "PCSC")
                iport = 200;
            else if (port == "COM1")
                iport = 0;
            else if (port == "COM2")
                iport = 1;

            try
            {
                icdev = dc_init(iport, baund);

                if ((int)icdev <= 0)
                {
                    return ret;
                }
                //射频复位
                dc_reset(icdev, 1);
                st = dc_config_card(icdev, 'A');
                if (st != 0) return ret;

                //寻卡并返回卡序列号
                st = dc_card_n(icdev, 0x00, ref SnrLen, _Snr);
                if (st != 0) return ret;

                byte[] pwd = UtilHelper.strToToHexByte(password);
                byte len = (byte)pwd.Length;

                st = dc_authentication_passaddr(icdev, 0, len, pwd);
                if (st != 0) return ret;

                dc_beep(icdev, 10);

                uint ivalue = val;

                if ("inc".Equals(optype))
                    st = dc_increment(icdev, (byte)addr, ivalue);
                else if ("dec".Equals(optype))
                    st = dc_decrement(icdev, (byte)addr, ivalue);
                else if ("init".Equals(optype))
                    st = dc_initval(icdev, (byte)addr, ivalue);


                if (st != 0) return ret;
                ret = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message);
            }
            finally
            {
                if ((int)icdev > 0)
                    st = dc_exit(icdev);
            }


            return ret;
        }

        public static string gb2312_utf8(string text)
        {
            //声明字符集
            System.Text.Encoding utf8, gb2312;
            //gb2312
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            //utf8
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            byte[] gb;
            gb = gb2312.GetBytes(text);
            gb = System.Text.Encoding.Convert(gb2312, utf8, gb);
            //返回转换后的字符
            return utf8.GetString(gb);
        }
        private static string Byte2Str(byte[] bytes)
        {
            string retstr = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] != '\0')
                {
                    if (retstr.Length == 0)
                        retstr = bytes[i].ToString();
                    else
                        retstr += "," + bytes[i].ToString();
                }
            }

            return retstr;
        }

    }
}
