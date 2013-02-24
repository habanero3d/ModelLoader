using System.IO;

namespace ModelLoader
{
    public interface IWriteable
    {
		/// <summary>
		/// Writes object data to given BinaryWriter.
		/// </summary>
        void Write(BinaryWriter bw);
    }
}
