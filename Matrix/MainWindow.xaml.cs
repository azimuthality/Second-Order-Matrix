using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Matrix
{
    public partial class InverseMatrix : Window
    {
        private double[,] initMatrix = new double[2, 2];
        public InverseMatrix()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandler(object sender, TextCompositionEventArgs e)
        {
            string keyText = e.Text.ToString();
            TextBox textbox = sender as TextBox;
            if (e.Text.ToString() == "-")
            {
                e.Handled = true;
                int newInputValue = int.Parse(textbox.Text) * -1;
                textbox.Text = newInputValue.ToString();
            }
            else
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(keyText);
            }
        }

        private void OnClickBtnHandler(object sender, RoutedEventArgs e)
        {
            try
            {

                initMatrix[0, 0] = double.Parse(textBoxInitMatrix11.Text.ToString());
                initMatrix[0, 1] = double.Parse(textBoxInitMatrix12.Text.ToString());
                initMatrix[1, 0] = double.Parse(textBoxInitMatrix21.Text.ToString());
                initMatrix[1, 1] = double.Parse(textBoxInitMatrix22.Text.ToString());
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message);
            }

            MatrixUnit matrixUnitDefault = new Matrix.MatrixUnit(this.initMatrix, MatrixUnit.MATRIX_DEFAULT_NOTE);
            contentControlDefaultMatrix.Content = matrixUnitDefault;
            if (!MatrixUnit.isValidMatrix)
            {
                MessageBox.Show("Определитель матрицы равен 0", "Вычисление обратной матрицы невозможно");
            }
            else
            {
                MatrixUnit matrixUnitMinor = new Matrix.MatrixUnit(MatrixUnit.MATRIX_MINOR_NOTE);
                contentControlMinorMatrix.Content = matrixUnitMinor;

                MatrixUnit matrixUnitComplement = new Matrix.MatrixUnit(MatrixUnit.MATRIX_COMPLEMENT_NOTE);
                contentControlComplementMatrix.Content = matrixUnitComplement;

                MatrixUnit matrixUnitTranspons = new Matrix.MatrixUnit(MatrixUnit.MATRIX_TRANSPONS_NOTE);
                contentControlTransponsMatrix.Content = matrixUnitTranspons;

                MatrixUnit matrixUnitResolve = new Matrix.MatrixUnit(MatrixUnit.MATRIX_RESOLVE_NOTE);
                contentControlResolveMatrix.Content = matrixUnitResolve;
            }
        }

        private void OnClickHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В данный момент не доступно", "В стадии разработки");
        }
        private void OnClickBtnAboutHandler(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
