namespace UploadFilesLIbrary
{
    public interface ISqlDataAccess
    {
        Task SaveData(string storedproc, string connectionName, object parameters);
    }
}