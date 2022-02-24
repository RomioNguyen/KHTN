using Nhom7_1981223_20880263_BT2.Models.Entities;

namespace Nhom7_1981223_20880263_BT2.Interfaces.Matrix
{
    public interface IAdjacencyMatrixServices
    {
        public bool isSymmetry(AdjacencyMatrix matrix);
        public void runDigraphMatrix(AdjacencyMatrix matrix);
        public void runUnDigraphMatrix(AdjacencyMatrix matrix);
    }
}
