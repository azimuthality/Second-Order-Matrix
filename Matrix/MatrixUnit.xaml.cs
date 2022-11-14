using System;
using System.Windows.Controls;

namespace Matrix
{
    public partial class MatrixUnit : UserControl
    {
        private double[,] arr;
        private static double determinante;

        public static bool isValidMatrix;
        public static double[,] currentStateMatrix;

        public static string MATRIX_DEFAULT_NOTE = "A";
        public static string MATRIX_DETERMINATE_NOTE = "|A|";
        public static string MATRIX_MINOR_NOTE = "M";
        public static string MATRIX_COMPLEMENT_NOTE = "A.";
        public static string MATRIX_TRANSPONS_NOTE = "T";
        public static string MATRIX_RESOLVE_NOTE = "A^-1";

        public MatrixUnit(double[,] arr, string typeMatrix)
        {
            InitializeComponent();

            this.arr = arr;
            CreateDefaultMatrix();
        }

        public MatrixUnit(string typeMatrix)
        {
            InitializeComponent();

            switch (typeMatrix)
            {
                case "M":
                    CreateMinorMatrix();
                    break;
                case "A.":
                    CreateComplementMatrix();
                    break;
                case "T":
                    CreateTransponsMatrix();
                    break;
                case "A^-1":
                    CreateResolveMatrix();
                    break;
            }
        }

        public bool CheckValidMatrix()
        {
            MatrixUnit.determinante = arr[0, 0] * arr[1, 1] - arr[0, 1] * arr[1, 0];

            return MatrixUnit.determinante != 0;
        }

        public void CreateDefaultMatrix()
        {
            isValidMatrix = CheckValidMatrix();

            labelTypeMatrix.Content = MATRIX_DEFAULT_NOTE + " =";

            labelUnitMatrix11.Content = arr[0, 0];
            labelUnitMatrix12.Content = arr[0, 1];
            labelUnitMatrix21.Content = arr[1, 0];
            labelUnitMatrix22.Content = arr[1, 1];

            labelDeterminantMatrix.Content = MATRIX_DETERMINATE_NOTE + " = " + MatrixUnit.determinante;
            currentStateMatrix = arr;
        }

        public void CreateMinorMatrix()
        {
            double[,] minorMatrix = { { currentStateMatrix[1, 1], currentStateMatrix[1, 0] }, { currentStateMatrix[0, 1], currentStateMatrix[0, 0] } };
            labelTypeMatrix.Content = MATRIX_MINOR_NOTE + " =";

            labelUnitMatrix11.Content = minorMatrix[0, 0];
            labelUnitMatrix12.Content = minorMatrix[0, 1];
            labelUnitMatrix21.Content = minorMatrix[1, 0];
            labelUnitMatrix22.Content = minorMatrix[1, 1];

            currentStateMatrix = minorMatrix;
        }

        public void CreateComplementMatrix()
        {
            double[,] complementMatrix = { { currentStateMatrix[1, 1], currentStateMatrix[1, 0] * -1 }, { currentStateMatrix[0, 1] * -1, currentStateMatrix[0, 0] } };
            labelTypeMatrix.Content = MATRIX_COMPLEMENT_NOTE + " =";

            labelUnitMatrix11.Content = complementMatrix[0, 0];
            labelUnitMatrix12.Content = complementMatrix[0, 1];
            labelUnitMatrix21.Content = complementMatrix[1, 0];
            labelUnitMatrix22.Content = complementMatrix[1, 1];

            currentStateMatrix = complementMatrix;
        }
        public void CreateTransponsMatrix()
        {
            double[,] transponsMatrix = { { currentStateMatrix[0, 0], currentStateMatrix[1, 0] }, { currentStateMatrix[0, 1], currentStateMatrix[1, 1] } };
            labelTypeMatrix.Content = MATRIX_TRANSPONS_NOTE + " =";

            labelUnitMatrix11.Content = transponsMatrix[0, 0];
            labelUnitMatrix12.Content = transponsMatrix[0, 1];
            labelUnitMatrix21.Content = transponsMatrix[1, 0];
            labelUnitMatrix22.Content = transponsMatrix[1, 1];

            currentStateMatrix = transponsMatrix;
        }
        public void CreateResolveMatrix()
        {
            labelTypeMatrix.Content = MATRIX_RESOLVE_NOTE + "=";

            labelUnitMatrix11.Content = Math.Round(currentStateMatrix[0, 0] / MatrixUnit.determinante, 2);
            labelUnitMatrix12.Content = Math.Round(currentStateMatrix[0, 1] / MatrixUnit.determinante, 2);
            labelUnitMatrix21.Content = Math.Round(currentStateMatrix[1, 0] / MatrixUnit.determinante, 2);
            labelUnitMatrix22.Content = Math.Round(currentStateMatrix[1, 1] / MatrixUnit.determinante, 2);
        }
    }
}
