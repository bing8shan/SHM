using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDllLib
{
    public  class CardInfo
    {
        public string? name { get; set; }
        public string? sex { get; set; }
        public string? nation { get; set; }

        public string? birth_day { get; set; }
        public string? address { get; set; }
        public string? id_number { get; set; }
        public string? department { get; set; }
        public string? expire_start_day { get; set; }
        public string? expire_end_day { get; set; }
        public string? reserved { get; set; }

        public string? english_name { get; set; }
        public string? citizenship { get; set; }
        public string? chinese_name { get; set; }

        public string? version_number { get; set; }
        public string? department_code { get; set; }
        public string? type_sign { get; set; }

        public string? sbkh { get; set; }
        public string? other { get; set; }
        public string? xh { get; set; }
        public string? kh { get; set; }

        public int type { get; set; }

    }

    public enum CARDTYPE { SFZ,SBK,JZK}
}
