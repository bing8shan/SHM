using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cn.Hardnuts.ICommService.Comm
{
    public interface IMainWindow
    {
        void WinMin();

        void WinMax();

        void WinClose();

        void TipText(string msg);
        void Cus1Text(string msg);
        void Cus2Text(string msg);

        void Info(string msg);
        void Error(string msg);

        void ShowCloseBtn(bool bVisible);

        void PlayWav(String filePath,bool isCircle);
        void PlayMp4(String filePath, bool isCircle);

        void InitTimer();
    }
}
