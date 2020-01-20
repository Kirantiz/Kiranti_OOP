using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetvei_i_grsanic
{
    public class CostMatrixItem
    {
        private int cost;
        private int grade;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public CostMatrixItem(int _cost, int _grade)
        {
            cost = _cost;
            grade = _grade;
        }
    }

    public class CostMatrix
    {
        private int size;
        private List<List<CostMatrixItem>> items;
        private List<int> rowsNumbers;
        private List<int> colsNumbers;
        private List<int> currentPartOfPath;

        public int Size
        {
            get { return size; }
        }

        public List<CostMatrixItem> this[int index]
        {
            get { return items[index]; }
        }

        public CostMatrix(List<List<int>> _values)
        {
            size = _values.Count;
            items = new List<List<CostMatrixItem>>();
            for (int i = 0; i < size; i++)
            {
                items.Add(new List<CostMatrixItem>());
                for (int j = 0; j < size; j++)
                    items[i].Add(new CostMatrixItem(_values[i][j], -1));
            }
            rowsNumbers = new List<int>();
            colsNumbers = new List<int>();
            for (int i = 0; i < size; i++)
            {
                rowsNumbers.Add(i + 1);
                colsNumbers.Add(i + 1);
            }
            currentPartOfPath = new List<int>();
        }

        public void ReduceRowsValues()
        {
            int rowMinCostValue = Int32.MaxValue;

            for (int i = 0; i < size; i++)
            {
                rowMinCostValue = Int32.MaxValue;
                for (int j = 0; j < size; j++)
                    if (items[i][j].Cost != -1 && items[i][j].Cost < rowMinCostValue)
                        rowMinCostValue = items[i][j].Cost;

                for (int j = 0; j < size; j++)
                    if (items[i][j].Cost != -1)
                        items[i][j].Cost -= rowMinCostValue;
            }
        }

        public void ReduceColsValues()
        {
            int colMinCostValue = Int32.MaxValue;

            for (int j = 0; j < size; j++)
            {
                colMinCostValue = Int32.MaxValue;
                for (int i = 0; i < size; i++)
                    if (items[i][j].Cost != -1 && items[i][j].Cost < colMinCostValue)
                        colMinCostValue = items[i][j].Cost;

                for (int i = 0; i < size; i++)
                    if (items[i][j].Cost != -1)
                        items[i][j].Cost -= colMinCostValue;
            }
        }

        public void CalculateGrades()
        {
            int rowMinCostValue = Int32.MaxValue;
            int colMinCostValue = Int32.MaxValue;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    items[i][j].Grade = -1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (items[i][j].Cost == 0)
                    {
                        rowMinCostValue = Int32.MaxValue;
                        for (int n = 0; n < size; n++)
                            if (items[i][n].Cost != -1 && n != j && items[i][n].Cost < rowMinCostValue)
                                rowMinCostValue = items[i][n].Cost;

                        colMinCostValue = Int32.MaxValue;
                        for (int n = 0; n < size; n++)
                            if (items[n][j].Cost != -1 && n != i && items[n][j].Cost < colMinCostValue)
                                colMinCostValue = items[n][j].Cost;

                        items[i][j].Grade = rowMinCostValue + colMinCostValue;
                    }
                }
            }
        }

        public void Reduce()
        {
            int maxGradeValue = Int32.MinValue;
            int maxGradeItemRowIndex = 0;
            int maxGradeItemColIndex = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (items[i][j].Grade != -1 && items[i][j].Grade > maxGradeValue)
                    {
                        maxGradeValue = items[i][j].Grade;
                        maxGradeItemRowIndex = i;
                        maxGradeItemColIndex = j;
                    }
                }
            }

            currentPartOfPath.Clear();
            currentPartOfPath.Add(rowsNumbers[maxGradeItemRowIndex]);
            currentPartOfPath.Add(colsNumbers[maxGradeItemColIndex]);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (rowsNumbers[i] == colsNumbers[maxGradeItemColIndex] && colsNumbers[j] == rowsNumbers[maxGradeItemRowIndex])
                        items[i][j].Cost = -1;

            for (int n = 0; n < size; n++)
                items[n].RemoveAt(maxGradeItemColIndex);
            items.RemoveAt(maxGradeItemRowIndex);
            colsNumbers.RemoveAt(maxGradeItemColIndex);
            rowsNumbers.RemoveAt(maxGradeItemRowIndex);
            size--;
        }

        public List<int> GetCurrentPartOfPath()
        {
            return currentPartOfPath;
        }
    }
}
