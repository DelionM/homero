using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculus;

namespace homero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //a inferior b superior
        double resultado, h, x, n, a, b, resultadoFinal, sumaA;
        String expresion;
        Calculo AnalizadorDeFunciones = new Calculo();
        double j2;
        int j = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                this.txtEcuacion.Focus();
            }
        }

        private void Convierte()
        {
            a = Convert.ToInt32(txtA.Text);
            b = Convert.ToInt32(txtB.Text);
            n = Convert.ToInt32(txtN.Text);
            //expresion = txtEcuacion.Text;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            expresion = txtEcuacion.Text;
            Valorh();
            if (AnalizadorDeFunciones.Sintaxis(expresion, 'x'))
            {

                //si la entrada es correcta se va agregar la tabla
                for (int i = 0; i <= n + 1; i++)
                {
                    int j = dataGrid.Rows.Add();
                    dataGrid.Rows[j].Cells[0].Value = i;
                }
                //inicia en x=a  
                a = sumaA;
                dataGrid.Rows[0].Cells[1].Value = sumaA;
                dataGrid.Rows[0].Cells[2].Value = AnalizadorDeFunciones.EvaluaFx(sumaA);
                resultado = 0;
                resultado = AnalizadorDeFunciones.EvaluaFx(sumaA);

                for (int i2 = 1; i2 <= n + 1; i2++)
                {
                    //Aumenta la suma
                    //EN ESTA PARTE ES DONDE SE HACER LA SUMA FINAL

                    sumaA = sumaA + h;
                    dataGrid.Rows[i2].Cells[1].Value = sumaA;
                    dataGrid.Rows[i2].Cells[2].Value = AnalizadorDeFunciones.EvaluaFx(sumaA);
                    resultadoFinal = resultadoFinal+ AnalizadorDeFunciones.EvaluaFx(sumaA);
                    resultadoFinal = (resultadoFinal * 4) / 2;
                    resultadoFinal = resultadoFinal * (h / 3);
                    txtResultado.Text = Convert.ToString(resultadoFinal);
                    //sumaA = sumaA + sumaA;
                    //
                    //bool pair = true;
                    //if (pair)
                    //{
                    //    j = dataGrid.Rows.Add();
                    //    dataGrid.Rows[j].Cells[0].Value = i2;
                    //    dataGrid.Rows[j].Cells[1].Value = sumaA;
                    //    dataGrid.Rows[j].Cells[2].Value = AnalizadorDeFunciones.EvaluaFx(sumaA);
                    //   // dataGrid.Rows[j].Cells[3].Value = (AnalizadorDeFunciones.EvaluaFx(sumaA) * 4);
                    //    resultado = resultado + (AnalizadorDeFunciones.EvaluaFx(sumaA) * 4);
                    //    pair = !pair;
                    //}
                    //else
                    //{
                    //    j = dataGrid.Rows.Add();
                    //    dataGrid.Rows[j].Cells[0].Value = i2;
                    //    dataGrid.Rows[j].Cells[1].Value = sumaA;
                    //    dataGrid.Rows[j].Cells[2].Value = AnalizadorDeFunciones.EvaluaFx(sumaA);
                    //    // dataGrid.Rows[j].Cells[3].Value = (AnalizadorDeFunciones.EvaluaFx(sumaA) * 2);
                    //    resultado = resultado + (AnalizadorDeFunciones.EvaluaFx(sumaA) * 2);
                    //    pair = !pair;
                    //}
                }
                grafica();
                
            }
            else {
                MessageBox.Show("Asegurese que la ecuación ingresada sea correcta");
            }
        }

        private void grafica()
        {
            propiedades();
                for (j2 = Convert.ToDouble(dataGrid.Rows[0].Cells[1].Value) - 1; j2 <= Convert.ToDouble(dataGrid.Rows[dataGrid.RowCount - 1].Cells[1].Value) + 1; j2++)
                {
                    chart1.Series["Grafica"].Points.AddXY(j2, AnalizadorDeFunciones.EvaluaFx(j2));
                }
        }

        private void propiedades()
        {
            chart1.Series["Grafica"].BorderWidth = 2;
            chart1.Series["Grafica"].Color = Color.Red;
        }

        private void Valorh()
        {
            Convierte();
            h = (b - a) / n;
            txtH.Text = Convert.ToString(h);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
