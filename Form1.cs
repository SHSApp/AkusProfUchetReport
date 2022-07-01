using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FSLib.Declension;

namespace SHSApp_Profuchet
{
    public partial class Form1 : Form
    {
        Settings sett;
        private AkusConnect akus;
        private static int Count = 0;
        private static string Zeki;
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    Zeki = File.ReadAllText(args[0]);
                    File.Delete(args[0]);
                }
                Count = Zeki.Length / 9;
            }
            //Count = 1;
            //Zeki = "!!!E"™Ґpm";
        }

        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            if (e.Index % 2 == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.Bounds);
            }
            if ((e.State & DrawItemState.Selected) != 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Wheat), e.Bounds);
                //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, Color.Gray, Color.Gray);
            }
            e.Graphics.DrawString(text, e.Font, new SolidBrush(Color.Black), e.Bounds.X, e.Bounds.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sett = new Settings();
            akus = new AkusConnect();
            sett.LoadTables();
            akus.SetDbPath(sett.GetParameterByID(0));
            sett.FillHeadersByID(category, 0);
            category.SelectedIndex = 0;
            sett.FillHeadersByID(personal, 1);
            personal.SelectedIndex = 0;

        }

        private void postanovka_CheckedChanged(object sender, EventArgs e)
        {
            if (postanovka.Checked) isprib.Enabled = true;
            else isprib.Enabled = false;
        }

        private void go_Click(object sender, EventArgs e)
        {
            go.Enabled = false;
            pb.Maximum = 100 * Count;
            pb.Step = 10;
            pb.Value = 0;
            string tr1, tr2, fabula, fabula2 = "";
            if (postanovka.Checked)
            {
                tr1 = "постановке на профилактический учет";
                tr2 = "поставить на профилактический учет";
                if (isprib.Checked)
                {
                    fabula = sett.GetFabulaPU2(0);
                    fabula2 = sett.GetFabulaPU2(1);
                } 
                else
                {
                    fabula = fabula2 = sett.GetFabulaPUbyID(category.SelectedIndex, 0);
                }
            }
            else 
            {
                tr1 = "снятии с профилактического учета";
                tr2 = "снять с профилактического учета";
                fabula = fabula2 = sett.GetFabulaPUbyID(category.SelectedIndex, 1);
            }
            for (int i = 0; i < Count; i++)
            {
                string id = Zeki.Substring(i * 9, 9);
                int symbCount = 0; string symbPart = "";
                pb.PerformStep();
                akus.Execute(id);
                pb.PerformStep();
                WordDocument wordDoc = new WordDocument(sett.GetParameterByID(0) + sett.GetParameterByID(8));
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[Тип рапорта1]", tr1);
                wordDoc.ReplaceAllStrings("[Тип рапорта2]", tr2.ToUpper());
                wordDoc.ReplaceAllStrings("[Тип рапорта3]", tr2);
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[Код профучета]", sett.GetCodePUByID(category.SelectedIndex));
                wordDoc.ReplaceAllStrings("[Фабула]", fabula);
                wordDoc.ReplaceAllStrings("[Фабула2]", fabula2);
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[Вид профучета]", sett.GetPUByID(category.SelectedIndex));
                wordDoc.ReplaceAllStrings("[Должность сотрудника1]", Tools.FirstToUpper(sett.GetPersonalDoljnostByID(personal.SelectedIndex,false)));
                wordDoc.ReplaceAllStrings("[Звание сотрудника1]", sett.GetPersonalZvanieByID(personal.SelectedIndex,false));
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[ФИО сотрудника1]", sett.GetPersonalFIOByID(personal.SelectedIndex, false));
                wordDoc.ReplaceAllStrings("[Фамилия Имя Отчество]", akus.GetFullFIO(DeclensionCase.Rodit));
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[ФИО]", akus.GetFullFIO(DeclensionCase.Imenit));
                wordDoc.ReplaceAllStrings("[Фамилия Имя Отчество2]", akus.GetFullFIO(DeclensionCase.Vinit));
                wordDoc.ReplaceAllStrings("[Фамилия И.О.2]", akus.GetFIO(DeclensionCase.Imenit));
                wordDoc.ReplaceAllStrings("[Фамилия И.О.]", akus.GetFIO(DeclensionCase.Vinit));
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[Дата рождения]", akus.GetBirthday());
                while (symbCount < akus.GetStatiaFull().Length)
                {
                    if (akus.GetStatiaFull().Length - symbCount >= 200)
                        symbPart = akus.GetStatiaFull().Substring(symbCount, 200) + "[Статьи]";
                    else symbPart = akus.GetStatiaFull().Substring(symbCount, akus.GetStatiaFull().Length - symbCount);
                    wordDoc.ReplaceAllStrings("[Статьи]", symbPart);
                    symbCount += 200;
                }
                wordDoc.ReplaceAllStrings("[Срок]", akus.GetFormattedSrok());
                wordDoc.ReplaceAllStrings("[Начало срока]", akus.GetNS());
                wordDoc.ReplaceAllStrings("[Конец срока]", akus.GetKS());
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("[Номер отряда]", akus.GetNomerOtryada(0));
                wordDoc.ReplaceAllStrings("[Дата прибытия]", akus.GetDataPrib());
                wordDoc.ReplaceAllStrings("[Учреждение прибытия]", akus.GetOtkudaPrib());
                pb.PerformStep();
                wordDoc.ReplaceAllStrings("ИЗ-^?^?/", "СИЗО-");
                wordDoc.Visible = true;
                Activate();
            }
            go.Enabled = true;
            Close();
        }

    }
}
