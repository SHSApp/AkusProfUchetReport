using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace SHSApp_Profuchet
{
    class Qualif
    {
        private OleDbConnection Conn = null;
        private OleDbCommand oCmd = null;
        private DataTable result = null;
        private bool state = false;
        private static string oQualif = "";
        public static string ConnectionString = "Provider=VFPOLEDB.1;Data Source=C:\\IK\\Database\\Qualif\\;Password=\"\";Collating Sequence=MACHINE;";
        //public static string ConnectionString = @"DRIVER={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\\IK\\Database;Exclusive=No;BackgroundFetch=No;Collate=Machine;Null=No;Deleted=No;";

        public void SetDbPath(string path)
        {
            ConnectionString = "Provider=VFPOLEDB.1;Data Source=" + path + "Qualif\\;Password=\"\";Collating Sequence=MACHINE;";
        }

        public Qualif()
        {
            Conn = new OleDbConnection();
            result = new DataTable();
            state = false;
        }

        public void OpenQualif(string name)
        {
            if (Conn != null)
            {
                try
                {
                    Conn.ConnectionString = ConnectionString;
                    Conn.Open();
                    state = true;
                    oCmd = Conn.CreateCommand();
                    oQualif = name;
                    result.Reset();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    state = false;
                }
            } else { state = false; }
        }

        public void CloseOpenedQualif()
        {
            if (state)
            {
                Conn.Close();
                state = false;
                result.Reset();
            }
        }

        public bool Opened
        {
            get
            {
               return state;
            }
        }

        public string GetFromQualifByID(string ID, string qualif)
        {
            if (!state)
            {
                OpenQualif(qualif);
            }
            oCmd.CommandText = "SELECT item, name FROM " + qualif + " WHERE item LIKE '" + ID + "'";
            result.Reset();
            result.Load(oCmd.ExecuteReader());
            CloseOpenedQualif();
            if (result.Rows.Count > 0) return result.Rows[0].ItemArray[1].ToString().TrimEnd(' ');
            else return "";
        }

        public string GetFromQualifByID(string ID)
        {
            if (state)
            {
                oCmd.CommandText = "SELECT item, name FROM " + oQualif + " WHERE item LIKE '" + ID + "'";
                result.Load(oCmd.ExecuteReader());
                if (result.Rows.Count > 0) return result.Rows[result.Rows.Count - 1].ItemArray[1].ToString().TrimEnd(' ');
                else return "";
            }
            else return "";
        }



        public string GetStatiaSimpleByID(string ID)
        {
            int IDcount = ID.TrimEnd(' ').Length / 2;
            string res = "ст. ";
            OpenQualif("pc8");
            for(int i = 0; i < IDcount; i++)
            {
                if (i == (IDcount - 1))
                {
                    res += GetFromQualifByID(ID.Substring(2 * i, 2)) + " УК РФ";
                }
                else
                {
                    res += GetFromQualifByID(ID.Substring(2 * i, 2)) + ", ";
                }
            }
            CloseOpenedQualif();
            return res;
        }

        public string GetNomerOtryadaByID(string ID)
        {
            OpenQualif("pc52");
            string res = GetFromQualifByID(ID);
            CloseOpenedQualif();
            if (res != "") return res;
            else return "Карантин";
        }

        public string GetOtkudaPribByID(string ID)
        {
            OpenQualif("pc5");
            string res = GetFromQualifByID(ID);
            CloseOpenedQualif();
            if (res != "") return res;
            else return "";
        }

        public string GetStatiaFullByID(string ID)
        {
            int IDcount = ID.TrimEnd(' ').Length / 2;
            string res = "";
            OpenQualif("pc8");
            for (int i = 0; i < IDcount; i++)
            {
                string tmp = GetFromQualifByID(ID.Substring(2 * i, 2));
                string pu = "";
                string ch = "";
                string st = "";
                tmp = tmp.Replace(" ", "");
                if (tmp.IndexOf("п.") > 1)
                {
                    pu = tmp.Substring(tmp.IndexOf("п.") + 2, tmp.Length - tmp.IndexOf("п.") - 2);
                    ch = tmp.Substring(tmp.IndexOf("ч.") + 2, tmp.IndexOf("п.") - tmp.IndexOf("ч.") - 2);
                    st = tmp.Substring(0, tmp.IndexOf("ч."));
                    if (pu.Length > 3) res += "пунктам "; else res += "пункту ";
                    res += pu + " части " + ch + " статьи "+ st;
                }
                else
                {
                    if (tmp.IndexOf("ч.") > 1)
                    {
                        ch = tmp.Substring(tmp.IndexOf("ч.") + 2, tmp.Length - tmp.IndexOf("ч.") - 2);
                        st = tmp.Substring(0, tmp.IndexOf("ч."));
                        res += "части " + ch + " статьи " + st;
                    }
                    else
                    {
                        res += "статьи " + tmp;
                    }
                }
                if (i == (IDcount - 1))
                {
                    res += " УК РФ";
                }
                else
                {
                    res += ", ";
                }
            }
            CloseOpenedQualif();
            return res;
        }

    }
}
