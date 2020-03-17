namespace TreeLibrary.MarshalledTrees
{
    public interface IMarshalledTree
    {
        string Marshall();
        void Unmarshal(string data);
    }

}
