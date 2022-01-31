namespace BT1_1981223_20880263.Sevices.AdjacencyMatrix
{
    public interface IAdjacencyMatrixServices
    {
        public bool isSymmetry(Models.AdjacencyMatrix matrix);
        public void runDigraphMatrix(Models.AdjacencyMatrix matrix);
        public void runUnDigraphMatrix(Models.AdjacencyMatrix matrix);
        public void runSimpleMatrix(Models.AdjacencyMatrix matrix);
    }
}
