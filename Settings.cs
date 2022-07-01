using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace SHSApp_Profuchet
{
    class Settings
    {
        private OleDbConnection Conn = null;
        //public static string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=settings.mdb;";
        public static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=settings.mdb;";
        private DataTable Profuchet = null;
        private DataTable Personal = null;
        private DataTable Options = null;

        //public string 

        public Settings()
        {
            Conn = new OleDbConnection(ConnectionString);
        }

        public void LoadTables()
        {
            if (Conn != null)
            {
                try
                {
                    Conn.Open();
                    Profuchet = new DataTable();
                    Personal = new DataTable();
                    Options = new DataTable();
                    OleDbCommand oCmd = Conn.CreateCommand();
                    oCmd.CommandText = "SELECT * FROM Profuchet ORDER BY ID";
                    Profuchet.Load(oCmd.ExecuteReader());
                    oCmd.CommandText = "SELECT * FROM Personal ORDER BY ID";
                    Personal.Load(oCmd.ExecuteReader());
                    oCmd.CommandText = "SELECT * FROM Options ORDER BY ID";
                    Options.Load(oCmd.ExecuteReader());
                    Conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string GetParameterByID(int ID)
        {
            return Options.Rows[ID].ItemArray[2].ToString();
        }
        public string GetCodePUByID(int ID)
        {
            return Profuchet.Rows[ID].ItemArray[1].ToString();
        }

        public string GetPUByID(int ID)
        {
            return Profuchet.Rows[ID].ItemArray[3].ToString();
        }
        public string GetFabulaPUbyID(int ID, int type)
        {
            return Profuchet.Rows[ID].ItemArray[4 + type].ToString();
        }
        public string GetFabulaPU2(int type)
        {
            return Profuchet.Rows[0 + type].ItemArray[6].ToString();
        }        
        public void FillHeadersByID(ComboBox cb, int ID)
        {
            switch (ID)
            {
                case 0:
                    for (int i = 0; i < Profuchet.Rows.Count; i++)
                    {
                        cb.Items.Add(Tools.FirstToUpper(Profuchet.Rows[i].ItemArray[3].ToString()));
                        cb.SelectedIndex = 0;
                    }
                    break;
                case 1:
                    for (int i = 0; i < Personal.Rows.Count; i++)
                    {
                        cb.Items.Add(Tools.FirstToUpper(Personal.Rows[i].ItemArray[2].ToString()) + " " + Personal.Rows[i].ItemArray[1].ToString());
                        cb.SelectedIndex = 0;
                    }
                    break;
                case 4:
                    for (int i = 0; i < Options.Rows.Count; i++)
                    {
                        cb.Items.Add(Options.Rows[i].ItemArray[1]);
                        cb.SelectedIndex = 0;
                    }
                    break;
            }               
        }

        public string GetPersonalDoljnostByID(int ID, bool Sklonenie)
        {
            if (!Sklonenie)
            {
                return Personal.Rows[ID].ItemArray[2].ToString();
            }
            else
            {
                return Personal.Rows[ID].ItemArray[5].ToString();
            }
        }

        public string GetPersonalZvanieByID(int ID, bool Sklonenie)
        {
            if (!Sklonenie)
            {
                return Personal.Rows[ID].ItemArray[3].ToString();
            }
            else
            {
                return Personal.Rows[ID].ItemArray[6].ToString();
            }
        }

        public string GetPersonalFIOByID(int ID, bool Sklonenie)
        {
            if (!Sklonenie)
            {
                return Personal.Rows[ID].ItemArray[1].ToString();
            }
            else
            {
                return Personal.Rows[ID].ItemArray[4].ToString();
            }
        }

        public string GetPersonalFullNameByID(int ID, bool Sklonenie)
        {
            if (!Sklonenie)
            {
                return Personal.Rows[ID].ItemArray[2].ToString() + " " 
                    + Personal.Rows[ID].ItemArray[3].ToString() + " внутренней службы " + Personal.Rows[ID].ItemArray[1].ToString();
            }
            else
            {
                return Personal.Rows[ID].ItemArray[5].ToString() + " "
                    + Personal.Rows[ID].ItemArray[6].ToString() + " внутренней службы " + Personal.Rows[ID].ItemArray[4].ToString();
            }
        }

    }
}
