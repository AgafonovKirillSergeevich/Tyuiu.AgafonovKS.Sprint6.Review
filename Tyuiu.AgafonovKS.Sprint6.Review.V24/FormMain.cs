using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.AgafonovKS.Sprint6.Review.V24.Lib;

namespace Tyuiu.AgafonovKS.Sprint6.Review.V24
{
    public partial class FormMain : Form
    {
        DataService ds = new DataService();

        public int[,] valueArray;
        public int countRow;
        public int countColumns;
        public int startX;
        public int endX;
        public int massiveStart;
        public int massiveEnd;
        public int selectedR;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCreateMatrix_AKS_Click(object sender, EventArgs e)
        {
            try
            {
                countRow = Convert.ToInt32(textBoxCountRow_AKS.Text);
                countColumns = Convert.ToInt32(textBoxCountColums_AKS.Text);
                startX = Convert.ToInt32(textBoxStartDiap_AKS.Text);
                endX = Convert.ToInt32(textBoxEndDiap_AKS.Text);

                Random rnd = new Random();

                valueArray = new int[countRow, countColumns];

                dataGridViewOutPut_AKS.RowCount = valueArray.GetLength(0);
                dataGridViewOutPut_AKS.ColumnCount = valueArray.GetLength(1);

                
                bool isNegative = rnd.Next(0, 2) == 0; 

                for (int i = 0; i < countRow; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        valueArray[i, j] = rnd.Next(startX, endX);

                        if (isNegative)
                        {
                            valueArray[i, j] *= -1;
                        }                       
                        isNegative = !isNegative;

                        dataGridViewOutPut_AKS.Rows[i].Cells[j].Value = valueArray[i, j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonResult_AKS_Click(object sender, EventArgs e)
        {
            try
            {
                massiveStart = Convert.ToInt32(textBoxStartMassive_AKS.Text);
                massiveEnd = Convert.ToInt32(textBoxEndMassive_AKS.Text);
                selectedR = Convert.ToInt32(textBoxSelectedRow_AKS.Text);


                if (valueArray != null && selectedR >= 0 && selectedR < countRow)
                {
                    int res = DataService.GetMatrix(valueArray, selectedR, massiveStart, massiveEnd);
                    textBoxResult_AKS.Text = Convert.ToString(res);
                }
                else
                {
                    MessageBox.Show("Матрица не инициализирована или выбрана неверная строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные для выполнения вычислений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
