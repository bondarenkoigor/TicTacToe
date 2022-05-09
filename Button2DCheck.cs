using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    internal static class Button2DCheck
    {
        public static bool Column(Button[,] arr, int columnNum)
        {
            int lenght = arr.GetLength(0);
            Button[] column = new Button[lenght];
            for (int i = 0; i < lenght; i++)
                column[i] = arr[i, columnNum];

            return column.All<Button>(button => button.Text == column[0].Text);
        }
        public static bool Row(Button[,] arr, int rowNum)
        {
            int lenght = arr.GetLength(1);
            Button[] row = new Button[lenght];
            for (int i = 0; i < lenght; i++)
                row[i] = arr[rowNum, i];

            return row.All<Button>(button => button.Text == row[0].Text);
        }
        public static bool MainDiag(Button[,] arr)
        {
            if (arr.GetLength(0) != arr.GetLength(1)) return false;

            int lenght = arr.GetLength(0);
            Button[] Diagonal = new Button[lenght];
            for (int i = 0; i < lenght; i++)
                Diagonal[i] = arr[i, i];

            return Diagonal.All<Button>(button=>button.Text == Diagonal[0].Text);
        }
        public static bool SecondDiag(Button[,] arr)
        {
            if (arr.GetLength(0) != arr.GetLength(1)) return false;

            int lenght = arr.GetLength(0);
            Button[] Diagonal = new Button[lenght];
            for (int i = lenght - 1; i >= 0; i--)
                Diagonal[i] = arr[i, i];

            return Diagonal.All<Button>(button => button.Text == Diagonal[0].Text);
        }
    }
}
