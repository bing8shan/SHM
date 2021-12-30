using FastReport;
using FastReportPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MyUtilLib
{
    public class PrintHelper
    {
        public DataTable getMaster()
        {
            System.Data.DataTable table1 = new System.Data.DataTable();

            for (int i = 1; i <= 65; i++)
            {
                table1.Columns.Add(String.Format("F{0}A",i), typeof(string));
            }

            return table1;

        }

        public DataTable getDetail()
        {
            System.Data.DataTable table1 = new System.Data.DataTable();

            for (int i = 1; i <= 60; i++)
            {
                table1.Columns.Add(String.Format("F{0}A", i), typeof(string));
            }

            for (int i = 1; i <= 20; i++)
            {
                table1.Columns.Add(String.Format("FF{0}A", i), typeof(double));
            }

            return table1;

        }

        public void Print(String frFileName, String jsonFileName, String isPrintView,String printer)
        {
            MessageBox.Show(System.Text.Encoding.Default.ToString());
            string frpath =String.Format("{0}",frFileName);
            string jsonpath = String.Format("{0}", jsonFileName);
            Report FReport = new Report();
            DataSet ds = new DataSet();
            StringBuilder sb=new StringBuilder();
            string line;
            using (StreamReader sr = new StreamReader(jsonpath,Encoding.Default))
            {
                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                   // Console.WriteLine(line);
                    sb.Append(line);
                }
            }

            MyData data = JsonHelper.DeserializeJsonToObject<MyData>(sb.ToString());
            //JObject jobj = JObject.Parse(sb.ToString());

            //JArray ja = (JArray)jobj["dbMaster"];

            //Console.Out.WriteLine(ja.ToString());
            DataTable dbMaster = null;
            if (data!=null && data.dbMaster != null && data.dbMaster.Rows.Count > 0)
            {
                dbMaster = data.dbMaster;// this.getMaster();
                dbMaster.TableName = "dbMaster"; // 一定要设置表名称
                ds.Tables.Add(dbMaster.Copy());
            }

            //Console.Out.WriteLine(data.dbMaster.Rows.Count);
           // Console.Out.WriteLine(data.dbMaster.Rows[0]["F1A"]);
            //Console.Out.WriteLine(data.dbDetail.Rows.Count);
            DataTable dbDetail = null;
            if (data != null && data.dbDetail != null && data.dbDetail.Rows.Count > 0)
            {
                dbDetail = data.dbDetail;// this.getDetail();
                dbDetail.TableName = "dbDetail"; // 一定要设置表名称
                ds.Tables.Add(dbDetail.Copy());
            }
            

            FReport.Load(frpath);

            //TextObject lbl_title = (TextObject)FReport.FindObject("lbl_title");
            //if (lbl_title != null)
            //{
            //    lbl_title.Text = "这是标题";
            //}

            if (dbMaster!=null && dbMaster.Rows.Count>0){
                for (int i = 1; i <= 5; i++)
                {
                    string name = String.Format("PIC{0}A", i);
                    PictureObject pic = (PictureObject)FReport.FindObject(name);
                    if (pic != null)
                    {
                        pic.ImageLocation = data.dbMaster.Rows[0][name].ToString();
                    }
                }
            }

            FReport.RegisterData(ds);

            if (!String.IsNullOrEmpty(printer) && printer.Length>=2)
            {
                FReport.PrintSettings.Printer = printer;
            }

            if ("true".Equals(isPrintView))
            {
                FormFRPreview fp = new FormFRPreview();
                fp.CreateFr(FReport);
                fp.ShowDialog();
            }
            else
            {               
                FReport.Print();
            }


        }

        public void PrintJson(String frFileName, String content, String isPrintView, String printer)
        {
            string frpath = String.Format("{0}", frFileName);
         
            Report FReport = new Report();
            DataSet ds = new DataSet();
           
            MyData data = JsonHelper.DeserializeJsonToObject<MyData>(content);
            //JObject jobj = JObject.Parse(sb.ToString());

            //JArray ja = (JArray)jobj["dbMaster"];

            //Console.Out.WriteLine(ja.ToString());
            DataTable dbMaster = null;
            if (data != null && data.dbMaster != null && data.dbMaster.Rows.Count > 0)
            {
                dbMaster = data.dbMaster;// this.getMaster();
                dbMaster.TableName = "dbMaster"; // 一定要设置表名称
                ds.Tables.Add(dbMaster.Copy());
            }

            //Console.Out.WriteLine(data.dbMaster.Rows.Count);
            // Console.Out.WriteLine(data.dbMaster.Rows[0]["F1A"]);
            //Console.Out.WriteLine(data.dbDetail.Rows.Count);
            DataTable dbDetail = null;
            if (data != null && data.dbDetail != null && data.dbDetail.Rows.Count > 0)
            {
                dbDetail = data.dbDetail;// this.getDetail();
                dbDetail.TableName = "dbDetail"; // 一定要设置表名称
                ds.Tables.Add(dbDetail.Copy());
            }


            FReport.Load(frpath);

            //TextObject lbl_title = (TextObject)FReport.FindObject("lbl_title");
            //if (lbl_title != null)
            //{
            //    lbl_title.Text = "这是标题";
            //}

            if (dbMaster != null && dbMaster.Rows.Count > 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    string name = String.Format("PIC{0}A", i);
                    PictureObject pic = (PictureObject)FReport.FindObject(name);
                    if (pic != null)
                    {
                        pic.ImageLocation = data.dbMaster.Rows[0][name].ToString();
                    }
                }
            }

            FReport.RegisterData(ds);

            if (!String.IsNullOrEmpty(printer) && printer.Length >= 2)
            {
                FReport.PrintSettings.Printer = printer;
            }

            if ("true".Equals(isPrintView))
            {
                FormFRPreview fp = new FormFRPreview();
                fp.CreateFr(FReport);
                fp.ShowDialog();
            }
            else
            {
                FReport.Print();
            }


        }
    }
}
